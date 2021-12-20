// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function highlightServiceRow(rowId) {
    $('#service-partial-' + rowId).addClass('highlight');
    setTimeout(function () {
        $('#service-partial-' + rowId).removeClass('highlight');
    }, 5000);
}

function highlightActivityRow(rowId) {
    $('#activity-partial-' + rowId).addClass('highlight');
    setTimeout(function () {
        $('#activity-partial-' + rowId).removeClass('highlight');
    }, 5000);
}