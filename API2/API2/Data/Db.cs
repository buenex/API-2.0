using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;

namespace api.Data
{
    public abstract class Db<T>
    {
        public SqlConnection conn;
        public SqlCommand sqlCmd;
       
        public Db(String sqlServer, String nBanco, String userID, String pwd)
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder();

            conString.DataSource = sqlServer;
            conString.InitialCatalog = nBanco;
            conString.UserID = userID;
            conString.Password = pwd;

            conn = new SqlConnection(conString.ConnectionString);

        }

        //public Db() : this("moura3.brazilsouth.cloudapp.azure.com,1249", "nuRotulo", "usernurotulo", "AlsmnGigh12FdxC") { }
        public Db() : this("localhost", "nuRotulo", "sa", "123456") { }

        public SqlDataReader execute(string command)
        {
            string cmd = command;

            try
            {
                sqlCmd = new SqlCommand(cmd, conn);
                conn.Open();
                return sqlCmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //conn.Close();
            }

        }

        public List<Dictionary<string, object>> executeDataTable(string command)
        {
            string cmd = command;

            try
            {
                sqlCmd = new SqlCommand(cmd, conn);
                conn.Open();
                var dataReader = sqlCmd.ExecuteReader();
                return SelectDataRecord(dataReader);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private List<Dictionary<string, object>> SelectDataRecord(SqlDataReader reader)
        {
            var retorno = new List<Dictionary<string, object>>();
            foreach (IDataRecord record in reader as System.Collections.IEnumerable)
            {
                var item = new Dictionary<string, object>();
                for (var x = 0; x < record.FieldCount; x++)
                {
                    item.Add(record.GetName(x), record.GetValue(x));
                }
                retorno.Add(item);
            }
            return retorno;
        }

        public void executeNonQuery(string command)
        {
            string cmd = command;

            sqlCmd = new SqlCommand(cmd, conn);

            conn.Open();
            sqlCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void executeNonQuery(string command, out int id)
        {
            id = 0;

            string cmd = command;

            sqlCmd = new SqlCommand(cmd, conn);

            conn.Open();
            sqlCmd.ExecuteNonQuery();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT SCOPE_IDENTITY() as Id");
            sqlCmd = new SqlCommand(sql.ToString(), conn);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["Id"]);
            }

            conn.Close();
        }

        public List<T> getAll()
        {
            StringBuilder sql = new StringBuilder();
            var tipo = typeof(T);
            List<T> listaEntidade = new List<T>();

            sql.Append("SELECT ");
            sql.Append(retornarNomeProp(true));
            sql.Append(" FROM ");
            sql.Append(tipo.Name);

            SqlDataReader reader = execute(sql.ToString());

            while (reader.Read())
            {
                var entity = Activator.CreateInstance<T>();

                foreach (var prop in tipo.GetProperties())
                {
                    if (prop.PropertyType == typeof(Double))
                    {
                        prop.SetValue(entity, double.Parse(reader[prop.Name].ToString()));
                    }
                    else
                    {
                        if (reader[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(entity, reader[prop.Name]);
                        }
                    }
                }

                listaEntidade.Add(entity);
            }

            return listaEntidade;
        }

        public T getById(int id)
        {
            StringBuilder sql = new StringBuilder();
            var tipo = typeof(T);
            var entity = Activator.CreateInstance<T>();

            sql.Append("SELECT ");
            sql.Append(retornarNomeProp(true));
            sql.Append(" FROM ");
            sql.Append(tipo.Name);
            sql.Append(" WHERE Id =" + id);

            SqlDataReader reader = execute(sql.ToString());

            while (reader.Read())
            {
                foreach (var prop in tipo.GetProperties())
                {
                    if (prop.PropertyType == typeof(Double))
                    {
                        prop.SetValue(entity, double.Parse(reader[prop.Name].ToString()));
                    }
                    else
                    {
                        if (reader[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(entity, reader[prop.Name]);
                        }
                    }
                }
            }

            return entity;
        }

        public T insert(T entity)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("INSERT INTO ");
                sql.Append(entity.GetType().Name);
                sql.Append(" (");
                sql.Append(retornarNomeProp());
                sql.Append(")");
                sql.Append(" VALUES (");
                sql.Append(retornarValorProp(entity));
                sql.Append(")");

                executeNonQuery(sql.ToString());

                return entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public T update(int id, T entity)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder aux = new StringBuilder();

                var tipo = typeof(T);

                sql.Append("UPDATE ");
                sql.Append(entity.GetType().Name);
                sql.Append(" SET ");

                foreach (var prop in tipo.GetProperties())
                {
                    if (prop.Name.ToString().ToLower() != "id")
                    {
                        if (prop.PropertyType == typeof(String))
                        {
                            sql.Append(prop.Name + " = '" + prop.GetValue(entity).ToString() + "',");
                        }
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            sql.Append(prop.Name + " = '" + String.Format("dd/MM/yyyy", prop.GetValue(entity).ToString()) + "',");
                        }
                        if (prop.PropertyType == typeof(Boolean))
                        {
                            if (prop.GetValue(entity).ToString() == "True")
                            {
                                sql.Append(prop.Name + " = 1,");
                            }
                            else
                            {
                                sql.Append(prop.Name + " = 0,");
                            }

                        }
                    }

                }

                aux.Append(sql.ToString().Remove(sql.Length - 1));
                aux.Append(" WHERE Id =" + id);

                executeNonQuery(aux.ToString());

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            var tipo = typeof(T);

            sql.Append("DELETE FROM ");
            sql.Append(tipo.Name);
            sql.Append(" WHERE Id = " + id);

            executeNonQuery(sql.ToString());
        }

        private string retornarNomeProp(bool retornarId = false)
        {
            StringBuilder texto = new StringBuilder();
            var tipo = typeof(T);

            foreach (var prop in tipo.GetProperties())
            {
                if (prop.Name != "Id")
                {
                    texto.Append(prop.Name + ",");
                }
                else
                {
                    if (retornarId == true)
                    {
                        texto.Append(prop.Name + ",");
                    }
                }
            }

            return texto.ToString().Remove(texto.Length - 1);
        }

        private string retornarValorProp(T entity)
        {
            StringBuilder texto = new StringBuilder();
            var tipo = typeof(T);

            foreach (var prop in tipo.GetProperties())
            {
                if (prop.Name != "Id")
                {
                    if (prop.PropertyType == typeof(String))
                    {
                        texto.Append("'" + prop.GetValue(entity).ToString() + "',");
                    }
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        texto.Append("'" + String.Format("mm/dd/yyyy", prop.GetValue(entity).ToString()) + "',");
                    }
                    if (prop.PropertyType == typeof(Boolean))
                    {
                        if (prop.GetValue(entity).ToString() == "True")
                        {
                            texto.Append("1,");
                        }
                        else
                        {
                            texto.Append("0,");
                        }

                    }

                }

            }

            return texto.ToString().Remove(texto.Length - 1);
        }
    }
}
