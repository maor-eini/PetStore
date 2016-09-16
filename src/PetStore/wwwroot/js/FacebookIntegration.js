
$(document).ready(function () {
    $("#cart-num-items").hide();
    var numItems = localStorage['cart-num-items'];
    if(!numItems)
        localStorage['cart-num-items'] = 0;
});



$(".add-to-cart-btn").click(function (event) {
    event.preventDefault();
    var prevItems = parseInt(localStorage['cart-num-items']);
    $("#cart-num-items").html(++prevItems);
    $("#cart-num-items").show();


    $.post({
        url:this.href,
        success: function (data) {
            console.log("added to cart");
        },
        error: function () {
            console.log("failed to add to cart");
        }
    });
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
