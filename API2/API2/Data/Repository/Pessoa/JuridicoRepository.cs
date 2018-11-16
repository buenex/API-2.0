using api.Model.PackgePessoa;
using api.Data.Repository.PackgeEndereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace api.Data.Repository.PackgePessoa
{
    [Route("api/juridico")]
    public class JuridicoRepository : Db<Juridico>, IRepository<Juridico>
    {
        //api/juridico
        [HttpGet]
        public List<Juridico> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Juridico> listaJuridico = new List<Juridico>();

            sql.Append("SELECT P.Id as PessoaId, P.Nome, P.Endereco,");
            sql.Append(" J.dataNascimento, J.email, J.senha");
            sql.Append(" FROM Juridico J");
            sql.Append(" INNER JOIN Pessoa P ON J.Pessoa = P.Id");

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                Juridico Juridico = new Juridico();

                Juridico.Id = Convert.ToInt32(reader["PessoaId"]);
                Juridico.razaoSocial = reader["razaoSocial"].ToString();
                Juridico.cnpj = reader["cnpj"].ToString();
                Juridico.senha = reader["senha"].ToString();
                Juridico.nome = reader["nome"].ToString();
                
                EnderecoRepository endRepo = new EnderecoRepository();

                Juridico.endereco = endRepo.getById(Convert.ToInt32(reader["endereco"]));

                listaJuridico.Add(Juridico);
            }

            return listaJuridico;
            //throw new NotImplementedException();
        }

        //api/juridico/getbyJuridico
        [HttpGet("getbyJuridico")]
        public Juridico getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Juridico Juridico = new Juridico();

            sql.Append("SELECT P.Id as PessoaId, P.Nome, P.Endereco,");
            sql.Append(" J.dataNascimento, J.email, J.senha");
            sql.Append(" FROM Juridico J");
            sql.Append(" INNER JOIN Pessoa P ON J.Pessoa = P.Id");
            sql.Append(" WHERE P.Id = " + id);

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                Juridico.Id = Convert.ToInt32(reader["PessoaId"]);
                Juridico.razaoSocial = reader["razaoSocial"].ToString();
                Juridico.cnpj = reader["cnpj"].ToString();
                Juridico.senha = reader["senha"].ToString();
                Juridico.nome = reader["nome"].ToString();

                EnderecoRepository endRepo = new EnderecoRepository();

                Juridico.endereco = endRepo.getById(Convert.ToInt32(reader["endereco"]));
            }

            return Juridico;
            //throw new NotImplementedException();
        }
        //api/postJuridico
        [HttpPost ("postJuridico")]
        public Juridico insert(Juridico entity)
        {
            StringBuilder sql = new StringBuilder();
            int id;

            sql.Append("INSERT INTO Pessoa (nome,dataCadastro,endereco)");
            sql.Append(" VALUES (");
            sql.Append("'" + entity.nome + "',");
            sql.Append("'" + entity.dataCadastro.ToString("MM/dd/yyyy") + "',");
            sql.Append("'" + entity.endereco.Id + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString(), out id) ;

            entity.Id = id;

            sql.Clear();
            sql.Append("INSERT INTO Juridico ");
            sql.Append("(razaoSocial,cnpj, senha)");
            sql.Append(" VALUES (");
            sql.Append("'" + entity.razaoSocial + "',");
            sql.Append("'" + entity.cnpj + "',");
            sql.Append("'" + entity.senha + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString());

            return entity;
            //throw new NotImplementedException();
        }
        
        //api/juridico/putJuridico
        [HttpPut("putJuridico")]
        public Juridico update(int id, Juridico entity)
        {
             StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Pessoa");
            sql.Append("SET Nome = '"+entity.nome+"',");
            sql.Append("SET dataCadastro = '"+entity.dataCadastro.ToString("MM/dd/yyyy")+"',");
            sql.Append("SET endereco = '"+entity.endereco+"'");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());

            sql.Clear();

            sql.Append("UPDATE Juridico");
            sql.Append("SET razaoSocial = '"+ entity.razaoSocial+"',");
            sql.Append("SET cnpj = '"+ entity.cnpj+"',");
            sql.Append("SET senha = '"+ entity.senha+"',");
            sql.Append("WHERE Id = "+id);
            executeNonQuery(sql.ToString());
            return entity;
            //throw new NotImplementedException();
        }

        public void delete(int id)
        {
            base.delete(id);
        }
    }
}
