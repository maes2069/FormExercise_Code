using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using FormApp.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace FormApp.Data
{
    
    public class RequestRepository
    {
        private readonly IConfiguration _configuration;

        public RequestRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddRequest(RequestModel request)
        {
            string connectionString = "Server=localhost;Port=3306;Database=tech_requests;Uid=root;Pwd=2522;";
            // string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO request_list (email, description, dueDate) VALUES (@email, @description, @dueDate)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", request.Email);
                cmd.Parameters.AddWithValue("@description", request.Description);
                cmd.Parameters.AddWithValue("@dueDate", request.DueDate);
                cmd.ExecuteNonQuery();
            }
        }
        public List<RequestModel> GetAllRequests()
        {
            List<RequestModel> requests = new List<RequestModel>();

            string connectionString = "Server=localhost;Port=3306;Database=tech_requests;Uid=root;Pwd=2522;";
            // string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT email, description, dueDate FROM request_list ORDER BY dueDate ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new RequestModel
                        {
                            Email = reader.GetString("email"),
                            Description = reader.GetString("description"),
                            DueDate = reader.GetDateTime("dueDate")
                        });
                    }
                }
            }

            return requests;
        }
    }
}
