function changeToDarkMode() {
  let bg = document.getElementsByClassName("bg-light");
  let txt = document.getElementsByClassName("text-dark");
  let navs = document.getElementsByTagName("nav");
  let icons = document.getElementsByTagName("i");

  for (let i = 0; i < bg.length; i++) {
    bg[i].classList.replace("bg-light", "bg-dark");
  }

  for (let i = 0; i < txt.length; i++) {
    txt[i].classList.replace("text-dark", "text-light");
  }
  for (let i = 0; i < icons.length; i++) {
    if (icons[i].classList.contains("text-dark"))
      icons[i].classList.replace("text-dark", "text-light");
  }

  for (let i = 0; i < navs.length; i++) {
    if (navs[i].classList.contains("bg-light"))
      navs[i].classList.replace("bg-light", "bg-dark");
  }
}

if (window.matchMedia("(prefers-color-scheme: dark)").matches) {
  changeToDarkMode();
}
