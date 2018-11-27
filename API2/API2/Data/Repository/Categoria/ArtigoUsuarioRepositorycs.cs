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
    //GET ,POST, PUT DELETE OK

    public class ArtigoUsuarioRepository:Db<ArtigoUsuario>,IRepository<ArtigoUsuario>
    {
       
               
         public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE ArtigoUsuario ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }

        
        public new List<ArtigoUsuario> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<ArtigoUsuario> listaArtigoUsuario = new List<ArtigoUsuario>();

            sql.Append("SELECT C.Id,C.descricao,A.titulo as ATitulo,A.texto as ATexto,AU.dataPublicacao as AUDataPublicacao ,AU.Id as AUId");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON A.categoria = C.Id ");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON AU.artigo=A.Id ");

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
            sql.Append(" INNER JOIN Artigo A ON A.categoria = C.Id ");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON AU.artigo=A.Id ");
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

        public new ArtigoUsuario getByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            ArtigoUsuario artigoUsauario = new ArtigoUsuario ();

            sql.Append("SELECT C.Id,C.descricao,A.titulo as ATitulo,A.texto as ATexto,AU.dataPublicacao as AUDataPublicacao ,AU.Id as AUId,AU.titulo as AUTitulo");
            sql.Append(" FROM Categoria as C ");
            sql.Append(" INNER JOIN Artigo A ON A.categoria = C.Id ");
            sql.Append(" INNER JOIN ArtigoUsuario AU ON AU.artigo=A.Id ");
            sql.Append(" WHERE A.titulo = '"+ name +"'");

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
            sql.Append("(artigo, dataPublicacao)");
            sql.Append(" VALUES (");
            sql.Append(entity.artigo.Id + ",'"); 
            sql.Append(String.Format("{0:dd-MM-yyyy}",entity.dataPublicacao).ToString());
            sql.Append("')");
            executeNonQuery(sql.ToString());

            return entity;
           // throw new NotImplementedException();
        
        }

       
        public new  ArtigoUsuario  update(int id, ArtigoUsuario entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ArtigoUsuario ");
            sql.Append("SET artigo = "+ entity.artigo.Id +",");
            sql.Append("dataPublicacao = '");
            sql.Append(String.Format("{0:dd-MM-yyyy}", entity.dataPublicacao).ToString() + "' ");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
        }
    }
}