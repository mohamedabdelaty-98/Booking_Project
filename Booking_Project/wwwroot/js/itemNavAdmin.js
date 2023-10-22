let items = document.querySelectorAll(".itemm .nav-link");



//hotel.addEventListener("click", () => {
//    hotel.classList.add("active");
//});

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

