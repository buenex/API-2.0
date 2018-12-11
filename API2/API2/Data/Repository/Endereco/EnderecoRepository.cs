using api.Model.PackgeEndereco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


//GET, POST, PUT OK
namespace api.Data.Repository.PackgeEndereco
{

    public class EnderecoRepository : Db<Endereco>, IRepository<Endereco>
    {
        
   
        public List<Endereco> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Endereco> listaEndereco = new List<Endereco>();

            sql.Append("SELECT En.Id, En.Descricao, En.Bairro, ");
            sql.Append(" C.Id as IdCidade, C.Descricao as DescCidade,");
            sql.Append(" E.Id as EstadoId, E.Descricao as DescEstado, E.Sigla,");
            sql.Append(" P.Id as PaisId, P.Descricao DescPais");
            sql.Append(" FROM Endereco En");
            sql.Append(" INNER JOIN Cidade C ON En.Cidade = C.Id");
            sql.Append(" INNER JOIN Estado E ON C.Estado = E.Id");
            sql.Append(" INNER JOIN Pais P ON E.Pais = P.Id");

            SqlDataReader reader = execute(sql.ToString());

            while (reader.Read())
            {
                Cidade cidade = new Cidade();
                cidade.id = Convert.ToInt32(reader["IdCidade"]);
                cidade.descricao = reader["DescCidade"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["DescPais"].ToString();

                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["EstadoId"]);
                estado.descricao = reader["DescEstado"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                estado.pais = pais;

                cidade.estado = estado;

                Endereco endereco = new Endereco();
                endereco.Id = Convert.ToInt32(reader["Id"]);
                endereco.descricao = reader["Descricao"].ToString();
                endereco.bairro = reader["Bairro"].ToString();
                endereco.cidade = cidade;

                listaEndereco.Add(endereco);
            }

            return listaEndereco;

        }

        public new Endereco getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Endereco endereco = new Endereco();

            sql.Append("SELECT En.Id, En.Descricao, En.Bairro, ");
            sql.Append(" C.Id as IdCidade, C.Descricao as DescCidade,");
            sql.Append(" E.Id as EstadoId, E.Descricao as DescEstado, E.Sigla,");
            sql.Append(" P.Id as PaisId, P.Descricao DescPais");
            sql.Append(" FROM Endereco En");
            sql.Append(" INNER JOIN Cidade C ON En.Cidade = C.Id");
            sql.Append(" INNER JOIN Estado E ON C.Estado = E.Id");
            sql.Append(" INNER JOIN Pais P ON E.Pais = P.Id");
            sql.Append(" WHERE En.Id =" + id);

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                Cidade cidade = new Cidade();
                cidade.id = Convert.ToInt32(reader["IdCidade"]);
                cidade.descricao = reader["DescCidade"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["DescPais"].ToString();

                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["EstadoId"]);
                estado.descricao = reader["DescEstado"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                estado.pais = pais;

                cidade.estado = estado;

                endereco.Id = Convert.ToInt32(reader["Id"]);
                endereco.descricao = reader["Descricao"].ToString();
                endereco.bairro = reader["Bairro"].ToString();
                endereco.cidade = cidade;
            }

            return endereco;
        }

        
        public new Endereco getByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            Endereco endereco = new Endereco();

            sql.Append("SELECT En.Id, En.Descricao, En.Bairro, ");
            sql.Append(" C.Id as IdCidade, C.Descricao as DescCidade,");
            sql.Append(" E.Id as EstadoId, E.Descricao as DescEstado, E.Sigla,");
            sql.Append(" P.Id as PaisId, P.Descricao DescPais");
            sql.Append(" FROM Endereco En");
            sql.Append(" INNER JOIN Cidade C ON En.Cidade = C.Id");
            sql.Append(" INNER JOIN Estado E ON C.Estado = E.Id");
            sql.Append(" INNER JOIN Pais P ON E.Pais = P.Id");
            sql.Append(" WHERE En.Descricao ='" + name +"'");

            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                Cidade cidade = new Cidade();
                cidade.id = Convert.ToInt32(reader["IdCidade"]);
                cidade.descricao = reader["DescCidade"].ToString();

                Pais pais = new Pais();
                pais.Id = Convert.ToInt32(reader["PaisId"]);
                pais.descricao = reader["DescPais"].ToString();

                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(reader["EstadoId"]);
                estado.descricao = reader["DescEstado"].ToString();
                estado.sigla = reader["Sigla"].ToString();

                estado.pais = pais;

                cidade.estado = estado;

                endereco.Id = Convert.ToInt32(reader["Id"]);
                endereco.descricao = reader["Descricao"].ToString();
                endereco.bairro = reader["Bairro"].ToString();
                endereco.cidade = cidade;
            }

            return endereco;
        }

        public new void insert(Endereco entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO Endereco");
            sql.Append(" (Descricao, Bairro,Cidade)");
            sql.Append(" VALUES (");
            sql.Append("'" + entity.descricao + "','");
            sql.Append(      entity.bairro+"',");
            sql.Append(      entity.cidade.id);
            sql.Append(")");

            executeNonQuery(sql.ToString());
        }

        public new void update(int id, Endereco entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE Endereco");
            sql.Append(" SET Descricao = '" + entity.descricao + "',");
            sql.Append(" Bairro = '" + entity.bairro + "',");
            sql.Append(" Cidade="+entity.cidade.id);
            sql.Append(" WHERE Id =" + id);

            executeNonQuery(sql.ToString());
        }

        public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE Endereco ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
    }
}
