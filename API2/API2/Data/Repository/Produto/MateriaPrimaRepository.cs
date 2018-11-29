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
//GET,PUT,POST OK
namespace api.Data.Repository.PackgeProduto
{
    
    public class MateriaPrimaRepository : Db<MateriaPrima>, IRepository<MateriaPrima>
    {
        //alter
       
        public new List<MateriaPrima> getAll()
        {
            List<MateriaPrima>listMateriaPrima=new List<MateriaPrima>();
            StringBuilder sql=new StringBuilder();

            sql.Append("SELECT Id,Descricao,CausaAlergia ");
            sql.Append("FROM MateriaPrima ");

            SqlDataReader reader = execute(sql.ToString());

            while (reader.Read())
            {
                MateriaPrima materiaPrima = new MateriaPrima();

                materiaPrima.Id = (int)reader["Id"];

                materiaPrima.descricao = reader["Descricao"].ToString();
                bool alergia = false;
                if (reader["CausaAlergia"].ToString() == "True")
                {
                   
                    alergia = true;
                    materiaPrima.causaAlergia = alergia;

                }
                else if (reader["CausaAlergia"].ToString() == "False")
                {
                    alergia = false;
                    materiaPrima.causaAlergia = alergia;
                }



                listMateriaPrima.Add(materiaPrima);
            }

            return listMateriaPrima;
        }

       
        public new MateriaPrima getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Id,Descricao,CausaAlergia ");
            sql.Append("FROM MateriaPrima ");
            sql.Append("WHERE Id = "+ id);
             MateriaPrima materiaPrima = new MateriaPrima();
            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
               
                materiaPrima.Id = (int)reader["Id"];
                materiaPrima.descricao=reader["Descricao"].ToString();
                bool alergia = false;
                if (reader["CausaAlergia"].ToString() == "True")
                {

                    alergia = true;
                    materiaPrima.causaAlergia = alergia;

                }
                else if (reader["CausaAlergia"].ToString() == "False")
                {
                    alergia = false;
                    materiaPrima.causaAlergia = alergia;
                }
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

            if (reader.Read())
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
            int alergico;
            if (entity.causaAlergia)
            {
                alergico = 1;
            }
            else
            {
                alergico = 0;
            }
            sql.Append("INSERT INTO MateriaPrima ");
            sql.Append("(Descricao,CausaAlergia) ");
            sql.Append("VALUES ('"+ entity.descricao +"',");
            sql.Append(            alergico +")");
            executeNonQuery(sql.ToString());

            return entity;
        }

        
        public new MateriaPrima update(int id, MateriaPrima entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE MateriaPrima ");
            sql.Append("SET Descricao = '" + entity.descricao + "' ,");
            int alergia = 0;
            if (entity.causaAlergia == true)
                alergia = 1;
            else if (entity.causaAlergia == false)
                alergia = 0;
            sql.Append(" CausaAlergia = " +alergia+ " ");
            sql.Append("WHERE Id = " + id);
            executeNonQuery(sql.ToString());

            return entity;
        }

        public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE MateriaPrima ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
    }
}
