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
  let bg = document.getElementsByClassName('bg-light');
  let txt = document.getElementsByClassName('text-dark');
  let icons = document.getElementsByTagName("i");

  console.log(bg);

  for (let i = 0; i < bg.length;i++){
    bg[i].classList.replace('bg-light', 'bg-dark');
  }
  for (let i = 0; i < txt.length;i++){
   txt[i].classList.replace('text-dark','text-light');
  }

  for (let i = 0; i < icons.length; i++) {
    if (icons[i].classList.contains('text-dark'))
      icons[i].classList.replace('text-dark', 'text-light');
  }

  console.log(bg);
}

if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
  changeToDarkMode();
}