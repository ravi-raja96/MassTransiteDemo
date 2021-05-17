using System;
using Npgsql;

namespace InventoryService.Config
{
    public class PostgresConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ConnectionString
        {
            get
            {
                NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder
                {
                    Host = Host,
                    Port = Port,
                    Username = User,
                    Password = Password,
                    Database = Name,
                };
                return builder.ConnectionString;
            }
        }
    }
}
