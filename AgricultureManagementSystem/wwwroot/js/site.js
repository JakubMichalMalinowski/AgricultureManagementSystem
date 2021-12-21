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

function highlightNoteRow(rowId) {
    $('#note-' + rowId).removeClass('bg-light');
    $('#note-' + rowId).addClass('bg-secondary');
    $('#note-' + rowId).addClass('text-white');
    setTimeout(function () {
        $('#note-' + rowId).removeClass('bg-secondary');
        $('#note-' + rowId).removeClass('text-white');
        $('#note-' + rowId).addClass('bg-light');
    }, 2000);
}