
function TypedText(container,text) {
    let array = text.split("");
    let timer;
  
    alert(text);
  
    const frameLooper = () => {
      if (array.length > 0) {
        container.innerHTML += array.shift();
      } else {
        clearTimeout(timer);
      }
      loopTimer = setTimeout("frameLooper()", 70); /* change 70 for speed */
    }
  
    frameLooper();
  }