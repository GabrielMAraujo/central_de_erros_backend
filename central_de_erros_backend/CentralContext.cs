using System;
using System.IO;
using central_de_erros_backend.Models;
using dotenv.net;
using dotenv.net.Utilities;
using Microsoft.EntityFrameworkCore;

namespace central_de_erros_backend
{
    public class CentralContext : DbContext
    {   
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configurando variáveis de ambiente consumidas do .env

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            DotEnv.Config(true, path + "/config/config.env");

            //DotEnv.Config(true);

            var envReader = new EnvReader();

            //Lendo variáveis de ambiente
            string serverAddress = envReader.GetStringValue("SERVER_ADDRESS");
            string serverDatabase = envReader.GetStringValue("SERVER_DATABASE");
            string serverUserId = envReader.GetStringValue("SERVER_USER_ID");
            string serverPassword = envReader.GetStringValue("SERVER_PASSWORD");

            //Configurando o acesso ao servidor
            optionsBuilder.UseSqlServer($"Server={serverAddress};Database={serverDatabase};User Id={serverUserId};Password={serverPassword};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
