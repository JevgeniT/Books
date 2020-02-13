
$(document).on('click', '#remove', function (event) {
    event.preventDefault();
    let row = $(this);
    var link = $(this).parents().attr('href');

    $.ajax({
        type: 'POST',
        url: link,
        success: function () {
            $(row).closest("tr").remove();
        }
    });
});

$(document).on('click', '#edit', function (event) {
    $('#BookModal').modal('toggle');
    $('#BookId').val($(this).parents('tr:first').attr('id'));
});

$(document).on('click', '#comment', function (event) {
    let id = $(this).parents('tr:first').attr('id');
    $.ajax({
        type: 'GET',
        url: "https://localhost:5001/Comments/"+id,
        success: function (response) {
            $('#AddCommentModal').modal('toggle');
            $("#bookComments").html(response);
            $('input#BookId').val(id);
        }   
    });
});

$(document).on('click', '#edit', function (event) {
    $('#AuthorModal').modal('toggle');
    $('#AuthorId').val($(this).parents('tr:first').attr('id'));
   
}); 

$(document).on('click', '#edit', function (event) {
    $('#PublisherModal').modal('toggle');
    $('#PublisherId').val($(this).parents('tr:first').attr('id'));

});
$('form#searchForm').on('submit', function (event) {
    event.preventDefault();
    $.ajax({
        type: 'GET',
        url: "https://localhost:5001/?search="+$('#searchField').val(),
        success: function (response) {
            $('tbody').replaceWith($(response).find('tbody'))
        }
    });
});

// $('#bookAuthorModal').on('submit', function (event) {
//     event.preventDefault();
//     $.ajax({
//         type: 'GET',
//         url: "https://localhost:5001/BookAuthor",
//         success: function (response) {
//         
//         }
//     });
// });