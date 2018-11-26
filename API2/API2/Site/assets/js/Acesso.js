
    function send()
     {
       alert("Function")
      var person = {
          name: $("#Empresa").val(),
          nnpj:$("#Cnpj").val(),
         email:$("#").val(),
         razaoSocial:$("#").val(),
         senha:$("#").val(),
         pais:$("#").val(),
        estado:$("#").val(),
         cidade:$("#").val(),
         endereco:$("#").val()
      }
      $('#target').html('sending..');

      $.ajax({
          url: 'http://localhost:63569/api/juridico',
          type: 'post',
          dataType: 'json',
          contentType: 'application/json',
          success: function (data) {
              $('#target').html(data.msg);
          },
          data: JSON.stringify(person)
      });
  }
