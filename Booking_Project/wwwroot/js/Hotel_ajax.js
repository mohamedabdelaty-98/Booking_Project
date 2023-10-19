let hotels = document.getElementById("allhotel");
function addnewhotel() {
    hotels.classList.add("display_visable");
    add_hotel_image.classList.add("display_visable");
    insert_s.classList.remove("display_visable")

    console.log();
    $.ajax(
        {
            url: "/hotel/insert/",
            success: function (result) {
                console.log(result);
                $("#insert_s").html(result);
            }
        }

    );
}
function addimagehotel() {
    hotels.classList.add("display_visable");
    insert_s.classList.add("display_visable")
    add_hotel_image.classList.remove("display_visable");

    console.log();
    $.ajax(
        {
            url: "/ImgHotel/insert/",
            success: function (result) {
                console.log(result);
                $("#add_hotel_image").html(result);
            }
        }

    );
}
