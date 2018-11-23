using api.Model.PackgeEndereco;
using System.Collections.Generic;
using System;
using System.Text;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http;




namespace api.Data.PackgeRepository
{
    public class PaisRepository : Db<Pais>, IRepository<Pais>
    {
        
        StringBuilder sql =new StringBuilder();
        public new void delete(int id)
        {
            base.delete(id);
        }

        public new List<Pais> getAll()
        {
            List<Pais>listaPais = new List<Pais>();
            sql.Append("SELECT Id,descricao ");
            sql.Append("FROM Pais");

            SqlDataReader reader = execute(sql.ToString());
           while(reader.Read())
            {
                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["Id"]);
                pais.descricao = reader["descricao"].ToString();
                listaPais.Add(pais);
            }
            sql.Clear();
            return listaPais;
        }

        public new Pais getById(int id)
        {
            Pais pais = new Pais();
            sql.Append("SELECT descricao ");
            sql.Append("FROM Pais ");
            sql.Append("WHERE Id = "+id.ToString());

            SqlDataReader reader = execute(sql.ToString());
            if(reader.Read())
            {                
                pais.Id=id;
                pais.descricao = reader["descricao"].ToString();
                sql.Clear();
                //Console.WriteLine("pegou pais");               
            }
            return pais;
            //return pais;
        }

        public new Pais getByName(string name)
        {
            Pais pais = new Pais();
            sql.Append("SELECT Id,descricao ");
            sql.Append("FROM Pais ");
            sql.Append("WHERE descricao = '" +name.ToString()+"'");

            SqlDataReader reader = execute(sql.ToString());
            if (reader.Read())
            {
                pais.Id = (int)reader["Id"];
                pais.descricao = reader["descricao"].ToString();
                sql.Clear();
                Console.WriteLine("pegou pais");               
            }
            return pais;
            //return pais;
        }
        public new Pais insert(Pais pais)
        {
            return base.insert(pais);
        }

        Pais IRepository<Pais>.update(int id, Pais entity)
        {
            return base.update(id, entity);
        }
    }
}
