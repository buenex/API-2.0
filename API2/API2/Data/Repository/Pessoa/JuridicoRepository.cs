using api.Model.PackgePessoa;
using api.Data.Repository.PackgeEndereco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

// GET, POST, PUT, DELETE

namespace api.Data.Repository.PackgePessoa
{
    public class JuridicoRepository : Db<Juridico>, IRepository<Juridico>
    {
        public List<Juridico> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Juridico> listaJuridico = new List<Juridico>();

            sql.Append("SELECT P.Id as PessoaId, P.Nome as PName, P.Endereco as PEndereco,");
            sql.Append(" J.cnpj, J.email, J.senha,J.razaoSocial");
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
                Juridico.nome = reader["PName"].ToString();
                
                EnderecoRepository endRepo = new EnderecoRepository();

                Juridico.endereco = endRepo.getById(Convert.ToInt32(reader["PEndereco"]));

                listaJuridico.Add(Juridico);
            }

            return listaJuridico;
        }

        public Juridico getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Juridico Juridico = new Juridico();

            sql.Append("SELECT P.Id as PessoaId, P.Nome, P.Endereco,");
            sql.Append(" J.cnpj, J.email, J.senha, J.razaoSocial");
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
        }
   
        public Juridico insert(Juridico entity)
        {
            StringBuilder sql = new StringBuilder();


            sql.Append("INSERT INTO Pessoa (nome,endereco)");
            sql.Append(" VALUES (");
            sql.Append("'" + entity.nome + "',");
            sql.Append(      entity.endereco.Id );
            sql.Append(")");
            executeNonQuery(sql.ToString()) ;

       

            sql.Clear();
            sql.Append("INSERT INTO Juridico ");
            sql.Append("(Pessoa,razaoSocial,cnpj, email,senha)");
            sql.Append(" VALUES (");
            sql.Append(      entity.Id+",");
            sql.Append("'" + entity.razaoSocial + "',");
            sql.Append("'" + entity.cnpj + "',");
            sql.Append("'" + entity.email + "',");
            sql.Append("'" + entity.senha + "'");
            sql.Append(")");
            executeNonQuery(sql.ToString());

            return entity;
        }
        
        public new void update(int id, Juridico entity)
        {
             StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Pessoa ");
            sql.Append("SET Nome = '"+entity.nome+"',");
            sql.Append(" endereco = "+entity.endereco.Id);
            sql.Append(" WHERE Id = "+entity.Id);
            executeNonQuery(sql.ToString());

            sql.Clear();

            sql.Append("UPDATE Juridico ");
            sql.Append("SET razaoSocial = '"+ entity.razaoSocial+"',");
            sql.Append("    cnpj = '"+ entity.cnpj+"',");
            sql.Append("    email = '" + entity.email + "',");
            sql.Append("    senha = '"+ entity.senha+"'");
            sql.Append(" WHERE Id = "+id);
            executeNonQuery(sql.ToString());
        }

        public void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE Juridico ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
    }
}
