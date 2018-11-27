function showHint(str) {
   
    if (str.length == 0) { 
        alert("vazio");
        document.getElementById("txtHint").innerHTML = "";
        return;
    } else {
        var xmlhttp = new XMLHttpRequest();
        try{
            
            xmlhttp.open("GET", "http://localhost:63569/api/pais/1", true);
            
            alert("Passou")
        }
        catch
        {
            alert("Deu RUim");
        }
        try
        {
        xmlhttp.send();
        alert("enviando")

        }
        catch
        {

        }
        xmlhttp.onreadystatechange = function() 
        {
            alert("entrou;");
            //&& this.status == 404
            if (this.readyState == 4 && this.status == 200) {
               alert("cheio  error number: "+ this.responseText.toString());
                document.getElementById("txtHint").innerHTML = this.responseText;
            }
            else
            {
                alert("erro ok ? "+this.status.toString());
            }
        };
        
    }
}
function mostrar(el)
{
  
    document.getElementById(el).style.display ='inline'
}
function ocultar(el)
{
    document.getElementById(el).style.display ='none'
}