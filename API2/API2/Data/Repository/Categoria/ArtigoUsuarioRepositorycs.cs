using api.Model.PackageCategorias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace api.Data.Repository.PackageCategorias
{
    [Route("api/ArtigoUsuario")]
    public class ArtigoUsuarioRepository:Db<ArtigoUsuario>,IRepository<ArtigoUsuario>
    {
        //alter
               
         public new void delete(int id)
        {
            base.delete(id);
        }

        //api/ArtigoUsuario
        [HttpGet] 
        public new List<ArtigoUsuario> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<ArtigoUsuario> listaArtigoUsuario = new List<ArtigoUsuario>();

            sql.Append(" SELECT C.Id,C.descricao,Artigo.titulo as ATitulo,Artigo.texto as ATexto ");
            sql.Append(" ,ArtigoUsuario.dataPublicacao as AUDataPublicacao ");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON C.Id = A.Id ");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON A.Id=C.Id ");

            SqlDataReader reader = execute(sql.ToString());

             if (reader.Read())
            {
                ArtigoUsuario artigoUsauario = new ArtigoUsuario ();
                artigoUsauario.dataPublicacao = Convert.ToDateTime(reader["AUDataPublicacao"]);

                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["C.Id"]);
                categoria.descricao = reader["C.descricao"].ToString();

                Artigo artigo = new Artigo();
                artigo.titulo = reader["ATitulo"].ToString();
                artigo.texto = reader["ATexto"].ToString();
            }

            return listaArtigoUsuario;
            
        }

        //api/ArtigoUsuario/getbyArtigoUsuario
        [HttpGet("getbyArtigoUsuario")] 
        public new ArtigoUsuario getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            ArtigoUsuario artigoUsauario = new ArtigoUsuario ();

            sql.Append("SELECT C.Id,C.descricao,Artigo.titulo as ATitulo,Artigo.texto as ATexto ");
            sql.Append(",ArtigoUsuario.dataPublicacao as AUDataPublicacao");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON C.Id = A.Id");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON A.Id=C.Id");
            sql.Append(" WHERE C.Id = " + id);

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                artigoUsauario.dataPublicacao = Convert.ToDateTime(reader["AUDataPublicacao"]);

                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["C.Id"]);
                categoria.descricao = reader["C.descricao"].ToString();

                Artigo artigo = new Artigo();
                artigo.titulo = reader["ATitulo"].ToString();
                artigo.texto = reader["ATexto"].ToString();
            }

            return artigoUsauario;
        }

        //api/ArtigoUsuario/postArtigoUsuario
        [HttpPost("postArtigoUsuario")] 
        public new ArtigoUsuario insert(ArtigoUsuario entity)
        {
          StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ArtigoUsuario ");
            sql.Append("(Id, artigo, dataPublicacao)");
            sql.Append(" VALUES (");
            sql.Append(      entity.Id + ","); 
            sql.Append("'" + entity.artigo + "',"); 
            sql.Append("'" + entity.dataPublicacao + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString());

            return entity;
           // throw new NotImplementedException();
        
        }

        //api/ArtigoUsuario/putArtigoUsuario
        [HttpPut("putArtigoUsuario")] 
        ArtigoUsuario IRepository<ArtigoUsuario>.update(int id, ArtigoUsuario entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ArtigoUsuario");
            sql.Append("SET fk_Artigo = '"+ entity.artigo +"',");
            sql.Append("SET dataPublicacao = '"+ entity.dataPublicacao +"' ");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
        }
    }
}