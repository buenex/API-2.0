using api.Model.PackageCategorias;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace api.Data.Repository.PackageCategorias
{
    //GET,POST,PUT DELETE OK
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
            if(reader.Read())
            categoria.id = (int)reader["Id"];
            categoria.descricao = reader["descricao"].ToString();

            sql.Clear();
            return categoria; 
        }

        public new Categoria getByName(string name)
        {
            Categoria categoria = new Categoria();

            sql.Append("SELECT Id,descricao ");
            sql.Append("FROM Categoria ");
            sql.Append("WHERE descricao='" + name+"'");

            SqlDataReader reader = execute(sql.ToString());
            if (reader.Read())
                categoria.id = (int)reader["Id"];
            categoria.descricao = reader["descricao"].ToString();

            sql.Clear();
            return categoria;
        }

        public new Categoria insert(Categoria entity)
        {
            sql.Append("INSERT INTO Categoria ");
            sql.Append("(descricao) ");
            sql.Append("VALUES (");
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