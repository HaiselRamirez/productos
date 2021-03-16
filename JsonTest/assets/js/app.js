//const { ajax } = require("jquery");
//const { parseJSON } = require("jquery");
//const { parseJSON } = require("jquery");

$(function () {
  selecAnio();
  getProducts();
});

function selecAnio() {
  var d = new Date();
  var n = d.getFullYear();
  for (var i = n; i >= 1999; i--)
    $("#slAnio").append("<option value="+ i+">Año " + i + "</option>");
}


function getProducts() {
  $.ajax({
    method: "post",
    url: "Default.aspx/getProducts",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (re) {
      var data = re.d;
      var sl = $("#slDepartamento");
      $.each(data, function (item, i) {
        sl.append('<option value=' + i.id + '>' + i.Producto + '</option>');
      })
		}
	})
}