using api.Model.PackgeEndereco;
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

namespace api.Data.Repository.PackgeEndereco
{
    public class EstadoRepository : Db<Estado>, IRepository<Estado>
    {
        //api/estado
        [HttpGet]
        public new List<Estado> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Estado> listaEstado = new List<Estado>();

            sql.Append("SELECT E.Id, E.Pais, E.Descricao, E.Sigla,");
            sql.Append(" P.Id as PaisId, P.Descricao as PDescricao");
            sql.Append(" FROM Estado E");
            sql.Append(" INNER JOIN Pais P");
            sql.Append(" ON E.Pais = P.Id");
            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["Id"]);
                estado.descricao = reader["Descricao"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["PDescricao"].ToString();
                estado.pais = pais;

                listaEstado.Add(estado);
            }

            return listaEstado;
        }

        public new Estado getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Estado estado = new Estado();

            sql.Append("SELECT E.Id, E.Pais, E.Descricao, E.Sigla,");
            sql.Append(" P.Id as PaisId, P.Descricao as PDescricao");
            sql.Append(" FROM Estado E");
            sql.Append(" INNER JOIN Pais P");
            sql.Append(" ON E.Pais = P.Id");
            sql.Append(" WHERE E.id = " + id);

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                estado.Id = Convert.ToInt32(reader["Id"]);
                estado.descricao = reader["Descricao"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["PDescricao"].ToString();
                estado.pais = pais;
            }

            return estado;
        }

          public new Estado getByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            Estado estado = new Estado();

            sql.Append("SELECT E.Id, E.Pais, E.Descricao, E.Sigla,");
            sql.Append(" P.Id as PaisId, P.Descricao as PDescricao");
            sql.Append(" FROM Estado E");
            sql.Append(" INNER JOIN Pais P");
            sql.Append(" ON E.Pais = P.Id");
            sql.Append(" WHERE E.Descricao = '"+name+"'");

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                estado.Id = Convert.ToInt32(reader["Id"]);
                estado.descricao = reader["Descricao"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["PDescricao"].ToString();
                estado.pais = pais;
            }

            return estado;
        }


        #region "MÉTODOS NÃO IMPLEMENTADOS"

        public new void delete(int id)
        {
            base.delete(id);
            //StringBuilder sql = new StringBuilder();
            //sql.Append("DELETE FROM Estado WHERE Id="+id);
            //executeNonQuery(sql.ToString());
            //throw new NotImplementedException();
        }

        public new Estado insert(Estado entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Estado ");
            sql.Append("(Pais, Descricao, Sigla)");
            sql.Append(" VALUES (");
            sql.Append(      entity.pais + ",");
            sql.Append("'" + entity.descricao + "',"); 
            sql.Append("'" + entity.sigla + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString());

            return entity;
            throw new NotImplementedException();
        }

        public new Estado update(int id, Estado entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Estado");
            sql.Append("SET Pais = '"+ entity.pais +"',");
            sql.Append("SET Sigla = '"+ entity.sigla +"',");
            sql.Append("SET Descricao = '"+ entity.descricao +"'");
            sql.Append("WHERE Id = "+ id);
            executeNonQuery(sql.ToString());
            //throw new NotImplementedException();
            return entity;
        }
        #endregion

    }
}
