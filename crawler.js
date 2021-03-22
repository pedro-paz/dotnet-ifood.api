function observe(element) {
  const self = this === window ? new observe(element) : this;

  self.element = element || self.element;

  this.assertExist = function (querySelector) {
    return new Promise((resolve) => {
      const observer = new MutationObserver(() => {
        if (!!document.querySelector(querySelector)) {
          setTimeout(() => resolve(self));
          observer.disconnect();
        }
      });
      observer.observe(element, { childList: true, subtree: true });
    });
  };

  this.assertDoesntExist = function (querySelector) {
    return new Promise((resolve) => {
      const observer = new MutationObserver(() => {
        if (!document.querySelector(querySelector)) {
          setTimeout(() => resolve(self));
          observer.disconnect();
        }
      });
      observer.observe(element, { childList: true, subtree: true });
    });
  };

  return self;
}

let collectProduct = () => {
  let modal = document?.querySelector(".dish__container");
  let productPrice =
    modal?.querySelector(".dish-price__original") ||
    modal?.querySelector(".dish-price");
  return {
    name: modal?.querySelector(".nav-header__title")?.innerText || null,
    description:
      modal?.querySelector(".dish-content__details")?.innerText || null,
    price: Number(
      productPrice?.innerText?.replace(/(^R\$ )/, "").replace(",", ".")
    ),
    discountPrince:
      Number(
        modal
          ?.querySelector(".dish-price__discount")
          ?.childNodes?.[0].textContent.replace(/(^R\$ )/, "")
          .replace(",", ".")
      ) || null,
    complementGroups: [...modal.querySelectorAll(".garnish-choices__list")].map(
      (complementGroupElement) => {
        let complementDescription = complementGroupElement.querySelector(
          ".garnish-choices__title span:last-child"
        )?.innerText;
        let complementRequired =
          complementDescription.toLowerCase().indexOf("até") == -1;
        return {
          name: complementGroupElement.querySelector(".garnish-choices__title")
            .childNodes?.[0].textContent,
          min: !complementRequired
            ? 0
            : Number(complementDescription.match(/\d/)[0]) || 0,
          max: Number(complementDescription.match(/\d+/)[0]),
          complements: [
            ...complementGroupElement.querySelectorAll(
              ".garnish-choices__label"
            ),
          ].map((complementElement) => {
            return {
              name: complementElement.querySelector(
                ".garnish-choices__option-desc"
              ).childNodes?.[0].textContent,
              price:
                Number(
                  complementElement
                    .querySelector(".garnish-choices__option-price")
                    ?.textContent.replace(/(^\+? ?R\$ )/, "")
                    .replace(",", ".")
                ) || 0,
              description:
                complementElement.querySelector(
                  ".garnish-choices__option-details"
                )?.textContent ?? null,
            };
          }),
        };
      }
    ),
  };
};

let getNextElement = (current, selector) => {
  let list = [...document.querySelectorAll(selector)];
  const nextProducts = list.filter((x, i) => i > list.indexOf(current));
  return (nextProducts && nextProducts?.[0]) || null;
};

let scrollToElement = (element) => {
  element &&
    window.scroll(0, element.getBoundingClientRect().top + window.scrollY);
};

function collectAllProducts(currentProduct) {
  return new Promise((resolve) => {
    currentProduct.click();
    observe(document.body)
      .assertExist(".ReactModalPortal .dish__container")
      .then((observer) => {
        allCompanies[allCompanies.length - 1].products.push(collectProduct());
        document.querySelector(".dish__container .nav-header button").click();
        observer.assertDoesntExist(".ReactModalPortal").then(() => {
          currentProduct = getNextElement(currentProduct, ".dish-card");
          scrollToElement(currentProduct);
          if (currentProduct) {
            resolve(collectAllProducts(currentProduct));
          } else {
            resolve();
          }
        });
      });
  });
}

function collectAllCompanies(currentCompany) {
  currentCompany.click();
  observe(document.body)
    .assertExist(".dish-card")
    .then((observer) => {
      document.querySelector(".merchant-details__button").click();
      observer
        .assertExist(".drawer__content-container .merchant-details-about")
        .then((observer) => {
          allCompanies.push({
            name: document.querySelector(".merchant-info__title").innerText,
            street: document
              .querySelectorAll(
                ".merchant-details-about .merchant-details-about__info-data"
              )?.[0]
              .innerText.split(",")?.[0],
            streetNumber: document
              .querySelectorAll(
                ".merchant-details-about .merchant-details-about__info-data"
              )?.[0]
              .innerText.split(/[,-]/)?.[1],
            district: document
              .querySelectorAll(
                ".merchant-details-about .merchant-details-about__info-data"
              )?.[0]
              .innerText.split(/[,-]/)[2]
              .replace(/^ +| +$/g, ""),
            zip: document
              .querySelectorAll(
                ".merchant-details-about .merchant-details-about__info-data"
              )?.[2]
              .innerText.split(" ")
              .pop(),
            state: document
              .querySelectorAll(
                ".merchant-details-about .merchant-details-about__info-data"
              )?.[1]
              .innerText.split("-")
              .pop()
              ?.replace(/^ +| +$/g, ""),
            city: document
              .querySelectorAll(
                ".merchant-details-about .merchant-details-about__info-data"
              )?.[1]
              .innerText.split("-")[0]
              .replace(/^ +| +$/g, ""),
            rating: Number(
              document.querySelector(".restaurant-rating").innerText
            ),
            minimumOrderValue: Number(
              document
                .querySelector(".merchant-info__minimum-order")
                ?.innerText.match(/(\d|,)+/g)?.[0]
                .replace(",", ".")
            ),
            products: [],
          });
          collectAllProducts(document.querySelector(".dish-card")).then(() => {
            window.history.back();
            observer.assertExist(".restaurant-card__link").then(() => {
              currentCompany = [
                ...document.querySelectorAll(".restaurant-card__link"),
              ].filter(
                (x) =>
                  currentCompany.querySelector(".restaurant-name").innerText ==
                  x.querySelector(".restaurant-name").innerText
              )[0];
              currentCompany = getNextElement(
                currentCompany,
                ".restaurant-card__link"
              );
              if (currentCompany) {
                collectAllCompanies(currentCompany);
              }
            });
          });
        });
    });
}

let allCompanies = [];
collectAllCompanies(document.querySelector(".restaurant-card__link"));
