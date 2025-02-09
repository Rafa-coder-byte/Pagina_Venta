﻿using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;

namespace CapaDatos.Utilities
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion()
        {
            // Encuentra el directorio base de la solución
            string basePath = Directory.GetCurrentDirectory();
            while (!File.Exists(Path.Combine(basePath, "appsettings.json")) && basePath != null)
            {
                basePath = Directory.GetParent(basePath)?.FullName;
            }

            // Si no se encuentra el archivo appsettings.json, lanza una excepción
            if (basePath == null)
            {
                throw new FileNotFoundException("No se encontró el archivo appsettings.json en la jerarquía de directorios.");
            }

            // Crea un objeto ConfigurationBuilder para leer el archivo appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Construye la configuración y la asigna a la variable configuration
            IConfiguration configuration = builder.Build();

            // Obtiene la cadena de conexión desde la configuración
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Método para obtener una conexión a la base de datos
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }


    }
}

