function ConfirmDelete(id) {
    let Result = confirm("Are you sure ?");
    if (Result) {
        $.ajax({
            url: `/empolyees/delete/${id}`,
            type: "Get",
            success: function (res) {
                if (res) {
                    $(`#${id}`).remove();
                }
            },
            error: function (err) {
                console.log(err)
            }
        })
    }
}