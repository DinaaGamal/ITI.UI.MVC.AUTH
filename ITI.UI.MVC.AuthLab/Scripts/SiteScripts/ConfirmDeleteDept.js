function ConfirmDelete(id) {
    let Result = confirm("Are you sure ?");
    if (Result) {
        location.href = `/department/delete/${id}`;
    }
}