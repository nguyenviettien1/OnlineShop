var user = {
    init: function () {
        user.loadProvince();
        user.registerEvent();
    },
    registerEvent: function () {
        $('#ProvinceID').off('change').on('change', function () {
            var id = $(this).val();
            if (id != '') {
                user.loadDistrict(parseInt(id));
            }
            else {
                $('#DistrictID').html('');
            }
        });
    },
    loadProvince: function () {
        
        $.ajax({
            url: 'User/LoadProvince',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var data = res.data;
                    var html = '<option value="">--Chọn tỉnh thành--</option>';
                    $.each(data, function (i, item) {
                        html += '<option value=' + item.ID + '>' + item.Name +'</option>'  
                    });
                    $('#ProvinceID').html(html);
                }
            }
        })
    },
    loadDistrict: function (id) {
        $.ajax({
            url: '/User/LoadDistrict',
            type: "POST",
            data: { provinceID: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn quận huyện--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID + '">' + item.Name + '</option>'
                    });
                    $('#DistrictID').html(html);
                }
            }
        })
    }
}
user.init();