﻿
$(".cart-items").hide();

$("#add-to-cart-btn").click(function (event) {
    event.preventDefault();
    var prevItems = parseInt($("#cart-num-items").text());
    console.log(prevItems);
    $("#cart-num-items").html(++prevItems);
    console.log(prevItems);
    $(".cart-items").show();
});

window.fbAsyncInit = function () {
    FB.init({
        appId: 'your-app-id',
        xfbml: true,
        version: 'v2.7'
    });
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));