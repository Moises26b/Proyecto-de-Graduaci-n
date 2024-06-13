function usernameQuery(username) {
    $.ajax({
        type: "POST",
        url: "/login/encontrarUsuario",
        data: { username },
        success: function (data) {
            console.log(data);
            if (data == "true") {
                console.log(data);
                $("#errorMessage").text("El usuario o correo existe").removeAttr("class").addClass("success-message-shown");
                clearAlert("#errorMessage");
            } else {
                console.log(data);
                $("#errorMessage").text("El usuario o correo no existe").removeAttr("class").addClass("error-message-shown");
                clearAlert("#errorMessage");
            }
            console.log("success");
        }
    });
}
function sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}
async function clearAlert(tagPorLimpiar) {
    await sleep(2000);
    $(tagPorLimpiar).text("").removeAttr("class").addClass("error-message");
}

// Define a debounce function
function debounce(func, delay) {
    let timer;
    return function () {
        const context = this;
        const args = arguments;
        clearTimeout(timer);
        timer = setTimeout(() => {
            try {
                func.apply(context, args);
            } catch (error) {
                console.error('Error in debounced function:', error);
            }
        }, delay);
    };
}

// Your event listener function
const usernameInput = document.getElementById('username');

usernameInput.addEventListener('input', debounce(function () {
    const username = usernameInput.value;
    // Call the AJAX function with debounced input
    usernameQuery(username);
}, 500));

const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');


registerBtn.addEventListener('click', () => {
    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});

document.getElementById('EnviarFormLogin').addEventListener('click', function () {
    document.getElementById('FormLogin').submit();
});

// Function to close the popup
function closePopup() {
    var popup = document.getElementById('popup');
    popup.style.display = 'none';
}

// Function to display the popup when the page loads
window.onload = function () {
    var popup = document.getElementById('popup');
    popup.style.display = 'block';
};