//$(document).ready(function(){
   // $("a").on('click', function(event) {
  
     
    //  if (this.hash !== "") {

      //  event.preventDefault();
  
       
      //  var hash = this.hash;

      //  $('html, body').animate({
     //    scrollTop: $(hash).offset().top
      //  }, 800, function(){
     //
        
        //  window.location.hash = hash;
       // });
    //  } 
  // });
  // });

function scrollbar(b)
{
  a = b;
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
    $('html, body').animate({scrollTop:2150}, 'slow');
  }
  else if(a =="partners")
  {
    $('html, body').animate({scrollTop:3000}, 'slow');
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

