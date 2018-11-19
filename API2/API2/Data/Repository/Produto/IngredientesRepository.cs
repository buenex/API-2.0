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
  
    public class IngredientesRepository : Db<Ingredientes>, IRepository<Ingredientes>
    {  
       
        public new List<Ingredientes> getAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Ingredientes> listaIngredientes = new List<Ingredientes>();

            sql.Append("SELECT Id, Produto, MateriaPrima, ValorEnergetico, ValorDiario");
            sql.Append(" FROM Ingredientes");

            SqlDataReader reader = base.execute(sql.ToString());

            while (reader.Read())
            {
                Ingredientes ingrediente = new Ingredientes();

                ingrediente.Id = Convert.ToInt32(reader["Id"]);
                ingrediente.valorDiario = double.Parse(reader["ValorDiario"].ToString());
                ingrediente.valorEnergetico = double.Parse(reader["ValorEnergetico"].ToString());

                ProdutoRepository prodRepo = new ProdutoRepository();
                ingrediente.produto = Convert.ToInt32(reader["Produto"]);

                MateriaPrimaRepository matRepo = new MateriaPrimaRepository();
                ingrediente.materiaPrima = matRepo.getById(Convert.ToInt32(reader["MateriaPrima"]));
                listaIngredientes.Add(ingrediente);
            }

            return listaIngredientes;
        }

       
        
        public new Ingredientes getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            Ingredientes Ingrediente = new Ingredientes();

            sql.Append("SELECT Id, Produto, MateriaPrima, ValorEnergetico, ValorDiario");
            sql.Append(" FROM Ingredientes");
            sql.Append(" WHERE Id = " + id);

            SqlDataReader reader = base.execute(sql.ToString());

            if (reader.Read())
            {
                Ingrediente.Id = Convert.ToInt32(reader["Id"]);
                Ingrediente.valorDiario = double.Parse(reader["ValorDiario"].ToString());
                Ingrediente.valorEnergetico = double.Parse(reader["ValorEnergetico"].ToString());

                ProdutoRepository prodRepo = new ProdutoRepository();
                //Ingrediente.produto = prodRepo.getById(Convert.ToInt32(reader["Produto"]));
                Ingrediente.produto = Convert.ToInt32(reader["Produto"]);

                MateriaPrimaRepository matRepo = new MateriaPrimaRepository();
                Ingrediente.materiaPrima = matRepo.getById(Convert.ToInt32(reader["MateriaPrima"]));
            }

            return Ingrediente;
        }
        
        
        public new Ingredientes insert(Ingredientes entity)
        {
            StringBuilder sql = new StringBuilder();
            int id;

            sql.Append("INSERT INTO Ingredientes (Produto, MateriaPrima, ValorEnergetico, ValorDiario)");
            sql.Append(" VALUES (");
            sql.Append(entity.produto + ",");
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
            sql.Append(" Produto = " + entity.produto + ",");
            sql.Append(" MateriaPrima = " + entity.materiaPrima.Id + ",");
            sql.Append(" valorEnergetico = " + entity.valorEnergetico + ",");
            sql.Append(" valorDiario = " + entity.valorDiario);
            sql.Append(" WHERE ID =" + id);
            executeNonQuery(sql.ToString());

            return entity;
        }

        public new void delete(int id)
        {
            base.delete(id);
        }
    }
}
