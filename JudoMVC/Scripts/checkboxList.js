$(function () {
    var checkedListBox = $(".checked-list-box");

    $('.checked-list-box').children('li').each(function () {
        $(this).click(function () {
            var checkbox = $(this).children(".checkbox");
            checkbox.click(function(e) {
                e.preventDefault();
            });
            if (checkbox.is(":checked")) {
                checkbox[0].checked = false;
                $(this).removeClass("checked");

            } else {
                checkbox[0].checked = true;
                $(this).addClass("checked");
            }
        });
    });
});