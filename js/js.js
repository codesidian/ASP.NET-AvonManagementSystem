function sendOrder() {

    var Order =  '{"products":[]}';

    var ordobj = JSON.parse(Order);

     var table = document.getElementById("table");
    var prodid = ' '; var prodname = ' '; var prodquant = ' '; var prodprice = ' ';

     for (var i = 1, row; row = table.rows[i]; i++) {
         var product = '{"productID":"","productName":"","quantity":"","price":""}';
         var prodobj = JSON.parse(product);
        for (var j = 0, col; col = row.cells[j]; j++) {
            if (j == 1) { prodid = col.getElementsByClassName("form-control")[0].value; } 
            else if (j == 2) { prodname = col.getElementsByClassName("form-control")[0].value; }
            else if (j == 3) { prodquant = col.getElementsByClassName("form-control")[0].value;  }
            else if (j == 4) { prodprice = col.getElementsByClassName("form-control")[0].value;  }
         }
         prodobj.productID = prodid;
         prodobj.productName = prodname;
         prodobj.quantity = prodquant;
         prodobj.price = prodprice;
         var prodstr = JSON.stringify(prodobj);
         ordobj['products'].push(prodobj);

         var curob = JSON.stringify(ordobj);
         testarea.innerHTML = curob; 
    }

    var jsonStr = JSON.stringify(ordobj);
    var sss = '{"products":[{"productID":"111","productName":"1","quantity":"1","price":"1"},{"productID":"2","productName":"2","quantity":"2","price":"2"}]}'
    __doPostBack('processOrder', JSON.stringify(jsonStr));
}



 function AddRow()
 {
     var table = document.getElementById("table");

     table.rows[ table.rows.length - 1 ].cells[0].innerHTML = "";

     let lastRow = table.rows[table.rows.length-1];
     let lastCell = lastRow.cells[lastRow.cells.length-1];
     lastCell.innerHTML = "";

 var row = table.insertRow(-1);
 var cell1 = row.insertCell(0);
 var cell2 = row.insertCell(1);
 var cell3 = row.insertCell(2);
 var cell4 = row.insertCell(3);
 var cell5 = row.insertCell(4);
 var cell6 = row.insertCell(5);
     cell1.innerHTML = "<div class=\"form-group\"><button class=\"btn btn-primary\" onclick=\"AddRow();\"><i class=\"fa fa-plus\"></i></button></div>";
     cell2.innerHTML = "<div class=\"form-group\"><input type=\"text\" class=\"form-control\" placeholder=\"Product Number\"></div>"
     cell3.innerHTML = "<div class=\"form-group\"><input type=\"text\" class=\"form-control\" placeholder=\"Product Name\"></div>";
     cell4.innerHTML = "<div class=\"form-group\"><input type=\"text\" class=\"form-control\" placeholder=\"0\"></div>";
     cell5.innerHTML = "<div class=\"form-group input-icon\"><input type=\"text\" class=\"form-control\" placeholder=\"0.00\"><i>&#163</i></div>";
     cell6.innerHTML = "<div class=\"form-group\"><button class=\"btn btn-danger\"  onclick=\"myDeleteFunction();\"><i class=\"fa fa-minus\"></i></button></div>";
 

 }
 
 function myDeleteFunction() {
 document.getElementById("table").deleteRow(-1);
 var table = document.getElementById("table");
 table.rows[ table.rows.length - 1 ].cells[0].innerHTML = "<button class=\"btn btn-primary\" onclick=\"AddRow();\"><i class=\"fa fa-plus\"></i></button>";
 if (table.rows.length>2){
 table.rows[ table.rows.length - 1 ].cells[5].innerHTML = "<button class=\"btn btn-danger\" onclick=\"myDeleteFunction();\"><i class=\"fa fa-minus\"></i></button>";}
}