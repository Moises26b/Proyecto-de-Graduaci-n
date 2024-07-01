document.addEventListener('DOMContentLoaded', function () {
    var submitBtn = document.getElementById('submitBtn');
    var successAlert = document.getElementById('successAlert');
    var validationAlert = document.getElementById('validationAlert');
    var registrationForm = document.getElementById('registrationForm');

    submitBtn.addEventListener('click', function () {
        if (registrationForm.checkValidity()) {
            // Muestra la alerta de registro completado
            successAlert.style.display = 'block';

            // Simula una redirección o cualquier otro comportamiento después de mostrar la alerta
            setTimeout(function () {
                successAlert.style.display = 'none'; // Oculta la alerta después de 3 segundos
            }, 3000); // 3000 milisegundos = 3 segundos
        } else {
            // Muestra la alerta de validación
            validationAlert.style.display = 'block';

            // Oculta la alerta de validación después de 3 segundos
            setTimeout(function () {
                validationAlert.style.display = 'none';
            }, 3000);
        }
    });
});