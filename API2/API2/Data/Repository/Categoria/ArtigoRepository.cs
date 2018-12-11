using api.Model.PackageCategorias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace api.Data.Repository.PackageCategorias
{
    public class ArtigoRepository:Db<Artigo>,IRepository<Artigo>
    {
        //GET,POST,PUT DELETE OK
         public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE Artigo ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
        public new List<Artigo> getAll()
        {
           StringBuilder sql = new StringBuilder();
            List<Artigo> listaArtigo = new List<Artigo>();

            sql.Append("SELECT A.Id,A.titulo,A.texto,C.Id as catId,C.descricao as catDescricao ");
            sql.Append(" FROM Artigo  A ");
            sql.Append(" INNER JOIN Categoria C ON C.Id = A.Id");

            SqlDataReader reader = execute(sql.ToString());

             while (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["catId"]);
                categoria.descricao = reader["catDescricao"].ToString();

                Artigo artigo = new Artigo();
                artigo.titulo = reader["titulo"].ToString();
                artigo.texto = reader["texto"].ToString();
                artigo.Id = (int)reader["Id"];
                artigo.categoria = categoria;

                listaArtigo.Add(artigo);
            }

            return listaArtigo;
            
        }
            //ALTER
        public new Artigo getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Artigo artigo = new Artigo ();

            sql.Append("SELECT A.Id,A.titulo,A.texto,C.Id as catId, C.descricao as catDescricao ");
            sql.Append(" FROM Artigo as A ");
            sql.Append(" INNER JOIN Categoria C ON C.Id = A.Id");
            sql.Append(" WHERE A.Id = " + id);

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = (int)reader["catId"];
                categoria.descricao = reader["catDescricao"].ToString();

                artigo.titulo = reader["titulo"].ToString();
                artigo.texto = reader["texto"].ToString();
                artigo.Id = (int)reader["Id"];
                artigo.categoria = categoria;
            }

            return artigo;
        }

        public new Artigo getByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            Artigo artigo = new Artigo();

            sql.Append("SELECT A.Id,A.titulo,A.texto,C.Id as catId, C.descricao as catDescricao ");
            sql.Append(" FROM Artigo as A ");
            sql.Append(" INNER JOIN Categoria C ON C.Id = A.Id");
            sql.Append(" WHERE A.titulo = '" + name +"'");
            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(reader["CatId"]);
                categoria.descricao = reader["CatDescricao"].ToString();

                artigo.titulo = reader["titulo"].ToString();
                artigo.texto = reader["texto"].ToString();
                artigo.categoria = categoria;
                artigo.Id = (int)reader["Id"];
            }

            return artigo;
        }

        public new Artigo insert(Artigo entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Artigo ");
            sql.Append(" (categoria,titulo, texto) ");
            sql.Append(" VALUES (");
            sql.Append(      entity.Id + ",'");
            sql.Append(      entity.titulo + "','");
            sql.Append(      entity.texto + "'"); 
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