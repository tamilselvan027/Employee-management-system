document.addEventListener('DOMContentLoaded', () => {
    const startDateInput = document.getElementById('start-date');
    const endDateInput = document.getElementById('end-date');
    const daysCountInput = document.getElementById('days-count');

    function calculateDaysDifference() {
        const startDate = new Date(startDateInput.value);
        const endDate = new Date(endDateInput.value);
        //console.log(endDate);
        //console.log(startDate);
        if (startDate && endDate && endDate >= startDate) {
            const timeDifference = endDate - startDate;
           
            //console.log(timeDifference);
            // Add 1 to include both the start and end date:
            const daysDifference = Math.ceil(timeDifference / (1000 * 60 * 60 * 24)) + 1;
            daysCountInput.value = daysDifference;
        } else {
            daysCountInput.value = '';
        }
    }

    startDateInput.addEventListener('change', calculateDaysDifference);
    endDateInput.addEventListener('change', calculateDaysDifference);
});

$(document).ready(function () {
    console.log('test2');

    function validateLeaveType() {
        const leaveType = $('#leave-type').val();
        if (leaveType === '') {
            $('#leavetype').text('Please select leave type').css('color', 'red');
            $('#leave-type').css('border', '1px solid red');
            return false;
        } else {
            $('#leavetype').text('');
            $('#leave-type').css('border', '1px solid green');
            return true;
        }
    }

    function validateStartdate() {
        const startDate = $('#start-date').val();
        if (startDate == '') {
            $('#start').text('Please select date').css('color', 'red');
            $('#start-date').css('border', '1px solid red');
            return false;
        } else {
            $('#start').text('');
            $('#start-date').css('border', '1px solid green');
            return true;
        }
    }

    function validateEnddate() {
        const endDate = $('#end-date').val();
        if (endDate == '') {
            $('#end').text('Please select date').css('color', 'red');
            $('#end-date').css('border', '1px solid red');
            return false;
        } else {
            $('#end').text('');
            $('#end-date').css('border', '1px solid green');
            return true;
        }
    }
    //function validateReason() {
    //    const reason = $('#reason').val();
    //    if (reason == '') {
    //        $('#reason').text('Please enter').css('color', 'red');
    //        $('#reason').css('border', '1px solid red');
    //        return false;
    //    } else {
    //        $('#reason').text('');
    //        $('#reason').css('border', '1px solid green');
    //        return true;
    //    }
    //}

    $('#leave-type').focusout(validateLeaveType);
    $('#start-date').focusout(validateStartdate);
    $('#end-date').focusout(validateEnddate);
    //$('#reason').focusout(validateReason);

    $('#submitbutton').click(function (e) {
        e.preventDefault();

        var IsvalidateLeaveType = validateLeaveType();
        var IsvalidateStartdate = validateStartdate();
        var IsvalidateEnddate = validateEnddate();
        //var IsvalidateReason = validateReason();


        if (IsvalidateLeaveType && IsvalidateStartdate && IsvalidateEnddate ) {
            $('#loginForm').submit();
        } else {
            return false;
            console.log("test");
        }
    })
});