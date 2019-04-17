
$(function () {
    // Handler for .ready() called.
    OrderCart();
});

function OrderCart() {
    sendData("Menu/OrderCart", null);
}

function AddOrder(idMenu) {
    sendData("Menu/Add", { "idMenu": idMenu });
}


function HandleResult(result) {
    console.log(result);

    var orderList = '';
    if (result === null) return;

    var ilist = result.itemList;


    orderList += '<div class="row">';
    orderList += '<div class="col-md-2"">';
    orderList += '<h3>Id<h3>';
    orderList += '</div>';
    orderList += '<div class="col-md-2"">';
    orderList += '<h3>Item</h3>';
    orderList += '</div>';
    orderList += '<div class="col-md-2"">';
    orderList += '<h3>Preço</h3>';
    orderList += '</div>';
    orderList += '<div class="col-md-2"">';
    orderList += '<h3>Quantidade</h3>';
    orderList += '</div>';
    orderList += '</div>';



    for (var i = 0; i < ilist.length; i++) {
        orderList += '<div class="row">';
        orderList += '<div class="col-md-2"">';
        orderList += ilist[i].id;
        orderList += '</div>';
        orderList += '<div class="col-md-2"">';
        orderList += ilist[i].menuItem;
        orderList += '</div>';
        orderList += '<div class="col-md-2"">';
        orderList += ilist[i].price;
        orderList += '</div>';
        orderList += '<div class="col-md-2"">';
        orderList += ilist[i].quantity;
        orderList += '</div>';
        orderList += '</div>';
    }

    orderList += '<div>';
    orderList += ' <a href="#" onclick="PlaceOrder();" class="btn btn-sm btn-success" >Finalizar Pedido</a>';
    orderList += '</div>';

    $("#orderlist").html(orderList);
}


function PlaceOrder() {
    sendData("Menu/PlaceOrder", null);

}
