// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    //Lector autocomplete
    $("#lectors").autocomplete({
        source: function (req, res) {
            $.ajax({
                url: "/Lectors/GetLectorsBySearch",
                type: "POST",
                dataType: "JSON",
                data: { search: req.term },
                success: function (data) {
                    res($.map(data, function (item) {
                        return { label: `${item.firstname} ${item.lastname}`, value: `${item.firstname} ${item.lastname}`, id: item.id }
                    }))
                },
            })
        },
        select: function (event, ui) {
            $("#lectorId").val(ui.item.id)
        },
        options: { messages: { noResults: "", results: "" } }
    },800)

    //book autocomplete
    $("#books").autocomplete({
        source: function (req, res) {
            $.ajax({
                url: "/Books/GetBooksBySearch",
                type: "POST",
                dataType: "JSON",
                data: { search: req.term },
                success: function (data) {
                    res($.map(data, function (item) {
                        return { label: `${item.title} - ${item.firstname} ${item.lastname}`, value: `${item.title}`, id: item.id }
                    }))
                },
            })
        },
        select: function (event, ui) {
            $("#bookId").val(ui.item.id)
        },
        options: { messages: { noResults: "", results: "" } }
    },800)
})   

function returnBook(id) {
    $.ajax({
        url: "/Rentails/ReturnBook",
        type: "POST",
        dataType: "JSON",
        data: { id: id },
        success: function (data) {
            console.log(data)
            if (data.success) {
                window.location.reload()
            }
        },
    })
}
                    