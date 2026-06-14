using Abstracciones.Interfaces.DA;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuracion;
        private readonly SqlConnection _sqlConnection;
        public RepositorioDapper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _sqlConnection = new SqlConnection(_configuracion.GetConnectionString("BD"));
        }
        public SqlConnection ObtenerRepositorio()
        {
            return _sqlConnection;
        }
    }
}
