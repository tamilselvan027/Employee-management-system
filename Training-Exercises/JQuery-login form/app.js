$(document).ready(function () {
    
    $('#submitButton').click ( function(e) {
        e.preventDefault();
       
        const email = $('#email').val();
        const password = $('#password').val();      

        const regex =/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        // Email validation
        if(email === ''){
            $('.nameerr').text('Enter your username');
            $('.nameerr').css('color' , 'red');
            $('#email').css('border', '1px solid red');
        }else if (!regex.test(email)){
            $('.nameerr').text('Enter the valid email address');
            $('.nameerr').css('color' , 'red');
            $('#email').css('border', '1px solid red');
        } else{
            $('.nameerr').text('');
             $('#email').css('border', '1px solid green');
        }

        // password validation
        if(password === ''){
            $('.error').text('Enter your password');
            $('.error').css('color' , 'red');
            $('#password').css('border', '1px solid red');
        } else if (password.length < 8 ){
            $('.error').text('Password must be in 8 letters');
            $('.error').css('color' , 'red');
            $('#password').css('border', '1px solid red');
        } else{
            $('.error').text('');
            $('#password').css('border', '1px solid green');
        }

    })
});