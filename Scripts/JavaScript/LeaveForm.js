document.addEventListener('DOMContentLoaded', () => {
    const startDateInput = document.getElementById('start-date');
    const endDateInput = document.getElementById('end-date');
    const daysCountInput = document.getElementById('days-count');

    function calculateDaysDifference() {
        const startDate = new Date(startDateInput.value);
        const endDate = new Date(endDateInput.value);

        if (startDate && endDate && endDate >= startDate) {
            const timeDifference = endDate - startDate;
            const daysDifference = Math.floor(timeDifference / (1000 * 60 * 60 * 24));
            daysCountInput.value = daysDifference;
        } else {
            daysCountInput.value = '';
        }
    }

    startDateInput.addEventListener('change', calculateDaysDifference);
    endDateInput.addEventListener('change', calculateDaysDifference);
});
