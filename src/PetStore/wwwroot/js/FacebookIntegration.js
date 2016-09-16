
$("#cart-num-items").hide();

$(".add-to-cart-btn").click(function (event) {
    event.preventDefault();
    var prevItems = parseInt($("#cart-num-items").text());
    $("#cart-num-items").html(++prevItems);
    $("#cart-num-items").show();

    $.ajax(this.href, {
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
