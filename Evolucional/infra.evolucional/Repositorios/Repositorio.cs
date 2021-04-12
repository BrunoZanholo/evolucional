using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace infra.evolucional.Repositorios
{
    public abstract class Repositorio
    {
        private string stringConnection;

        private string dbuser = "projeto-evolucional-usr";
        private string dbpassword = "6s@f30@54J$gl2M";

        public Repositorio(IConfiguration configuration)
        {
            var dbserver = configuration["Repositorio:DBSever"];
            var dbname = configuration["Repositorio:DBName"];

            this.stringConnection = $"Data Source={dbserver};Initial Catalog={dbname};Integrated Security=False;User ID={dbuser};Password={dbpassword};Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;Application Name={Environment.MachineName}";
        }

        public async Task<int> ExecutarTruncateAsync(string tabela)
        {
            using (var connection = new SqlConnection(this.stringConnection))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = $"DELETE FROM DBO.[{tabela}]"
                })
                {                    
                    return (await command.ExecuteNonQueryAsync());
                }
            }
        }

        public async Task<int> ExecutarCommandoAsync(string query, params Parametro[] parametros)
        {
            using (var connection = new SqlConnection(this.stringConnection))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = query
                })
                {
                    this.Parametros(command, parametros);

                    return (await command.ExecuteNonQueryAsync());
                }
            }
        }

        public async Task<DataTableReader> ExecutarQueryAsync(string query, params Parametro[] parametros)
        {
            using (var connection = new SqlConnection(this.stringConnection))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = query
                })
                {
                    this.Parametros(command, parametros);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        using (var table = new DataTable())
                        {
                            adapter.Fill(table);

                            return table.CreateDataReader();
                        }
                    }
                }
            };
        }

        private void Parametros(SqlCommand command, params Parametro[] parametros)
        {
            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    command.Parameters.AddWithValue(parametro.Nome, parametro.Valor ?? DBNull.Value);
                }
            }
        }

        public async Task<int> ExecutarBulkAsync(DataTable data)
        {
            using (var connection = new SqlConnection(this.stringConnection))
            {
                await connection.OpenAsync();

                using (var comando = new SqlBulkCopy(connection))
                {
                    comando.DestinationTableName = data.TableName;
                    comando.BulkCopyTimeout = 180;

                    foreach (DataColumn coluna in data.Columns)
                    {
                        comando.ColumnMappings.Add(coluna.ColumnName, coluna.ColumnName);
                    }

                    comando.WriteToServer(data);
                }
            }

            return (0);
        }
    }
}