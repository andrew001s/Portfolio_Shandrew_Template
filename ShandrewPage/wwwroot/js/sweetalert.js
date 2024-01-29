

function alerta() {
    Swal.fire({
        title: "Success!",
        icon: "success",
        backdrop: false,
        timer: 1500,
        input: "none",
        showConfirmButton: false
    })
}
function sendemail(e) {
    e.preventDefault();
    Swal.fire({
        title: "Do you want send this email?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: "Yes",
    }).then((result) => {
        if (result.isConfirmed) {
            const form = document.getElementById('formularioCorreo');
            form.submit();
            alerta();
        }
    }) 
  
}
