using Store_API.Connection;
using Store_API.Models;
using System.Data;
using System.Data.SqlClient;

namespace Store_API.Data
{
    public class Dproducts
    {
        ConnectionBD cn = new ConnectionBD();

        public async Task<List<MProducts>> ShowProducts()
        {
            var list = new List<MProducts>();

            using (var sql = new SqlConnection(cn.stringSQL()))
            {
                using (var cmd = new SqlCommand("showProducts", sql))
                {
                    await sql.OpenAsync(); // Abrir la conexión
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproduucts = new MProducts();
                            mproduucts.id = (int)item["id"];
                            mproduucts.description = (string)item["description"];
                            mproduucts.price = (decimal)item["price"];

                            list.Add(mproduucts);
                        }
                    } //recorrido de datos

                    // Aquí podrías ejecutar el comando y procesar los resultados en 'list'
                } //execute store procedure
            } //connection

            return list;
        }

        public async Task InsertProducts(MProducts parameters)
        {


            using (var sql = new SqlConnection(cn.stringSQL()))
            {
                using (var cmd = new SqlCommand("insertProducts", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@description", parameters.description);
                    cmd.Parameters.AddWithValue("@price", parameters.price);

                    await sql.OpenAsync(); // Abrir la conexión
                    await cmd.ExecuteNonQueryAsync();
                }
      
            } 

        }

        public async Task editProduct(MProducts parameters)
        {


            using (var sql = new SqlConnection(cn.stringSQL()))
            {
                using (var cmd = new SqlCommand("editProducts", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parameters.id);
                    //cmd.Parameters.AddWithValue("@description", parameters.description);
                    cmd.Parameters.AddWithValue("@price", parameters.price);

                    await sql.OpenAsync(); // Abrir la conexión
                    await cmd.ExecuteNonQueryAsync();
                }

            }

        }

        public async Task deleteProducts(MProducts parameters)
        {


            using (var sql = new SqlConnection(cn.stringSQL()))
            {
                using (var cmd = new SqlCommand("deleteProducts", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parameters.id);
                    await sql.OpenAsync(); // Abrir la conexión
                    await cmd.ExecuteNonQueryAsync();
                }

            }

        }
    }
}

