$(document).ready(function () {


    function validateUsername() {
        const username = $('#username').val();
        // Email validation
        if (username === '') {
            $('.nameerr').text('Enter your username').css('color', 'red');
            $('#username').css('border', '1px solid red');
            return false;
        } else {
            $('.nameerr').text('');
            $('#username').css('border', '1px solid green');
            return true;
        }
    }

    function validatePassword() {
        const password = $('#password').val();
        // password validation
        if (password === '') {
            $('.error').text('Enter your password');
            $('.error').css('color', 'red');
            $('#password').css('border', '1px solid red');
            return false;
        } else if (password.length < 8) {
            $('.error').text('Password must be in 8 letters');
            $('.error').css('color', 'red');
            $('#password').css('border', '1px solid red');
            return false;
        } else {
            $('.error').text('');
            $('#password').css('border', '1px solid green');
            return true;
        }

    }

    $('#username').focusout(validateUsername);
    $('#password').focusout(validatePassword);

    $('#submitButton').click(function (e) {
        e.preventDefault();

        var IsvalidateUsername = validateUsername();
        var IsvalidatePassword = validatePassword();

        console.log(IsvalidateUsername);
        console.log(IsvalidatePassword);

        if (IsvalidateUsername && IsvalidatePassword) {
            $('#loginForm').off('submit').submit();
        } else {
            return false;
            console.log("test");
        }
    })
});

function togglePassword() {
    var pwdField = document.getElementById("password");
    var toggleIcon = document.getElementById("togglePwd");

    if (pwdField.type === "password") {
        pwdField.type = "text";
        toggleIcon.classList.remove("fa-eye-slash");
        toggleIcon.classList.add("fa-eye");
    } else {
        pwdField.type = "password";
        toggleIcon.classList.remove("fa-eye");
        toggleIcon.classList.add("fa-eye-slash");
    }
}
