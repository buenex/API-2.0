
function scrollbar(a)
{
  if(a == "blog")
  {
    $('html, body').animate({scrollTop:1500}, 'slow');
  }
  else if(a == "home")
  {
    $('html, body').animate({scrollTop:0}, 'slow'); 
  }
  else if(a== "about")
  {
    $('html, body').animate({scrollTop:2268}, 'slow');
  }
  else if(a =="partners")
  {
    $('html, body').animate({scrollTop:3065}, 'slow');
  }
  else if(a=="services")
  {
    $('html, body').animate({scrollTop:600}, 'slow');
  }
}

  
function openclose(el)
 {
  var display = document.getElementById(el).style.display;

  if(display != "inline")
  {
      document.getElementById(el).style.display = 'inline';
  }
  else if(display == "inline")
  {
  
      document.getElementById(el).style.display = 'none';
  }
}

