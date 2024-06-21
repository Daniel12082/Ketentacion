(function () {
    'use strict';

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation');

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                form.classList.add('was-validated');
            }, false);
        });
})();

document.addEventListener("DOMContentLoaded", function() {
    document.querySelector("form.user").addEventListener("submit", function(event) {
        event.preventDefault();

        var firstName = document.getElementById("FirstName").value;
        var lastName = document.getElementById("LastName").value;
        var email = document.getElementById("Email").value;
        var password = document.getElementById("Password").value;
        var repeatPassword = document.getElementById("RepeatPassword").value;

        // Validar que las contraseñas coincidan
        if (password !== repeatPassword) {
            alert("Las contraseñas no coinciden");
            return;
        }

        // Crear un objeto con los datos del formulario
        var data = {
            "email": email,
            "username": lastName,
            email: email,
            password: password
        };

        const endpointUrl = "http://localhost:5101/user/register";

        // Verificar si el correo electrónico ya está registrado
        fetch(endpointUrl + "?email=" + encodeURIComponent(email))
            .then(response => response.json())
            .then(existingUser => {
                if (existingUser.exists) {
                    alert("El usuario ya está registrado");
                } else {
                    // Realizar la solicitud HTTP con los datos del formulario
                    fetch(endpointUrl, {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                            },
                            body: JSON.stringify(data),
                        })
                        .then(response => {
                            if (response.status === 200) {
                                window.location.href = "/index.html"; // Redirige si el registro es exitoso
                            } else if (response.status === 400) {
                                throw new Error('El usuario ya está registrado');
                            } else {
                                throw new Error('Error al registrar usuario');
                            }
                        })
                        .catch(error => {
                            // Manejar errores y mostrar mensaje de error
                            alert(error.message);
                        });
                }
            })
            .catch(error => {
                // Manejar errores y mostrar mensaje de error
                alert('Error al verificar el correo electrónico: ' + error.message);
            });
    });
});