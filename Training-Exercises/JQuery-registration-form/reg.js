$(document).ready(function () {
    
    $('#submitButton').click ( function(e) {
        e.preventDefault();
        
        const username = $('#username').val();
        const phonenumber = $('#phone').val();
        const email = $('#email').val();
        const password = $('#password').val();      
        const cpassword = $('#cpassword').val();
        const date = $('#date').val();

        const regex =/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        const upperName = /[A-Z]+/;
        const numName = /[0-9]+/;
        // validate for date
        const today = new Date();
        const selectedDate = new Date(date);
        const minAge = 18;
        const ageDiff = today.getFullYear() - selectedDate.getFullYear();
        const monthDiff = today.getMonth() - selectedDate.getMonth();
        const dayDiff = today.getDate() - selectedDate.getDate();

        if(!date) {
            $('.doberror').text('Date of birth is required');
            $('.doberror').css('color' , 'red');
            $('#date').css('border', '1px solid red');
        } else if ( selectedDate > today){
            $('.doberror').text('date of birth cannot be in future');
            $('.doberror').css('color' , 'red');
            $('#date').css('border', '1px solid red');
        }else if (ageDiff < minAge || (ageDiff === minAge && (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0 )))){
            $('.doberror').text(`you must be at least ${minAge} years old`);
            $('.doberror').css('color' , 'red');
            $('#date').css('border', '1px solid red');
        } else {
            $('.doberror').text('');
            $('#date').css('border', '1px solid green');
        }

        // username validation
        if(username === ''){
            $('.nameerror').text('Enter your username');
            $('.nameerror').css('color' , 'red');
            $('#username').css('border', '1px solid red');
        } else if (username.length < 3) {
            $('.nameerror').text('Name must be in 3 characters');
            $('.nameerror').css('color' , 'red');
            $('#username').css('border', '1px solid red');
        } else {
            $('.nameerror').text('');
            $('#username').css('border', '1px solid green');
        }

        // phonenumber validation
        if(phonenumber === ''){
            $('.phoneerror').text('Enter your phone number');
            $('.phoneerror').css('color' , 'red');
            $('#phone').css('border', '1px solid red');
        } else if (phonenumber.length === 10) {
            $('.phoneerror').text('');
            $('#phone').css('border', '1px solid green');
        } else {
            $('.phoneerror').text('Enter valid phone number');
            $('.phoneerror').css('color' , 'red');
            $('#phone').css('border', '1px solid red');
        }

        // gender(radio) validation
        if($('input[type=radio][name=gender]:checked').length == 0)
            {
                $('.gendererror').text('Please select your gender');
                $('.gendererror').css('color' , 'red');
            } else {
                $('.gendererror').text('');
            } 

        // Email validation
        if(email === ''){
            $('.emailerror').text('Enter your email Id');
            $('.emailerror').css('color' , 'red');
            $('#email').css('border', '1px solid red');
        }else if (!regex.test(email)){
            $('.emailerror').text('Enter the valid email address');
            $('.emailerror').css('color' , 'red');
            $('#email').css('border', '1px solid red');
        } else{
            $('.emailerror').text('');
             $('#email').css('border', '1px solid green');
        }

        
        // password validation
        if(password === ''){
            $('.passerror').text('Enter your password');
            $('.passerror').css('color' , 'red');
            $('#password').css('border', '1px solid red');
        } else if (password.length < 8){
            $('.passerror').text('Password must be in 8 letters');
            $('.passerror').css('color' , 'red');
            $('#password').css('border', '1px solid red');
        } else if (!upperName.test(password)){
            $('.passerror').text('Password must be in 1 uppercase letter');
            $('.passerror').css('color' , 'red');
            $('#password').css('border', '1px solid red');
        } else if (!numName.test(password)){
            $('.passerror').text('Password must be in 1 number');
            $('.passerror').css('color' , 'red');
            $('#password').css('border', '1px solid red');
        } else{
            $('.passerror').text('');
            $('#password').css('border', '1px solid green');
        }

        //  confirm password validation
        if(cpassword === ''){
            $('.conerror').text('Enter your password');
            $('.conerror').css('color' , 'red');
            $('#cpassword').css('border', '1px solid red');
        } else if ( cpassword === password ){
            $('.conerror').text('');
            $('#cpassword').css('border', '1px solid green');
        } else {
            $('.conerror').text('Password mismatch ');
            $('.conerror').css('color' , 'red');
            $('#cpassword').css('border', '1px solid red');
        }

    })
});