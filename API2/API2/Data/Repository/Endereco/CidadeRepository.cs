using api.Model.PackgeEndereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace api.Data.Repository.PackgeEndereco
{
    [Route ("api/cidade") ]
    public class CidadeRepository : Db<Cidade>, IRepository<Cidade>
    {
        //api/cidade
        [HttpGet]
        public new List<Cidade> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Cidade> listaCidade = new List<Cidade>();

            sql.Append("SELECT C.Id, C.Estado, E.Descricao as DescEstado, E.Sigla, ");
            sql.Append("P.Id as PaisId, P.Descricao as DescPais, C.Descricao");
            sql.Append(" FROM Cidade C");
            sql.Append(" INNER JOIN Estado E ON C.Estado = E.Id");
            sql.Append(" INNER JOIN Pais P ON E.Pais = P.Id");

            SqlDataReader reader = execute(sql.ToString());

            while  (reader.Read())
            {
                Cidade cidade = new Cidade();

                cidade.id = Convert.ToInt32(reader["id"]);
                cidade.descricao = reader["Descricao"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["DescPais"].ToString();
                
                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["Estado"]);
                estado.descricao = reader["DescEstado"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                estado.pais = pais;
                
                cidade.estado = estado;

                listaCidade.Add(cidade);
            }

            return listaCidade;
        }

         //api/cidade/1
        public new Cidade getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Cidade cidade = new Cidade();

            sql.Append("SELECT C.Id, C.Estado, E.Descricao as DescEstado, E.Sigla, ");
            sql.Append("P.Id as PaisId, P.Descricao as DescPais, C.Descricao");
            sql.Append(" FROM Cidade C");
            sql.Append(" INNER JOIN Estado E ON C.Estado = E.Id");
            sql.Append(" INNER JOIN Pais P ON E.Pais = P.Id");
            sql.Append(" WHERE C.Id = " + id);

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                cidade.id = Convert.ToInt32(reader["id"]);
                cidade.descricao = reader["Descricao"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["DescPais"].ToString();

                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["Estado"]);
                estado.descricao = reader["DescEstado"].ToString();
                estado.sigla = reader["Sigla"].ToString();
                estado.pais = pais;

                cidade.estado = estado;
            }

            return cidade;
        }

        public new Cidade getByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            Cidade cidade = new Cidade();

            sql.Append("SELECT C.Id, C.Estado, E.Descricao as DescEstado, E.Sigla, ");
            sql.Append("P.Id as PaisId, P.Descricao as DescPais, C.Descricao");
            sql.Append(" FROM Cidade C");
            sql.Append(" INNER JOIN Estado E ON C.Estado = E.Id");
            sql.Append(" INNER JOIN Pais P ON E.Pais = P.Id");
            sql.Append(" WHERE C.Descricao = '" + name +"'");

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                cidade.id = Convert.ToInt32(reader["id"]);
                cidade.descricao = reader["Descricao"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["DescPais"].ToString();

                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["Estado"]);
                estado.descricao = reader["DescEstado"].ToString();
                estado.sigla = reader["Sigla"].ToString();
                estado.pais = pais;

                cidade.estado = estado;
            }

            return cidade;
        }

        #region "MÉTODOS NÃO IMPLEMENTADOS"
        public void delete(int id)
        {
            base.delete(id);
            //StringBuilder sql = new StringBuilder();
            //sql.Append("DELETE FROM Cidade WHERE Id="+id);
            //executeNonQuery(sql.ToString());
            //throw new NotImplementedException();
        }

        public Cidade insert(Cidade entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Cidade");
            sql.Append("(Estado,Descricao)");
            sql.Append("VALUES (");
            sql.Append("'"+entity.estado+"',");
            sql.Append("'"+entity.descricao+"'");
            sql.Append(")");
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
        }

        public Cidade update(int id, Cidade entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Cidade");
            sql.Append("SET Estado = '"+ entity.estado +"',");
            sql.Append("SET Descricao = '"+ entity.descricao +"' ");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
           
        }
#endregion
    }
}
