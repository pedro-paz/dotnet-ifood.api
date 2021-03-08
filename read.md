# Colect Product

```
let modal = document.querySelector(".dish__container");
let productPrice = modal.querySelector('.dish-price__original') || modal.querySelector('.dish-price')
let product = {
    name: modal.querySelector('.nav-header__title')?.innerText || null,
    description: modal.querySelector('.dish-content__details')?.innerText || null,
    price: Number(productPrice.innerText.replace(/(^R\$ )/,'').replace(',','.')),
    complementGroups: [...modal.querySelectorAll('.garnish-choices__list')].map(complementGroupElement => {
        let complementDescription = complementGroupElement.querySelector('.garnish-choices__title span:last-child')?.innerText
        let complementRequired = complementDescription.toLowerCase().indexOf('até') == -1
        return {
            name:complementGroupElement.querySelector('.garnish-choices__title').childNodes[0].textContent,
            min: !complementRequired ? 0 : Number(complementDescription.match(/\d/)[0]),
            max: Number(complementDescription.match(/\d+/)[0]),
            complements: [...complementGroupElement.querySelectorAll('.garnish-choices__label')].map(complementElement => {
                return {
                    name: complementElement.querySelector('.garnish-choices__option-desc').childNodes[0].textContent,
                    price: Number(complementElement.querySelector('.garnish-choices__option-price')?.textContent.replace(/(^\+? ?R\$ )/,'').replace(',','.')) || 0,
                    description: complementElement.querySelector('.garnish-choices__option-details')?.textContent ?? null
                }
            })
        }
    })
}
```
