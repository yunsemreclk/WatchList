document.addEventListener('DOMContentLoaded', function () {
    // Theme Toggle Functionality
    const themeToggle = document.getElementById('themeToggle');
    const themeIcon = document.getElementById('themeIcon');
    const htmlElement = document.documentElement;

    // Apply saved theme or default
    // Check for system dark mode preference
    const prefersDarkMode = window.matchMedia('(prefers-color-scheme: dark)');

    // Function to check and apply initial theme
    function checkInitialTheme() {
        // First check for saved preference in localStorage
        const savedTheme = localStorage.getItem('theme');

        if (savedTheme) {
            // Use saved preference if available
            applyTheme(savedTheme);
        } else {
            // Otherwise use system preference
            const initialTheme = prefersDarkMode.matches ? 'dark' : 'light';
            applyTheme(initialTheme);
            localStorage.setItem('theme', initialTheme);
        }
    }

    (function () {
        const savedTheme = localStorage.getItem('theme');
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        const theme = savedTheme || (prefersDark ? 'dark' : 'light');
        document.documentElement.setAttribute('data-bs-theme', theme);
    })();

    // Call initial theme check
    checkInitialTheme();

    // Listen for system preference changes
    prefersDarkMode.addEventListener('change', function (e) {
        // Only apply system preference if user hasn't made a manual choice
        if (!localStorage.getItem('theme')) {
            const newTheme = e.matches ? 'dark' : 'light';
            applyTheme(newTheme);
            localStorage.setItem('theme', newTheme);
        }
    });

    // Theme toggle event listener
    themeToggle.addEventListener('click', function () {
        const currentTheme = htmlElement.getAttribute('data-bs-theme');
        const newTheme = currentTheme === 'light' ? 'dark' : 'light';
        applyTheme(newTheme);
        localStorage.setItem('theme', newTheme);
    });

    function applyTheme(theme) {
        // Set theme attribute on html element
        htmlElement.setAttribute('data-bs-theme', theme);

        if (theme === 'dark') {
            // Dark theme icon and element updates
            themeIcon.classList.replace('bi-moon', 'bi-sun');

            // Update navbar for dark theme - darker background
            const navbar = document.querySelector('.navbar');
            navbar.classList.remove('navbar-dark', 'bg-dark');
            navbar.classList.add('navbar-dark', 'bg-dark');
            navbar.style.backgroundColor = '#1a1d20';

            // Update footer for dark theme
            const footer = document.querySelector('.footer');
            if (footer) {
                footer.style.backgroundColor = '#1a1d20';
            }

            // Add transition effect for smooth theme change
            document.body.classList.add('theme-transition');
            setTimeout(() => {
                document.body.classList.remove('theme-transition');
            }, 500);
        } else {
            // Light theme icon and element updates
            themeIcon.classList.replace('bi-sun', 'bi-moon');

            // Update navbar for light theme - standard dark background
            const navbar = document.querySelector('.navbar');
            navbar.classList.remove('navbar-dark', 'bg-dark');
            navbar.classList.add('navbar-dark', 'bg-dark');
            navbar.style.backgroundColor = ''; // Reset to default

            // Update footer for light theme
            const footer = document.querySelector('.footer');
            if (footer) {
                footer.style.backgroundColor = '';
            }

            // Add transition effect for smooth theme change
            document.body.classList.add('theme-transition');
            setTimeout(() => {
                document.body.classList.remove('theme-transition');
            }, 500);
        }
    }

    // Auto-dismiss toasts after 5 seconds
    setTimeout(function () {
        $('.toast').toast('hide');
    }, 5000);

    // Scroll to top button functionality
    const scrollToTopBtn = document.getElementById('scrollToTop');

    window.addEventListener('scroll', function () {
        if (window.pageYOffset > 300) {
            scrollToTopBtn.style.display = 'block';
        } else {
            scrollToTopBtn.style.display = 'none';
        }
    });

    scrollToTopBtn.addEventListener('click', function () {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });

    // Add active class to current nav link
    const currentPath = window.location.pathname.toLowerCase();
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');

    navLinks.forEach(link => {
        const href = link.getAttribute('href');
        if (href && currentPath.includes(href.toLowerCase()) && href !== '/') {
            link.classList.add('active');
        }
    });
});

// Show loading spinner during page loads
function showLoading() {
    document.getElementById('loadingSpinner').classList.remove('d-none');
}

function hideLoading() {
    document.getElementById('loadingSpinner').classList.add('d-none');
}

// Show loading during form submissions
document.addEventListener('submit', function () {
    showLoading();
});

window.addEventListener('load', hideLoading);


