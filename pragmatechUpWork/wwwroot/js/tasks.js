
/* ---------------- Remove Task Js -------------------- */
function RemoveTask(argUrl)
{
    swal("Taskı sildikdən sonra geri qaytarmaq mümkün olmayacaq.",
        {
            icon: "warning",
            title: "Bu etmək istədiyindən əminsən?",
            text: "Taskı sildikdən sonra geri qaytarmaq mümkün olmayacaq.",
            buttons: {
                cancel: "Yox!",
                catch: {
                    text: "Hə!",
                    value: "remove",
                },
            },
        }) //End of swal
        .then((value) => {
            if (value == 'remove') {
                $.ajax({
                    type: "DELETE",
                    url: location.origin + argUrl,
                    success: function (response)
                    {
                        if (response.error == "none")
                        {
                            console.log("Hello BRATKA")
                            location.reload();
                        }
                       
                    },
                }); // End of AJAX
            }
        }); // End of then
}; // End of Event listener