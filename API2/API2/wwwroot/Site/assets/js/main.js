$(document).ready(function(){
    $("a").on('click', function(event) {
  
     
      if (this.hash !== "") {

        event.preventDefault();
  
       
        var hash = this.hash;

        $('html, body').animate({
          scrollTop: $(hash).offset().top
        }, 800, function(){
     
        
          window.location.hash = hash;
        });
      } 
    });
  });

  function topo()
  {
    $('html, body').animate({scrollTop:0}, 'slow'); 
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

