using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;
using Biblioteca.Models.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.Models.Contexts
{
    public class ContextDataSqlServer : IContextData
    {
        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

        public void AtualizarLivro(LivroDto livro)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(Enum.TSql.ATUALIZAR_LIVRO);

                using (var command = new SqlCommand(query, _connection))
                {
                    command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = livro.Id;
                    command.Parameters.Add("@nome", System.Data.SqlDbType.VarChar).Value = livro.Nome;
                    command.Parameters.Add("@autor", System.Data.SqlDbType.VarChar).Value = livro.Autor;
                    command.Parameters.Add("@editora", System.Data.SqlDbType.VarChar).Value = livro.Editora;

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(Enum.TSql.CADASTRAR_LIVRO);
                using (var command = new SqlCommand(query, _connection))
                {
                    command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = livro.Id;
                    command.Parameters.Add("@nome", System.Data.SqlDbType.VarChar).Value = livro.Nome;
                    command.Parameters.Add("@autor", System.Data.SqlDbType.VarChar).Value = livro.Autor;
                    command.Parameters.Add("@editora", System.Data.SqlDbType.VarChar).Value = livro.Editora;

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(Enum.TSql.EXCLUIR_LIVRO);
                using (var command = new SqlCommand(query, _connection))
                {
                    command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }


        public List<LivroDto> ListarLivro()
        {
            try
            {
                List<LivroDto> livroList = new List<LivroDto>();
                _connection.Open();

                var query = SqlManager.GetSql(Enum.TSql.LISTAR_LIVRO);
                using (var command = new SqlCommand(query, _connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetString(0);
                            var nome = reader.GetString(1);
                            var autor = reader.GetString(2);
                            var editora = reader.GetString(3);

                            var livro = new LivroDto(id, nome, autor, editora);
                            livroList.Add(livro);
                        }
                    }
                }

                return livroList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error listing books", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            try
            {
                LivroDto livro = null;
                _connection.Open();

                var query = SqlManager.GetSql(Enum.TSql.PESQUISAR_LIVRO);
                
                using (var command = new SqlCommand(query, _connection))
                {
                    command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var idLivro = reader.GetString(0);
                            var nome = reader.GetString(1);
                            var autor = reader.GetString(2);
                            var editora = reader.GetString(3);

                            livro = new LivroDto(idLivro, nome, autor, editora);
                        }
                    }
                }

                return livro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
