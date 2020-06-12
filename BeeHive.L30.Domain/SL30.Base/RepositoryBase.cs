using BeeHive.L90.Generics.SL10;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
namespace BeeHive.L30.Domain.SL30.Base
{
    public abstract class RepositoryBase<T>
    {

        //connection string 
       public string connectionString = string.Empty;
        /// <summary>
        /// This method gets all the record of the defined entity.
        /// </summary>
        /// <returns></returns>
        public RepositoryBase()
        {
            //Get connection string from appsettings.json
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string is null or empty.");
        }
        public virtual List<T> All()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                string queryExpression = string.Empty;
                Dictionary<string, Tuple<string, bool, TypeCode>> properties = GetTableProperties();
                if (properties.Count != 0)
                {
                    queryExpression += "select ";
                    queryExpression += string.Join(",",properties.Select(x => "\"" + x.Key + "\" \"" + x.Value.Item1 + "\""));
                    queryExpression += " from ";
                    queryExpression += GetTableName();
                }
                conn.Open();
                List<T> result = conn.Query<T>(queryExpression).ToList();
                conn.Close();
                conn.Dispose();
                return result;
            }
            catch (NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// This method gets the record of the defined entity by id
        /// </summary>
        /// <param name="id">ID of the record to be fetched</param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                string queryExpression = string.Empty;
                Dictionary<string, Tuple<string, bool, TypeCode>> properties = GetTableProperties();
                if (properties.Count != 0)
                {
                    string primaryKey = properties.Where(x => x.Value.Item2 == true).Select(x => x.Key).FirstOrDefault();
                    queryExpression += "select ";
                    queryExpression += string.Join(",", properties.Select(x => "\"" + x.Key + "\" \"" + x.Value.Item1 + "\"").ToList());
                    queryExpression += " from ";
                    queryExpression += GetTableName();
                    queryExpression += $" where {primaryKey} = {id}";
                }
                conn.Open();
                T result = conn.Query<T>(queryExpression).FirstOrDefault();
                conn.Close();
                conn.Dispose();
                return result;
            }
            catch (NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// This method cretes a record of the defined entity
        /// </summary>
        /// <param name="domain">Entity record to be created</param>
        /// <returns>Entity record with Id if table has a primary key else returns same record.</returns>
        public virtual T Create(T domain)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                Dictionary<string, Tuple<string, bool, TypeCode>> properties = GetTableProperties();
                List<string> insertColumns = properties.Where(x => x.Value.Item2 == false).OrderBy(x => x.Key).Select(x => x.Key).ToList();
                Dictionary<string, Tuple<string, TypeCode>> values = new Dictionary<string, Tuple<string, TypeCode>>();
                foreach (KeyValuePair<string, Tuple<string, bool, TypeCode>> property in properties.OrderBy(x => x.Key))
                {
                    if (property.Value.Item2 == true)
                        continue;
                    if (typeof(T).GetProperty(property.Value.Item1).GetValue(domain) != null)
                        values.Add(property.Key, new Tuple<string, TypeCode>(typeof(T).GetProperty(property.Value.Item1).GetValue(domain).ToString(), property.Value.Item3));
                    else
                        values.Add(property.Key, new Tuple<string, TypeCode>(null, property.Value.Item3));
                }
                string insertQuery = $"insert into {GetTableName()}";
                string columnQuery = $"({string.Join(",", insertColumns)})";
                string parameterizedValue = $"(@{string.Join(",@", insertColumns)})";
                string queryExpression = $"{insertQuery}{columnQuery} values {parameterizedValue}";
                conn.Open();
                using (var cmd = new NpgsqlCommand(queryExpression, conn))
                {
                    foreach (string item in insertColumns)
                    {
                        Tuple<string, TypeCode> value;
                        values.TryGetValue(item, out value);
                        if (value.Item1 == null)
                            cmd.Parameters.AddWithValue($"@{item}", DBNull.Value);
                        else
                            switch (value.Item2)
                            {
                                case TypeCode.Int32:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToInt32(value.Item1));
                                    break;
                                case TypeCode.Int64:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToInt64(value.Item1));
                                    break;
                                case TypeCode.DateTime:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToDateTime(value.Item1));
                                    break;
                                case TypeCode.Boolean:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToBoolean(value.Item1));
                                    break;
                                default:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToString(value.Item1));
                                    break;
                            }
                    }
                    cmd.ExecuteNonQuery();
                }
                string primaryKey = properties.Where(x => x.Value.Item2 == true).OrderBy(x => x.Key).Select(x => x.Key).FirstOrDefault();
                if (primaryKey != null)
                {
                    queryExpression = $"select currval(pg_get_serial_sequence('{GetTableName()}','{primaryKey}'));";
                    int id = conn.Query<int>(queryExpression).FirstOrDefault();
                    queryExpression = $"select {string.Join(",", properties.Select(x => "\""+x.Key +"\" \""+ x.Value.Item1+"\"").ToList())} from {GetTableName()} where {primaryKey} = {id}";
                    domain = conn.Query<T>(queryExpression).FirstOrDefault();
                }
                return domain;
            }
            catch (NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// This method updates the record in database
        /// </summary>
        /// <param name="domain">Entity Record to be updated</param>
        /// <returns></returns>
        public virtual T Update(T domain)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                string queryExpression = $"update {GetTableName()} set ";
                string whereExpression = string.Empty;
                Dictionary<string, Tuple<string, bool, TypeCode>> properties = GetTableProperties();
                List<string> updateColumns = new List<string>();
                Dictionary<string, Tuple<string, TypeCode>> values = new Dictionary<string, Tuple<string, TypeCode>>();
                foreach (KeyValuePair<string, Tuple<string, bool, TypeCode>> property in properties)
                {
                    string column = property.Key;
                    if (property.Value.Item2)
                    {
                        string value = typeof(T).GetProperty(property.Value.Item1).GetValue(domain).ToString();
                        whereExpression = $" where {column} = {value}";
                    }
                    else
                    {
                        if (typeof(T).GetProperty(property.Value.Item1).GetValue(domain) != null)
                            values.Add(property.Key, new Tuple<string, TypeCode>(typeof(T).GetProperty(property.Value.Item1).GetValue(domain).ToString(), property.Value.Item3));
                        else
                            values.Add(property.Key, new Tuple<string, TypeCode>(null, property.Value.Item3));
                        updateColumns.Add($"{column} = @{column}");
                    }
                }
                queryExpression += string.Join(",", updateColumns) + whereExpression;
                conn.Open();
                using (var cmd = new NpgsqlCommand(queryExpression, conn))
                {
                    foreach (string item in properties.Where(x => x.Value.Item2 == false).OrderBy(x => x.Key).Select(x => x.Key).ToList())
                    {
                        Tuple<string, TypeCode> value;
                        values.TryGetValue(item, out value);
                        if (value.Item1 == null)
                            cmd.Parameters.AddWithValue($"@{item}", DBNull.Value);
                        else
                            switch (value.Item2)
                            {
                                case TypeCode.Int32:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToInt32(value.Item1));
                                    break;
                                case TypeCode.Int64:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToInt64(value.Item1));
                                    break;
                                case TypeCode.DateTime:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToDateTime(value.Item1));
                                    break;
                                case TypeCode.Boolean:
                                    cmd.Parameters.AddWithValue($"@{item}",Convert.ToBoolean(value.Item1));
                                    break;
                                default:
                                    cmd.Parameters.AddWithValue($"@{item}", Convert.ToString(value.Item1));
                                    break;
                            }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return domain;
        }
        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="id">Delete Entity id</param>
        public virtual void Delete(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                Dictionary<string, Tuple<string, bool, TypeCode>> properties = GetTableProperties();
                string primaryKey = properties.Where(x => x.Value.Item2 == true).Select(x => x.Key).FirstOrDefault();
                string queryExpression = $"delete from {GetTableName()} where {primaryKey} = {id.ToString()}";
                conn.Open();
                conn.Query(queryExpression);
            }
            catch(NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// This method gets the table properties.
        /// return type Dictionary<string, Tuple<string, bool, TypeCode>> where
        /// Dictionary key is the column name in db
        /// in tuple item1 = Name in class.
        /// item2 = IsKey is the bool to identify if this is a primary key in the table
        /// item3 = TypeCode that defines the datatype.
        /// </summary>
        private static Dictionary<string, Tuple<string, bool, TypeCode>> GetTableProperties()
        {
            try
            {
                Dictionary<string, Tuple<string, bool, TypeCode>> properties = new Dictionary<string, Tuple<string, bool, TypeCode>>();
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    //if propery is of type nullable
                    TypeCode typeCode = new TypeCode();
                    if (property.PropertyType == typeof(Nullable<Int16>))
                        typeCode = TypeCode.Int16;
                    else if (property.PropertyType == typeof(Nullable<Int32>))
                        typeCode = TypeCode.Int32;
                    else if (property.PropertyType == typeof(Nullable<Int64>))
                        typeCode = TypeCode.Int64;
                    else if (property.PropertyType == typeof(Nullable<DateTime>))
                        typeCode = TypeCode.DateTime;
                    else if (property.PropertyType == typeof(Nullable<Decimal>))
                        typeCode = TypeCode.Decimal;
                    else if (property.PropertyType == typeof(Nullable<Double>))
                        typeCode = TypeCode.Double;
                    else
                        typeCode = Type.GetTypeCode(property.PropertyType);
                    object[] attributes = property.GetCustomAttributes(true);
                    KeyAttribute keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                    bool isKey = keyAttribute == null ? false : true;
                    ColumnAttribute columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
                    if (columnAttribute != null)
                    {
                        string aliasName = columnAttribute.Name;
                        properties.Add(aliasName, new Tuple<string, bool, TypeCode>(property.Name, isKey, typeCode));
                    }
                }
                return properties;
            }
            catch (NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This Method returns the corresponsing tablename of the entity.
        /// </summary>
        /// <returns></returns>
        private static string GetTableName()
        {
            string tableName = string.Empty;
            var attributes = typeof(T).GetCustomAttributes();
            foreach (object attribute in attributes)
            {
                TableAttribute aliasAttribute = attribute as TableAttribute;
                if (aliasAttribute != null)
                {
                    tableName = aliasAttribute.Name;
                }
            }
            return tableName;
        }
    }
}
