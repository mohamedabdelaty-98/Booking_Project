﻿let hotel_disp = document.getElementById("hotels");
let insertHotel = document.getElementById("insert_s");
let addimage = document.getElementById("add_hotel_image");



function DisplayHotels() {
    room_disp.classList.add("display_visable")
    hotel_disp.classList.remove("display_visable");
    $.ajax(
        {
            url: "/hotel/getall/",
            success: function (result) {
                console.log(result);
                $("#hotels").html(result);
            }
        }

    );
}


//section room
var room_disp = document.getElementById("rooms");
function DisplayRooms() {
    hotel_disp.classList.add("display_visable")
    room_disp.classList.remove("display_visable");
    
    console.log("dddd");
    $.ajax(
        {
            url: "/room/rooms/",
            success: function (result) {
                console.log(result);
                $("#rooms").html(result);
            }
        }

    );
}
