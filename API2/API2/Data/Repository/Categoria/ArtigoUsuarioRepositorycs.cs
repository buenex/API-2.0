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
    
    public class ArtigoUsuarioRepository:Db<ArtigoUsuario>,IRepository<ArtigoUsuario>
    {
       
               
         public new void delete(int id)
        {
            base.delete(id);
        }

        
        public new List<ArtigoUsuario> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<ArtigoUsuario> listaArtigoUsuario = new List<ArtigoUsuario>();

            sql.Append("SELECT C.Id,C.descricao,A.titulo as ATitulo,A.texto as ATexto,AU.dataPublicacao as AUDataPublicacao ,AU.Id as AUId");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON A.Id = C.Id ");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON AU.Id=A.Id ");

            SqlDataReader reader = execute(sql.ToString());

             while (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["Id"]);
                categoria.descricao = reader["descricao"].ToString();

                Artigo artigo = new Artigo();
                artigo.titulo = reader["ATitulo"].ToString();
                artigo.texto = reader["ATexto"].ToString();
                artigo.categoria = categoria;

                ArtigoUsuario artigoUsauario = new ArtigoUsuario();
                artigoUsauario.dataPublicacao = Convert.ToDateTime(reader["AUDataPublicacao"]);
                artigoUsauario.Id = (int)reader["AUId"];
                artigoUsauario.artigo = artigo;
                listaArtigoUsuario.Add(artigoUsauario);
            }

            return listaArtigoUsuario;
            
        }

       
        public new ArtigoUsuario getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            ArtigoUsuario artigoUsauario = new ArtigoUsuario ();

            sql.Append("SELECT C.Id,C.descricao,A.titulo as ATitulo,A.texto as ATexto,AU.dataPublicacao as AUDataPublicacao ,AU.Id as AUId");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON A.Id = C.Id ");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON AU.Id=A.Id ");
            sql.Append(" WHERE C.Id = "+id);

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["Id"]);
                categoria.descricao = reader["descricao"].ToString();

                Artigo artigo = new Artigo();
                artigo.titulo = reader["ATitulo"].ToString();
                artigo.texto = reader["ATexto"].ToString();
                artigo.categoria = categoria;

                artigoUsauario.dataPublicacao = Convert.ToDateTime(reader["AUDataPublicacao"]);
                artigoUsauario.Id = (int)reader["AUId"];
                artigoUsauario.artigo = artigo;
            }

            return artigoUsauario;
        }

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
       
        ArtigoUsuario IRepository<ArtigoUsuario>.update(int id, ArtigoUsuario entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ArtigoUsuario");
            sql.Append("SET artigo = '"+ entity.artigo +"',");
            sql.Append("SET dataPublicacao = '"+ entity.dataPublicacao +"' ");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
        }
    }
}