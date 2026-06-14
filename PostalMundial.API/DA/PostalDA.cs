using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DA
{
    public class PostalDA : IPostalDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public PostalDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones CRUD
        public async Task<Guid> Agregar(PostalRequest postal)
        {
            Guid id = Guid.NewGuid();
            await _sqlConnection.ExecuteAsync("dbo.AgregarPostal", new
            {
                Id = id,
                IdPais = postal.IdPais,
                IdGrupo = postal.IdGrupo,
                Numero = postal.Numero,
                Tengo = postal.Tengo,
                Posicion = postal.Posicion,
                FechaAgregada = postal.FechaAgregada,
                Notas = postal.Notas
            }, commandType: CommandType.StoredProcedure);
            return id;
        }

        public async Task<Guid> Editar(Guid Id, PostalRequest postal)
        {
            await verificarPostalExiste(Id);
            string query = @"EditarPostal";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new 
            {
                Id = Id,
                IdPais = postal.IdPais,
                IdGrupo = postal.IdGrupo,
                Numero = postal.Numero,
                Tengo = postal.Tengo,
                Posicion = postal.Posicion,
                FechaAgregada = postal.FechaAgregada,
                Notas = postal.Notas
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarPostalExiste(Id);
            string query = @"EliminarPostal";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id = Id });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<PostalResponse>> Obtener()
        {
            string query = @"ObtenerPostales";
            var resultadoConsulta = await _sqlConnection.QueryAsync<PostalResponse>(query);
            return resultadoConsulta;
        }

        public async Task<PostalResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerPostal";
            var resultadoConsulta = await _sqlConnection.QuerySingleAsync<PostalResponse>(query, new { Id = Id });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<PostalResponse>> ObtenerFaltantes()
        {
            string query = @"ObtenerPostalesFaltantes";
            var resultadoConsulta = await _sqlConnection.QueryAsync<PostalResponse>(query);
            return resultadoConsulta;
        }
        #endregion

        #region Helpers
        private async Task verificarPostalExiste(Guid Id)
        {
            PostalResponse? postalExistente = await Obtener(Id);
            if(postalExistente == null)
            {
                throw new InvalidOperationException("La postal no existe");
            }
        }
        #endregion
    }
}
