using api.Data.Repository.PackgeEndereco;
using api.Model.PackgePessoa;
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


//GET, POST, PUT, DELETE OK
namespace api.Data.Repository.PackgePessoa
{
    public class FisicoRepository : Db<Fisico>, IRepository<Fisico>
    {

        public new List<Fisico> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Fisico> listaFisico = new List<Fisico>();

            sql.Append("SELECT P.Id as PessoaId, P.Nome, P.Endereco,");
            sql.Append(" F.dataNascimento, F.email, F.senha");
            sql.Append(" FROM Fisico F");
            sql.Append(" INNER JOIN Pessoa P ON F.Pessoa = P.Id");

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                Fisico fisico = new Fisico();

                fisico.Id = Convert.ToInt32(reader["PessoaId"]);
                fisico.dataCadastro = (DateTime)reader["dataNascimento"];
                fisico.email = reader["email"].ToString();
                fisico.senha = reader["senha"].ToString();
                fisico.nome = reader["nome"].ToString();
                
                EnderecoRepository endRepo = new EnderecoRepository();

                fisico.endereco = endRepo.getById(Convert.ToInt32(reader["endereco"]));

                listaFisico.Add(fisico);
            }

            return listaFisico;
        }
        public new Fisico getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Fisico fisico = new Fisico();

            sql.Append("SELECT P.Id as PessoaId, P.Nome, P.Endereco,");
            sql.Append(" F.dataNascimento, F.email, F.senha,F.Id");
            sql.Append(" FROM Fisico F");
            sql.Append(" INNER JOIN Pessoa P ON F.Pessoa = P.Id");
            sql.Append(" WHERE F.Id = " + id);

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                fisico.Id = Convert.ToInt32(reader["PessoaId"]);
                fisico.dataCadastro = (DateTime)reader["dataNascimento"];
                fisico.email = reader["email"].ToString();
                fisico.senha = reader["senha"].ToString();
                fisico.nome = reader["nome"].ToString();

                EnderecoRepository endRepo = new EnderecoRepository();

                fisico.endereco = endRepo.getById(Convert.ToInt32(reader["endereco"]));
            }

            return fisico;
        }

         public new Fisico getByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            Fisico fisico = new Fisico();

            sql.Append("SELECT P.Id as PessoaId, P.Nome, P.Endereco,");
            sql.Append(" F.dataNascimento, F.email, F.senha");
            sql.Append(" FROM Fisico F");
            sql.Append(" INNER JOIN Pessoa P ON F.Pessoa = P.Id");
            sql.Append(" WHERE P.Nome = '" + name +"'");

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                fisico.Id = Convert.ToInt32(reader["PessoaId"]);
                fisico.dataCadastro = (DateTime)reader["dataNascimento"];
                fisico.email = reader["email"].ToString();
                fisico.senha = reader["senha"].ToString();
                fisico.nome = reader["nome"].ToString();

                EnderecoRepository endRepo = new EnderecoRepository();

                fisico.endereco = endRepo.getById(Convert.ToInt32(reader["endereco"]));
            }

            return fisico;
        }

        public new Fisico insert(Fisico entity)
        {
           
            StringBuilder sql = new StringBuilder();
            int id;

            sql.Append("INSERT INTO Pessoa (Nome, Endereco)");
            sql.Append(" VALUES (");
            sql.Append("'" + entity.nome + "',");
            sql.Append("'" + entity.endereco.Id + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString(), out id) ;
            entity.Id = id;

            sql.Clear();
            sql.Append("INSERT INTO Fisico ");
            sql.Append("(Pessoa, dataNascimento, email, senha)");
            sql.Append(" VALUES (");
            sql.Append(      entity.Id + ",");
            sql.Append("'" + entity.dataNascimento.ToString("MM/dd/yyyy") + "',"); 
            sql.Append("'" + entity.email + "',");
            sql.Append("'" + entity.senha + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString());

            return entity;
        }

        public Fisico update(int id, Fisico entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Pessoa ");
            sql.Append("SET Nome = '"+entity.nome+"',");
            sql.Append("    Endereco ="+entity.endereco.Id+"");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());

            sql.Clear();

            sql.Append("UPDATE Fisico ");
            sql.Append("SET email = '"+ entity.email+"',");
            sql.Append(" senha = '"+ entity.senha+"',");
            sql.Append(" dataNascimento = '"+ entity.dataNascimento.ToString("MM/dd/yyyy") +"' ");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
        }

        public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE Fisico ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
    }
}
