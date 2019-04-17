
$(function () {
    // Handler for .ready() called.
    GetCookList();
});

function GetCookList() {
    sendData("Cook/GetCookList", null);
}





function HandleResult(result) {
    console.log(result);

    var orderList = '';
    if (result === null) return;


    var ilist = result.items;

    for (var i = 0; i < ilist.length; i++)
    {
        orderList += '<div class="row">';
        orderList += '<div class="col-md-12""><h3>Pedido: ';
        orderList += ilist[i].id;
        orderList += '</h3></div>';
        let cookList = ilist[i].itemList;

        
        for (var j = 0; j < cookList.length; j++) {
            orderList += '<div class="row">';
            orderList += '<div class="col-md-2"">';
            orderList += cookList[j].id;
            orderList += '</div>';
            orderList += '<div class="col-md-2"">';
            orderList += cookList[j].menuItem;
            orderList += '</div>';
            orderList += '<div class="col-md-2"">';
            orderList += cookList[j].quantity;
            orderList += '</div>';
            orderList += '</div>';
            
        }
        

        
        orderList += '</div>';
    }

   // orderList += '<div>';
   // orderList += ' <a href="#" onclick="PlaceOrder();" class="btn btn-sm btn-success" >Finalizar Pedido</a>';
   // orderList += '</div>';

    $("#cooklist").html(orderList);
}