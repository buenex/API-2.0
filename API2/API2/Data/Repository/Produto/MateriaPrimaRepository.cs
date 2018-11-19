using api.Model.PackgeProduto;
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

namespace api.Data.Repository.PackgeProduto
{
    
    public class MateriaPrimaRepository : Db<MateriaPrima>, IRepository<MateriaPrima>
    {
        //alter
       
        public new List<MateriaPrima> getAll()
        {
            List<MateriaPrima>listMateriaPrima=new List<MateriaPrima>();
            StringBuilder sql=new StringBuilder();

            sql.Append("SELECT Id,Descricao ");
            sql.Append("FROM MateriaPrima ");

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                MateriaPrima materiaPrima = new MateriaPrima();

                materiaPrima.Id = (int)reader["Id"];
                materiaPrima.descricao = reader["Descricao"].ToString();

                listMateriaPrima.Add(materiaPrima);
            }

            return listMateriaPrima;
        }

       
        public new MateriaPrima getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Id,Descricao ");
            sql.Append("FROM MateriaPrima ");
            sql.Append("WHERE Id = "+ id);
             MateriaPrima materiaPrima = new MateriaPrima();
            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
               
                materiaPrima.Id = (int)reader["Id"];
                materiaPrima.descricao=reader["Descricao"].ToString();
            }
            return materiaPrima;
        }

      
        public List<MateriaPrima> getByAlergico(Boolean alergico)
        {
            List<MateriaPrima> materias = new List<MateriaPrima>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, Descricao, CausaAlergia");
            sql.Append(" FROM MateriaPrima");
            if (alergico)
            {
                sql.Append(" WHERE CausaAlergia = 1");
            }
            else
            {
                sql.Append(" WHERE CausaAlergia = 0");
            }
            SqlDataReader reader = execute(sql.ToString());

            while (reader.Read())
            {
                MateriaPrima materia = new MateriaPrima();
                materia.Id = Convert.ToInt32(reader["Id"].ToString());
                materia.descricao = reader["Descricao"].ToString();
                materia.causaAlergia = Convert.ToBoolean( reader["CausaAlergia"].ToString());
                materias.Add(materia);
            }

            return materias;
        }

       
        public new MateriaPrima insert(MateriaPrima entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO MateriaPrima ");
            sql.Append("id,Descricao,CausaAlergia ");
            sql.Append("VALUES ("+ entity.Id +",");
            sql.Append(            entity.descricao +",");
            sql.Append(            entity.causaAlergia +")");

            return entity;
        }

        
        public new MateriaPrima update(int id, MateriaPrima entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE MateriaPrima ");
            sql.Append("SET Descricao = " + entity.Id.ToString() + " ");
            sql.Append("SET CausaAlergia = " + entity.causaAlergia.ToString() + " ");
            sql.Append("WHERE Id = " + id);

            return entity;
        }

        public new void delete(int id)
        {
            base.delete(id);
        }
    }
}
