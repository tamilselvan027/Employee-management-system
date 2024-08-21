const form = document.getElementById('form');
const fullname = document.getElementById('fullname');
const email = document.getElementById('email');
const password = document.getElementById('password');
const date = document.getElementById('date');


form.addEventListener('submit', e => {
    e.preventDefault();
    validateInput();
})

const setError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = message;
    inputControl.classList.add('error');
    inputControl.classList.remove('success');
}

const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('error');
}

const isValidEmail = email => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

const validateInput = () => {
    const fullnameValue = fullname.value.trim();
    const emailValue = email.value.trim();
    const passwordValue = password.value.trim();
    const dateValue = date.value;

    const today = new Date();
    const selectedDate = new Date(dateValue);
    const minAge = 18;
    const ageDiff = today.getFullYear() - selectedDate.getFullYear();
    const monthDiff = today.getMonth() - selectedDate.getMonth();
    const dayDiff = today.getDate() - selectedDate.getDate();
    

    if(fullnameValue === ''){
        setError(fullname, 'username is required');
    } else {
        setSuccess(fullname);
    }

    if(emailValue === '') {
        setError(email, 'Email is required');
    } else if (!isValidEmail(emailValue)) {
        setError(email, 'Provide a valid email address');
    } else {
        setSuccess(email);
    }

    if(passwordValue === ''){
        setError(password, 'password is required');
    } else if(passwordValue.length < 8){
        setError (password, 'password must be at least 8 character');
    } else {
        setSuccess(password);
    }
    

    if(!dateValue) {
        setError(date, 'date is required');
    } else if ( selectedDate > today){
        setError(date, 'date cannot be in future');
    }else if (ageDiff < minAge || (ageDiff === minAge && (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0 )))){
        setError(date, `you must be at least ${minAge} years old`);
    }else{
        setSuccess(date);
    }
}