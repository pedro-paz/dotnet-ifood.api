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

let getNextListProduct = (product) => {
  let list = [...document.querySelectorAll(".dish-card")];
  const nextProducts = list.filter((x, i) => i > list.indexOf(product));
  return (nextProducts && nextProducts?.[0]) || null;
};

let scrollToProduct = (product) => {
  product &&
    window.scroll(0, product.getBoundingClientRect().top + window.scrollY);
};

let allProducts = [];
let currentListProduct = document.querySelector(".dish-card");

let observer = new MutationObserver((mutationList, observer) => {
  const expectedSelector = ".ReactModalPortal";
  const addedNodes = mutationList.map((x) => [...x.addedNodes]).flat();
  const removednodes = mutationList.map((x) => [...x.removedNodes]).flat();
  const expectedElementAdded =
    addedNodes.filter((x) => x.matches(expectedSelector)).length > 0;
  const expectedElementRemoved =
    removednodes.filter((x) => x.matches(expectedSelector)).length > 0;
  setTimeout(() => {
    if (expectedElementAdded) {
      allProducts.push(collectProduct());
      currentListProduct = getNextListProduct(currentListProduct);
      if (currentListProduct == null) {
        observer.disconnect();
        console.log("terminou!");
      } else {
        scrollToProduct(currentListProduct);
      }
      document?.querySelector(".dish__container .nav-header button").click();
    } else if (expectedElementRemoved) {
      currentListProduct?.click();
    }
  }, 2000);
});

observer.observe(document.querySelector("body"), { childList: true });
scrollToProduct(currentListProduct);
currentListProduct.click();
