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
    public class CategoriaRepository:Db<Categoria>,IRepository<Categoria>
    {
         StringBuilder sql = new StringBuilder();
            
         public new void delete(int id)
        {
            sql.Append("DELETE Categoria ");
            sql.Append("WHERE Id="+id);

            executeNonQuery(sql.ToString());
        }

        public new List<Categoria> getAll(int id)
        {
            List<Categoria>categorias=new List<Categoria>();
            sql.Append("SELECT descricao ");
            sql.Append("FROM Categoria");

            SqlDataReader reader = execute(sql.ToString());
            while(reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.descricao = reader["descricao"].ToString();
                categorias.Add(categoria);
            }
            sql.Clear();   
            return categorias;            
        }

        public new Categoria getById(int id)
        {
            Categoria categoria = new Categoria();

            sql.Append("SELECT Id,descricao ");
            sql.Append("FROM Categoria ");
            sql.Append("WHERE Id="+id);

            SqlDataReader reader = execute(sql.ToString());

            categoria.id = Convert.ToInt32(reader["Id"]);
            categoria.descricao = reader["descricao"].ToString();

            sql.Clear();
            return categoria; 
        }

        public new Categoria insert(Categoria entity)
        {
            sql.Append("INSERT INTO Categoria ");
            sql.Append("(Id,descricao) ");
            sql.Append("VALUES (");
            sql.Append(     entity.id+",");
            sql.Append("'"+ entity.descricao+"'");
            sql.Append(")");

            executeNonQuery(sql.ToString());
            sql.Clear();
            return entity;
        }

        Categoria IRepository<Categoria>.update(int id, Categoria entity)
        {
            sql.Append("UPDATE Categoria ");
            sql.Append("SET descricao ='"+entity.descricao+"' ");
            sql.Append("WHERE Id = "+entity.id);

            executeNonQuery(sql.ToString());
            sql.Clear();
            return base.update(id, entity);
        }
    }
}