
/* ---------------- Remove Proof Js -------------------- */
function RemoveMilestoneProof(argUrl)
{
    swal("Sübutu sildikdən sonra geri qaytarmaq mümkün olmayacaq.",
        {
            icon: "warning",
            title: "Bu etmək istədiyindən əminsən?",
            text: "Sübutu sildikdən sonra geri qaytarmaq mümkün olmayacaq.",
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
                            location.reload();
                        }
                       
                    },
                }); // End of AJAX
            }
        }); // End of then
}; // End of Event listener

