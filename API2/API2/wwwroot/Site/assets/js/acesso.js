
    function send()
     {
       alert("Function")
      var person = {
          name: $("#Empresa").val(),
          cnpj:$("#Cnpj").val(),
         email:$("#Email").val(),
         razaoSocial:$("#Razao").val(),
         senha:$("#Senha").val(),
         pais:$("#Pais").val(),
        estado:$("#Estado").val(),
         cidade:$("#Cidade").val(),
         endereco:$("#Endereço").val()
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
