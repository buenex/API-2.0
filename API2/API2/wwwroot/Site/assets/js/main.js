
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
  else if(a == "about")
  {
    $('html, body').animate({scrollTop:2268}, 'slow');
  }
  else if(a =="partners")
  {
    $('html, body').animate({scrollTop:3065}, 'slow');
  }
  else if(a == "services")
  {
    $('html, body').animate({scrollTop:600}, 'slow');
  }
}
var expanded = false;

function showCheckboxes() {
  var checkboxes = document.getElementById("checkboxes");
  if (!expanded) {
    checkboxes.style.display = "block";
    expanded = true;
  } else {
    checkboxes.style.display = "none";
    expanded = false;
  }
}
function logado(op,l,close)
{
  
  
  document.getElementById(l).style.display = 'none';
  document.getElementById(op).style.display = 'inline';
}
function logar(l,q,cf,cj)
{
  var logar= document.getElementById(l).style.display;
  
  if(logar != "inline")
  {
    document.getElementById(l).style.display = 'inline';
    document.getElementById(q).style.display = 'none';
    document.getElementById(cf).style.display = 'none';
    document.getElementById(cj).style.display = 'none';

  }
  else if(logar == "inline")
  {
    document.getElementById(l).style.display = 'none';
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
