
$(document).ready(function () {
    var numItems = sessionStorage.getItem('cart-num-items');
    console.log(numItems);
    if (!numItems || numItems === 0) {
        console.log("in if")
        sessionStorage.setItem('cart-num-items', 0);
        $("#cart-num-items").hide();
    }
    else {
        console.log("in else")
        $("#cart-num-items").show();
    }
    $("#cart-num-items").html(numItems);

});

var getNumOfItems = function () {
    return sessionStorage.getItem('cart-num-items') || 0;
}

$(".minus").click(function(event){
    event.preventDefault();
    $.post({
        url: this.href,
        success: function (data) {
            console.log("quntity increased");
            var prevItems = sessionStorage.getItem('cart-num-items');
            $("#cart-num-items").html(++prevItems);
            sessionStorage.setItem('cart-num-items', prevItems)
            $("#cart-num-items").show();
        }
    });
})

$(".add-to-cart-btn").click(function (event) {

    event.preventDefault();
    $.post({
        url: this.href,
        success: function (data) {
            console.log("added to cart");
            var prevItems = sessionStorage.getItem('cart-num-items');
            $("#cart-num-items").html(++prevItems);
            sessionStorage.setItem('cart-num-items', prevItems)
            $("#cart-num-items").show();
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
