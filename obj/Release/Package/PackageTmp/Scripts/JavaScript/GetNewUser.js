
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('a.confirm-link').forEach(function (link) {
        link.addEventListener('click', function (event) {
            if (!confirm("Are you sure you want to proceed with this action?")) {
                event.preventDefault();
            }
        });
    });
});
