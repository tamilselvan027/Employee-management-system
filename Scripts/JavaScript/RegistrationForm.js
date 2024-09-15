﻿$(document).ready(function () {

    function validateFirstname() {
        const firstname = $('#firstname').val();
        if (firstname === '') {
            $('.fnameerror').text('Enter your firstname');
            $('.fnameerror').css('color', 'red');
            $('#firstname').css('border', '1px solid red');
            return false;
        } else if (firstname.length < 3) {
            $('.fnameerror').text('Name must be in 3 characters');
            $('.fnameerror').css('color', 'red');
            $('#firstname').css('border', '1px solid red');
            return false;
        } else {
            $('.fnameerror').text('');
            $('#firstname').css('border', '1px solid green');
            return true;
        }
    }

    function validateLastname() {
        const lastname = $('#lastname').val();
        if (lastname === '') {
            $('.lnameerror').text('Enter your lastname').css('color', 'red');
            $('#lastname').css('border', '1px solid red');
            return false;
        } else if (firstname.length < 3) {
            $('.lnameerror').text('Name must be in 3 characters').css('color', 'red');
            $('#lastname').css('border', '1px solid red');
            return false;
        } else {
            $('.lnameerror').text('');
            $('#lastname').css('border', '1px solid green');
            return true;
        }
    }

    function validatePhonenumber() {
        const phonenumber = $('#phone').val().trim();
        if (phonenumber === '') {
            $('.phoneerror').text('Enter your phone number');
            $('.phoneerror').css('color', 'red');
            $('#phone').css('border', '1px solid red');
            return false;
        } else if (phonenumber.length === 10) {
            $('.phoneerror').text('');
            $('#phone').css('border', '1px solid green');
            return true;
        } else {
            $('.phoneerror').text('Enter valid phone number');
            $('.phoneerror').css('color', 'red');
            $('#phone').css('border', '1px solid red');
            return false;
        }
    }

    function validateGender() {
        const gender = $('input[name = "gender"]:checked').val();
        if ($('input[type=radio][name=gender]:checked').length == 0) {
            $('.gendererror').text('Please select your gender');
            $('.gendererror').css('color', 'red');
            return false;
        } else {
            $('.gendererror').text('');
            return true;
        }
    }

    function validateDate() {
        const date = $('#date').val();
        // validate for date
        const today = new Date();
        const selectedDate = new Date(date);
        const minAge = 18;
        const ageDiff = today.getFullYear() - selectedDate.getFullYear();
        const monthDiff = today.getMonth() - selectedDate.getMonth();
        const dayDiff = today.getDate() - selectedDate.getDate();

        if (!date) {
            $('.doberror').text('Date of birth is required').css('color', 'red');
            $('#date').css('border', '1px solid red');
            return false;
        } else if (selectedDate > today) {
            $('.doberror').text('date of birth cannot be in future').css('color', 'red');
        } else if (ageDiff < minAge || (ageDiff === minAge && (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0)))) {
            $('.doberror').text(`you must be at least ${minAge} years old`).css('color', 'red');
            $('#date').css('border', '1px solid red');
            return false;
        } else {
            $('.doberror').text('');
            $('#date').css('border', '1px solid green');
            return true;
        }
    }

    function validateCity() {
        const City = $('#City').val();
        if (City === '') {
            $('.cityerror').text('Enter your city').css('color', 'red');
            $('#City').css('border', '1px solid red');
            return false;
        } else {
            $('.cityerror').text('');
            $('#City').css('border', '1px solid green');
            return true;
        }
    }

    function validateState() {
        const State = $('#State').val();
        if (State === '') {
            $('.stateerror').text('Enter your state').css('color', 'red');
            $('#State').css('border', '1px solid red');
            return false;
        } else {
            $('.stateerror').text('');
            $('#State').css('border', '1px solid green');
            return true;
        }
    }

    function validateHiredate() {
        const hiredate = $('#hiredate').val();

        if (!hiredate) {
            $('.hiredateerror').text('Hiredate is required').css('color', 'red');
            $('#hiredate').css('border', '1px solid red');
            return false;
        } else {
            $('.hiredateerror').text('');
            $('#hiredate').css('border', '1px solid green');
            return true;
        }
    }

    function validateDepartment() {
        const departmentname = $('#departmentname').val();
        if (departmentname === '') {
            $('.departmenterror').text('Select department name').css('color', 'red');
            $('#departmentname').css('border', '1px solid red');
            return false;
        } else {
            $('.departmenterror').text('');
            $('#departmentname').css('border', '1px solid green');
            return true;
        }
    }

    function validateEmployeetype() {
        const employeetype = $('#employeetype').val();
        if (employeetype === '') {
            $('.emperror').text('Select employee type').css('color', 'red');
            $('#employeetype').css('border', '1px solid red');
            return false;
        } else {
            $('.emperror').text('');
            $('#employeetype').css('border', '1px solid green');
            return true;
        }
    }

    function validateEmail() {
        const email = $('#email').val();
        const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        if (email === '') {
            $('.emailerror').text('Enter your email Id');
            $('.emailerror').css('color', 'red');
            $('#email').css('border', '1px solid red');
            return false;
        } else if (!regex.test(email)) {
            $('.emailerror').text('Enter the valid email address');
            $('.emailerror').css('color', 'red');
            $('#email').css('border', '1px solid red');
            return false;
        } else {
            $('.emailerror').text('');
            $('#email').css('border', '1px solid green');
            return true;
        }
    }

    function validateUsername() {
        const username = $('#username').val();
        if (username === '') {
            $('.nameerror').text('Enter your username');
            $('.nameerror').css('color', 'red');
            $('#username').css('border', '1px solid red');
            return false;
        } else if (username.length < 3) {
            $('.nameerror').text('Name must be in 3 characters');
            $('.nameerror').css('color', 'red');
            $('#username').css('border', '1px solid red');
            return false;
        } else {
            $('.nameerror').text('');
            $('#username').css('border', '1px solid green');
            return true;
        }
    }

    function validatePassword() {
        const password = $('#password').val();

        const upperName = /[A-Z]+/;
        const numName = /[0-9]+/;

        if (password === '') {
            $('.passerror').text('Enter your password');
            $('.passerror').css('color', 'red');
            $('#password').css('border', '1px solid red');
            return false;
        } else if (password.length < 8) {
            $('.passerror').text('Password must be in 8 letters');
            $('.passerror').css('color', 'red');
            $('#password').css('border', '1px solid red');
            return false;
        } else if (!upperName.test(password)) {
            $('.passerror').text('Password must be in 1 uppercase letter');
            $('.passerror').css('color', 'red');
            $('#password').css('border', '1px solid red');
            return false;
        } else if (!numName.test(password)) {
            $('.passerror').text('Password must be in 1 number');
            $('.passerror').css('color', 'red');
            $('#password').css('border', '1px solid red');
            return false;
        } else {
            $('.passerror').text('');
            $('#password').css('border', '1px solid green');
            return true;
        }

    }

    function validateCpassword() {
        const password = $('#password').val();
        const cpassword = $('#cpassword').val();
        if (cpassword === '') {
            $('.conerror').text('Enter your password');
            $('.conerror').css('color', 'red');
            $('#cpassword').css('border', '1px solid red');
            return false;
        } else if (cpassword === password) {
            $('.conerror').text('');
            $('#cpassword').css('border', '1px solid green');
            return true;
        } else {
            $('.conerror').text('Password mismatch ');
            $('.conerror').css('color', 'red');
            $('#cpassword').css('border', '1px solid red');
            return false;
        }
    }

    $('#firstname').focusout(validateFirstname);
    $('#lastname').focusout(validateLastname);
    $('#phone').focusout(validatePhonenumber);
    $('input[name = "gender"]').focusout(validateGender);
    $('#date').focusout(validateDate);
    $('#City').focusout(validateCity);
    $('#State').focusout(validateState);
    $('#hiredate').focusout(validateHiredate);
    $('#departmentname').focusout(validateDepartment);
    $('#employeetype').focusout(validateEmployeetype);
    $('#email').focusout(validateEmail);
    $('#username').focusout(validateUsername);
    $('#password').focusout(validatePassword);
    $('#cpassword').focusout(validateCpassword);

    $('#submitButton').click(function (e) {
        e.preventDefault();

        var IsvalidateFirstname =validateFirstname();
        var IsvalidateLastname = validateLastname();
        var IsvalidatePhonenumber = validatePhonenumber();
        var IsvalidateGender= validateGender();
        var IsvalidateDate = validateDate();
        var IsvalidateCity = validateCity();
        var IsvalidateState = validateState();
        var IsvalidateHiredate = validateHiredate();
        var IsvalidateDepartment = validateDepartment();
        var IsvalidateEmployeetype = validateEmployeetype();
        var IsvalidateEmail = validateEmail();
        var IsvalidateUsername = validateUsername();
        var IsvalidatePassword =validatePassword();
        var IsvalidateCpassword = validateCpassword();

        console.log(IsvalidateFirstname && IsvalidateLastname && IsvalidatePhonenumber && IsvalidateGender && IsvalidateDate && IsvalidateCity && IsvalidateState && IsvalidateHiredate && IsvalidateDepartment && IsvalidateEmployeetype && IsvalidateEmail && IsvalidateUsername && IsvalidatePassword && IsvalidateCpassword)


        if (IsvalidateFirstname && IsvalidateLastname && IsvalidatePhonenumber && IsvalidateGender && IsvalidateDate && IsvalidateCity && IsvalidateState && IsvalidateHiredate && IsvalidateDepartment && IsvalidateEmployeetype && IsvalidateEmail && IsvalidateUsername && IsvalidatePassword && IsvalidateCpassword) {
            $('#registrationForm').off('submit').submit();
        } else {
            return false;
        }

    })
});