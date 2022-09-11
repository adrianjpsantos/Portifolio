// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let tooltipTriggerList = [].slice.call(
  document.querySelectorAll('[data-bs-toggle="tooltip"]')
);
let tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
  return new bootstrap.Tooltip(tooltipTriggerEl);
});

function changeToDarkMode() {
  let elementsLight = document.getElementsByClassName('bg-light');
  let elementsDark = document.getElementsByClassName('bg-light');
  let elementsTextDark = document.getElementsByClassName('text-dark');
  let elementsTextLight = document.getElementsByClassName('text-light');


  for (let i = 0; i < elementsLight.length; i++){
    elementsLight[i].classList.replace('bg-light', 'bg-dark');
  }
  for (let i = 0; i < elementsDark.length; i++){
    elementsDark[i].classList.replace('bg-dark', 'bg-light');
  }
  
  for (let i = 0; i < elementsTextDark.length; i++){
    elementsTextDark[i].classList.replace('text-dark', 'text-light');
  }

  for (let i = 0; i < elementsTextLight.length; i++){
    elementsTextLight[i].classList.replace('text-light', 'text-dark');
  }
}

if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
  changeToDarkMode();
}