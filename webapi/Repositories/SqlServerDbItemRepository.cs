using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Webapi.Entities;

namespace Webapi.Repositories
{
    public class SqlServerDbItemRepository : IItemsRepository
    {
        private IConfiguration Configuration { get; set; }
        public SqlServerDbItemRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void CreateItem(Item item)
        {
            if (item is not null)
            {
                try
                {
                    string conn = Configuration.GetConnectionString("DefaultConnection");
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand("[dbo].[AddItem]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            List<SqlParameter> spParamList = new List<SqlParameter>() {
                                new SqlParameter() {
                                    ParameterName = "@Guid",
                                    SqlDbType = SqlDbType.UniqueIdentifier,
                                    Size = -1,
                                    Direction = ParameterDirection.Input,
                                    Value = item.Id
                                },
                                new SqlParameter() {
                                    ParameterName = "@Name",
                                    SqlDbType = SqlDbType.VarChar,
                                    Size = 100,
                                    Direction = ParameterDirection.Input,
                                    Value = item.Name
                                },
                                new SqlParameter() {
                                    ParameterName = "@Price",
                                    SqlDbType = SqlDbType.Decimal,
                                    Direction = ParameterDirection.Input,
                                    Size = 500,
                                    Value = item.Price

                                }
                            };

                            cmd.Parameters.AddRange(spParamList.ToArray());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public Task CreateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
             try
                {
                    string conn = Configuration.GetConnectionString("DefaultConnection");
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand("[dbo].[DeleteItem]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            List<SqlParameter> spParamList = new List<SqlParameter>() {
                                new SqlParameter() {
                                    ParameterName = "@Guid",
                                    SqlDbType = SqlDbType.UniqueIdentifier,
                                    Size = -1,
                                    Direction = ParameterDirection.Input,
                                    Value = id
                                }
                            };
                            cmd.Parameters.AddRange(spParamList.ToArray());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public Task DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            Item ReturnItem = null;
            try
            {
                string conn = Configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[GetItems]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        List<SqlParameter> spParamList = new List<SqlParameter>() {
                                new SqlParameter() {
                                    ParameterName = "@GUID",
                                    SqlDbType = SqlDbType.UniqueIdentifier,
                                    Size = -1,
                                    Direction = ParameterDirection.Input,
                                    Value = id
                                }
                            };

                        cmd.Parameters.AddRange(spParamList.ToArray());
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Item item = new Item()
                                {
                                    Id = (Guid)reader["Id"],
                                    Name = (string)reader["Name"],
                                    Price = (decimal)reader["Price"],
                                    CreatedDate = (DateTime)reader["CreateDate"]
                                };
                                ReturnItem = item;
                            }
                            reader.NextResult();
                        }
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ReturnItem;
        }

        public Task<Item> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                string conn = Configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[GetItems]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        List<SqlParameter> spParamList = new List<SqlParameter>() {
                                new SqlParameter() {
                                    ParameterName = "@GUID",
                                    SqlDbType = SqlDbType.UniqueIdentifier,
                                    Size = 4,
                                    Direction = ParameterDirection.Input,
                                    //Value = -1
                                }
                            };

                        cmd.Parameters.AddRange(spParamList.ToArray());
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Item item = new Item()
                                {
                                    Id = (Guid)reader["Id"],
                                    Name = (string)reader["Name"],
                                    Price = (decimal)reader["Price"],
                                    CreatedDate = (DateTime)reader["CreateDate"]
                                };
                                items.Add(item);
                            }
                            reader.NextResult();
                        }
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return items;
        }

        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            try
            {
                string conn = Configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[UpdateItem]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        List<SqlParameter> spParamList = new List<SqlParameter>() {
                                new SqlParameter() {
                                    ParameterName = "@Guid",
                                    SqlDbType = SqlDbType.UniqueIdentifier,
                                    Size = -1,
                                    Direction = ParameterDirection.Input,
                                    Value = item.Id
                                },
                                new SqlParameter() {
                                    ParameterName = "@Name",
                                    SqlDbType = SqlDbType.VarChar,
                                    Size = 100,
                                    Direction = ParameterDirection.Input,
                                    Value = item.Name
                                },
                                new SqlParameter() {
                                    ParameterName = "@Price",
                                    SqlDbType = SqlDbType.Decimal,
                                    Direction = ParameterDirection.Input,
                                    Size = 500,
                                    Value = item.Price

                                }
                            };

                        cmd.Parameters.AddRange(spParamList.ToArray());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Task UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}