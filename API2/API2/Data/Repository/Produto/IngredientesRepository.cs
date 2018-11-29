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
//GET, POST, PUT, DELETE OK

namespace api.Data.Repository.PackgeProduto

{
  
    public class IngredientesRepository : Db<Ingredientes>, IRepository<Ingredientes>
    {  
       
        public new List<Ingredientes> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Ingredientes> listaIngredientes = new List<Ingredientes>();

            sql.Append("SELECT I.Id, I.Produto, I.MateriaPrima, I.ValorEnergetico, I.ValorDiario, ");
            sql.Append("P.codigoBarra as codBarra, P.descricao as descricao, P.valorVenda as valorVenda,P.preparo as preparo,P.conservacao as conservacao,");
            sql.Append("M.Id as MId, M.Descricao as MDescricao, M.CausaAlergia as MCausaAlergia");
            sql.Append(" FROM Ingredientes as I ");
            sql.Append(" INNER JOIN Produto P ON P.Id = I.Id ");
            sql.Append(" INNER JOIN MateriaPrima M ON M.Id = P.Id");

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                Ingredientes ingrediente = new Ingredientes();

                ingrediente.Id = Convert.ToInt32(reader["Id"]);
                ingrediente.valorDiario = double.Parse(reader["ValorDiario"].ToString());
                ingrediente.valorEnergetico = double.Parse(reader["ValorEnergetico"].ToString());

                Produto prodRepo = new Produto();
                prodRepo.Id = Convert.ToInt32(reader["Produto"].ToString());
                prodRepo.codigoBarra = reader["codBarra"].ToString();
                prodRepo.conservacao=reader["conservacao"].ToString();
                prodRepo.descricao = reader["conservacao"].ToString();
                prodRepo.preparo=reader["preparo"].ToString();
                prodRepo.valorVenda= double.Parse(reader["valorVenda"].ToString());
                ingrediente.produto=prodRepo;

                MateriaPrima matRepo = new MateriaPrima();
                matRepo.Id = Convert.ToInt32(reader["MateriaPrima"]);
                matRepo.descricao=reader["MDescricao"].ToString();
                ingrediente.materiaPrima=matRepo;
                
                listaIngredientes.Add(ingrediente);
            }

            return listaIngredientes;
        }

       
        
        public new Ingredientes getById(int id)
        {
            StringBuilder sql = new StringBuilder();
           

            sql.Append("SELECT I.Id, I.Produto, I.MateriaPrima, I.ValorEnergetico, I.ValorDiario, ");
            sql.Append("P.codigoBarra as codBarra, P.descricao as descricao, P.valorVenda as valorVenda,P.preparo as preparo,P.conservacao as conservacao,");
            sql.Append("M.Id as MId, M.Descricao as MDescricao, M.CausaAlergia as MCausaAlergia");
            sql.Append(" FROM Ingredientes as I ");
            sql.Append(" INNER JOIN Produto P ON P.Id = I.Id ");
            sql.Append(" INNER JOIN MateriaPrima M ON M.Id = P.Id");
            sql.Append(" WHERE I.Id="+id);

            SqlDataReader reader = base.execute(sql.ToString());
            Ingredientes ingrediente = new Ingredientes();

            if (reader.Read())
            {
               

                ingrediente.Id = Convert.ToInt32(reader["Id"]);
                ingrediente.valorDiario = double.Parse(reader["ValorDiario"].ToString());
                ingrediente.valorEnergetico = double.Parse(reader["ValorEnergetico"].ToString());

                Produto prodRepo = new Produto();
                prodRepo.Id = Convert.ToInt32(reader["Produto"].ToString());
                prodRepo.codigoBarra = reader["codBarra"].ToString();
                prodRepo.conservacao = reader["conservacao"].ToString();
                prodRepo.descricao = reader["conservacao"].ToString();
                prodRepo.preparo = reader["preparo"].ToString();
                prodRepo.valorVenda = double.Parse(reader["valorVenda"].ToString());
                ingrediente.produto = prodRepo;

                MateriaPrima matRepo = new MateriaPrima();
                matRepo.Id = Convert.ToInt32(reader["MateriaPrima"]);
                matRepo.descricao = reader["MDescricao"].ToString();
                ingrediente.materiaPrima = matRepo;

                
            }

            return ingrediente;
        }
        
        
        public new Ingredientes insert(Ingredientes entity)
        {
            StringBuilder sql = new StringBuilder();
            int id;

            sql.Append("INSERT INTO Ingredientes (Produto, MateriaPrima, ValorEnergetico, ValorDiario)");
            sql.Append(" VALUES (");
            sql.Append(entity.produto.Id + ",");
            sql.Append(entity.materiaPrima.Id + ",");
            sql.Append(entity.valorEnergetico + ",");
            sql.Append(entity.valorDiario);
            sql.Append(")");
            executeNonQuery(sql.ToString(), out id);

            return entity;
        }

       
        
        public new Ingredientes update(int id, Ingredientes entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Clear();
            sql.Append("UPDATE Ingredientes SET");
            sql.Append(" Produto = " + entity.produto.Id + ",");
            sql.Append(" MateriaPrima = " + entity.materiaPrima.Id + ",");
            sql.Append(" ValorEnergetico = " + entity.valorEnergetico + ",");
            sql.Append(" ValorDiario = " + entity.valorDiario);
            sql.Append(" WHERE Id =" + id);
            executeNonQuery(sql.ToString());

            return entity;
        }

        public new void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE Ingredientes ");
            sql.Append("WHERE Id=" + id);

            executeNonQuery(sql.ToString());
        }
    }
}
