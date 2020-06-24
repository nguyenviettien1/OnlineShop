var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                        console.log(res.data);
                        console.log(request.term);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.Name);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.Name);   
                
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li class=\"li-auto\">")
                    .append("<div class=\"fix-text\">"
                        + item.Name + "<br>"
                        +"<b>"+ item.Price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + " đ</b></div>"
                        + "<div class=\"fix-img\"><img src=\"" + item.Image + "\"" + "width=50/>"
                        + "</div>")
                    .appendTo(ul);
            };
    }
}
common.init();