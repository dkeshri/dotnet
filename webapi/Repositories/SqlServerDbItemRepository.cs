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
        private IConfiguration Configuration { get;}
        private ISecondRepo secondRepo;
        public SqlServerDbItemRepository(IConfiguration configuration, ISecondRepo secondRepo)
        {
            Configuration = configuration;
            this.secondRepo = secondRepo;
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

        public async Task CreateItemAsync(Item item)
        {
            await Task.Run(()=>{
                CreateItem(item);
            });
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

        public async Task DeleteItemAsync(Guid id)
        {
            await Task.Run(() =>
            {
                DeleteItem(id);
            });
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

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                return GetItem(id);
            });
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

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.Run(() =>
            {
                return GetItems();
            });
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

        public async Task UpdateItemAsync(Item item)
        {
            await Task.Run(() =>
            {
                UpdateItem(item);
            });
        }
    }
}