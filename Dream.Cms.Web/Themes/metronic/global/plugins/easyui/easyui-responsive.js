$(function () {

    $(window).on("resize", function () {
        $(".table-model-list").datagrid("resize");
    });
});