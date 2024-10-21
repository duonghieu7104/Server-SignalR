using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class QueryHub : Hub
{
    private readonly string connectionString = "Data Source=LAPTOP-PMSG8QVF;Initial Catalog=JOBAPP;Integrated Security=True";

    public async Task<List<string>> GetAllMessages()
    {
        var messages = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            string query = "SELECT Content FROM Message";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    messages.Add(reader.GetString(0));
                }
            }
        }

        return messages;
    }
}
