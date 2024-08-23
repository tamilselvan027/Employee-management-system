const form = document.getElementById('form');
const fname = document.getElementById('fname');
const mname = document.getElementById('mname');
const lname = document.getElementById('lname');
const date = document.getElementById('date');
const stdid = document.getElementById('col-2a');
const address = document.getElementById('address');
const city = document.getElementById('city');
const state = document.getElementById('state');
const country = document.getElementById('country');
const zipcode = document.getElementById('zipcode');
const email = document.getElementById('email');
const empty = document.getElementById('empty');

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
    const fnameValue = fname.value.trim();
    const mnameValue = mname.value.trim();
    const lnameValue = lname.value.trim();
    const dateValue = date.value;
    const stuidValue = stdid.value.trim();
    const addressValue = address.value.trim();
    const cityValue = city.value.trim();
    const stateValue = state.value.trim();
    const countryValue = country.value.trim();
    const zipcodeValue = zipcode.value.trim();
    const emailValue = email.value.trim();
    const emptyValue = empty.value.trim();


    // this for date validation
    const today = new Date();
    const selectedDate = new Date(dateValue);
    const minAge = 18;
    const ageDiff = today.getFullYear() - selectedDate.getFullYear();
    const monthDiff = today.getMonth() - selectedDate.getMonth();
    const dayDiff = today.getDate() - selectedDate.getDate();
    

    // added first,middle,last name error message
    if(fnameValue === ''){
        setError(fname, 'Firstname is required');
    } else {
        setSuccess(fname);
    }

    if(mnameValue === ''){
        setError(mname, 'Middlename is required');
    } else {
        setSuccess(fname);
    }
    
    if(lnameValue === ''){
        setError(lname, 'Lastname is required');
    } else {
        setSuccess(fname);
    }

    // added email validation
    if(emailValue === '') {
        setError(email, 'Email is required');
    } else if (!isValidEmail(emailValue)) {
        setError(email, 'Provide a valid email address');
    } else {
        setSuccess(email);
    }
    
    // added date validation
    if(!dateValue) {
        setError(date, 'Date of birth is required');
    } else if ( selectedDate > today){
        setError(date, 'date of birth cannot be in future');
    }else if (ageDiff < minAge || (ageDiff === minAge && (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0 )))){
        setError(date, `you must be at least ${minAge} years old`);
    }else{
        setSuccess(date);
    }

    // added student id validation
    if(!stuidValue){
        setError(stdid, 'Student ID is required');
    } else if (stuidValue.length < 8){
        setError(stdid, 'Student ID must be to 8 numbers');
    } else{
        setSuccess(stdid);
    }
    // else if (!/^\d+$/.test(stdid)){
    //     setError(stdid, 'Student ID must be numberic');
    // }

    // added address validation
    if(!addressValue){
        setError(address, 'Address is required');
    } else {
        setSuccess(address);
    }
    // added city validation
    if(cityValue === ''){
        setError(city, 'Cityname is required');
    } else {
        setSuccess(city);
    }
    // added state validation
    if(!stateValue){
        setError(state, 'Statename is required');
    } else {
        setSuccess(state);
    }
    // added Countryname validation
    if(countryValue === ''){
        setError(country, 'Countryname is required');
    } else {
        setSuccess(country);
    }
    // added zipcode validation
    if(!zipcodeValue){
        setError(zipcode, 'zipcode is required');
    }else if (zipcodeValue.length !== 6 ){
        setError(zipcode, 'Please enter valid zipcode')
    } else {
        setSuccess(zipcode);
    }

    if(!emptyValue){
        setError(empty, 'Name is required');
    } else {
        setSuccess(empty);
    }
}