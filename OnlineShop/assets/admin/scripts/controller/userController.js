var user = {
    init: function () {
        $('#AlertBox').removeClass('hide');
        $('#AlertBox').delay(1000).slideUp(500);
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data("id");
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                type:"POST",
                dataType:"json",               
                success: function (response) {
                    
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                    }
                    else {
                       btn.text('Khóa');
                    }
                },
            });
        });
    }
}
user.init();