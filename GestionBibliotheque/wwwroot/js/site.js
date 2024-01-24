// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    $("#test").autocomplete({
        source: function (req, res) {
            $.ajax({
                url: "/Lectors/GetLectorsBySearch",
                type: "POST",
                dataType: "JSON",
                data: { search: req.term },
                success: function (data) {
                    res($.map(data, function (item) {
                        return {label: `${item.firstname} ${item.lastname}`, value: item.id}
                    }))
                }
            })
        },
    //    messages: {noResults: "", results: ""}
    })
})   