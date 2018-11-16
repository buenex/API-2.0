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
    public class ArtigoRepository:Db<Artigo>,IRepository<Artigo>
    {
        //ALTER
         public new void delete(int id)
        {
            base.delete(id);
        }
        //ALTER
        public new List<Artigo> getAll()
        {
           StringBuilder sql = new StringBuilder();
            List<Artigo> listaArtigo = new List<Artigo>();

            sql.Append("SELECT A.Id,A.titulo,A.texto,C.Id as catId,C.descricao as carDescricao");
            sql.Append(" FROM Artigo as A ");
            sql.Append(" INNER JOIN Artigo A ON C.Id = A.Id");

            SqlDataReader reader = execute(sql.ToString());

             if (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["C.Id"]);
                categoria.descricao = reader["C.descricao"].ToString();

                Artigo artigo = new Artigo();
                artigo.titulo = reader["A.titulo"].ToString();
                artigo.texto = reader["A.texto"].ToString();
            }

            return listaArtigo;
            
        }
            //ALTER
        public new Artigo getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Artigo artigo = new Artigo ();

            sql.Append("SELECT C.Id,C.descricao,Artigo.titulo as ATitulo,Artigo.texto as ATexto ");
            sql.Append("ArtigoUsuario.attribute9 as AUAttribute,ArtigoUsuario.dataPublicacao as AUDataPublicacao");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON C.Id = A.Id");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON A.Id=C.Id");
            sql.Append(" WHERE C.Id = " + id);

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["C.Id"]);
                categoria.descricao = reader["C.descricao"].ToString();

                artigo.titulo = reader["ATitulo"].ToString();
                artigo.texto = reader["ATexto"].ToString();
            }

            return artigo;
        }

        public new Artigo insert(Artigo entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Artigo ");
            sql.Append("(titulo, descricao)");
            sql.Append(" VALUES (");
            sql.Append(      entity.titulo + ",");
            sql.Append("'" + entity.texto + "'"); 
            sql.Append(")");
            executeNonQuery(sql.ToString());

            return entity;
        }

        Artigo IRepository<Artigo>.update(int id, Artigo entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Artigo");
            sql.Append("SET titulo = '"+ entity.titulo +"', ");
            sql.Append("SET texto = '"+ entity.texto +"' ");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
        }
    }
}