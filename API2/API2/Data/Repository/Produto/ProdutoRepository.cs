using api.Model.PackgeProduto;
using System;
using System.Collections.Generic;
using System.Data;
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
    public class ProdutoRepository : Db<Produto>, IRepository<Produto>
    {
        public new List<Produto> getAll()
        {
            List<Produto> produtos = new List<Produto>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, codigoBarra,");
            sql.Append(" Descricao, ValorVenda, Preparo, Conservacao");
            sql.Append(" FROM Produto");

            var listRows = executeDataTable(sql.ToString());
            Produto produto = new Produto();
            foreach (Dictionary<String, object> reader in listRows)
            {
                
                produto.Id = Convert.ToInt32(reader["Id"].ToString());
                produto.descricao = reader["Descricao"].ToString();
                produto.preparo = reader["Preparo"].ToString();
                produto.codigoBarra = reader["codigoBarra"].ToString();
                produto.conservacao = reader["Conservacao"].ToString();
                produto.valorVenda = double.Parse(reader["ValorVenda"].ToString());

                List<Ingredientes> ingredientes = new List<Ingredientes>();

                sql.Clear();
                sql.Append("SELECT I.Id, I.Produto, MP.Id MateriaPrima,  MP.Descricao, MP.CausaAlergia, I.ValorEnergetico, I.ValorDiario");
                sql.Append(" FROM Ingredientes I");
                sql.Append(" LEFT JOIN MateriaPrima MP ON I.MateriaPrima = MP.Id");
                sql.Append(" WHERE I.Produto = " + produto.Id);

                //SqlDataReader reader2 = execute(sql.ToString());
                var listRows2 = executeDataTable(sql.ToString());

                foreach (Dictionary<String, object> reader2 in listRows2)
                {
                    Ingredientes ingrediente = new Ingredientes();

                    ingrediente.Id = Convert.ToInt32(reader2["Id"].ToString());
                    ingrediente.valorDiario = double.Parse((reader2["ValorDiario"]).ToString());
                    ingrediente.valorEnergetico = double.Parse((reader2["ValorEnergetico"]).ToString());
                    ingrediente.produto = new Produto();
                    ingrediente.produto.Id = Convert.ToInt32(reader2["Produto"].ToString());

                    MateriaPrimaRepository repoMat = new MateriaPrimaRepository();
                    ingrediente.materiaPrima = repoMat.getById(Convert.ToInt32(reader2["MateriaPrima"].ToString()));

                    ingredientes.Add(ingrediente);
                }

                produto.ingredientes = ingredientes;
                produtos.Add(produto);
            }

            return produtos;
        }

        public new Produto getById(int id)
        {
            Produto produto = new Produto();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, codigoBarra,");
            sql.Append(" Descricao, ValorVenda, Preparo, Conservacao");
            sql.Append(" FROM Produto");
            sql.Append(" WHERE Id = " + id);
            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                produto.Id = Convert.ToInt32(reader["Id"].ToString());
                produto.descricao = reader["Descricao"].ToString();
                produto.preparo = reader["Preparo"].ToString();
                produto.codigoBarra = reader["codigoBarra"].ToString();
                produto.conservacao = reader["Conservacao"].ToString();
                produto.valorVenda = double.Parse(reader["ValorVenda"].ToString());

                List<Ingredientes> ingredientes = new List<Ingredientes>();

                sql.Clear();
                sql.Append("SELECT I.Id, I.Produto, MP.Id MateriaPrima,  MP.Descricao, MP.CausaAlergia, I.ValorEnergetico, I.ValorDiario");
                sql.Append(" FROM Ingredientes I");
                sql.Append(" LEFT JOIN MateriaPrima MP ON I.MateriaPrima = MP.Id");
                sql.Append(" WHERE I.Produto = " + produto.Id);

                conn.Close();
                SqlDataReader reader2 = execute(sql.ToString());
                while (reader2.Read())
                {
                    Ingredientes ingrediente = new Ingredientes();

                    ingrediente.Id = Convert.ToInt32(reader2["Id"].ToString());
                    ingrediente.produto.Id = Convert.ToInt32(reader2["Produto"]);
                    ingrediente.valorDiario = double.Parse((reader2["valorDiario"]).ToString());
                    ingrediente.valorEnergetico = double.Parse((reader2["valorEnergetico"]).ToString());

                    MateriaPrimaRepository repoMat = new MateriaPrimaRepository();
                    ingrediente.materiaPrima = repoMat.getById(Convert.ToInt32(reader2["MateriaPrima"].ToString()));

                    ingredientes.Add(ingrediente);
                }

                produto.ingredientes = ingredientes;
            }

            return produto;
        }

        public Produto getByEAN(String EAN)
        {
            Produto produto = new Produto();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, codigoBarra,");
            sql.Append(" Descricao, ValorVenda, Preparo, Conservacao");
            sql.Append(" FROM Produto");
            sql.Append(" WHERE codigoBarra = '" + EAN + "'");
            SqlDataReader reader = execute(sql.ToString());

            if (reader.Read())
            {
                produto.Id = Convert.ToInt32(reader["Id"].ToString());
                produto.descricao = reader["Descricao"].ToString();
                produto.preparo = reader["Preparo"].ToString();
                produto.codigoBarra = reader["codigoBarra"].ToString();
                produto.conservacao = reader["Conservacao"].ToString();
                produto.valorVenda = double.Parse(reader["ValorVenda"].ToString());

                List<Ingredientes> ingredientes = new List<Ingredientes>();

                sql.Clear();
                sql.Append("SELECT I.Id, I.Produto, MP.Id MateriaPrima,  MP.Descricao, MP.CausaAlergia, I.ValorEnergetico, I.ValorDiario");
                sql.Append(" FROM Ingredientes I");
                sql.Append(" LEFT JOIN MateriaPrima MP ON I.MateriaPrima = MP.Id");
                sql.Append(" WHERE I.Produto = " + produto.Id);

                conn.Close();
                SqlDataReader reader2 = execute(sql.ToString());
                while (reader2.Read())
                {
                    Ingredientes ingrediente = new Ingredientes();

                    ingrediente.Id = Convert.ToInt32(reader2["Id"].ToString());
                    ingrediente.produto.Id = Convert.ToInt32(reader2["Produto"].ToString());
                    ingrediente.valorDiario = double.Parse((reader2["valorDiario"]).ToString());
                    ingrediente.valorEnergetico = double.Parse((reader2["valorEnergetico"]).ToString());

                    MateriaPrimaRepository repoMat = new MateriaPrimaRepository();
                    ingrediente.materiaPrima = repoMat.getById(Convert.ToInt32(reader2["MateriaPrima"].ToString()));

                    ingredientes.Add(ingrediente);
                }

                produto.ingredientes = ingredientes;
            }

            return produto;
        }

        public new Produto insert(Produto entity)
        {
            Produto produto = new Produto();
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Produto ");
            sql.Append("VALUES('"+entity.codigoBarra+"','");
            sql.Append(           entity.descricao+"',");
            sql.Append(           entity.valorVenda.ToString()+",'");
            sql.Append(           entity.preparo+"','");
            sql.Append(           entity.conservacao+"')");
            executeNonQuery(sql.ToString());
            return produto;
        }

        public new Produto update(int id, Produto entity)
        {
            Produto produto = new Produto();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE Produto ");
            sql.Append("SET codigoBarra='"+entity.codigoBarra+"',");
            sql.Append("descricao='"+entity.descricao+"',");
            sql.Append("valorVenda="+entity.valorVenda.ToString()+",");
            sql.Append("preparo = '"+entity.preparo+"',");
            sql.Append("conservacao = '"+entity.conservacao+"' ");
            sql.Append("WHERE id = "+id);
            executeNonQuery(sql.ToString());
            return produto;
        }

        public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE Produto ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
    }
}
