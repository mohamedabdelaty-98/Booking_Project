let items = document.querySelectorAll(".itemm .nav-link");

items.forEach(
    e => {
        e.addEventListener("click", function () {
            var item = this;
            items.forEach(
                e => {
                    e.classList.remove("active");
                     });
        item.classList.add("active");
        console.log(item);
    })
    }
);

