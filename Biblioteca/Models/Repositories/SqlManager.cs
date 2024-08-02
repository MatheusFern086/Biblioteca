using Biblioteca.Models.Enum;
using System.Text;

namespace Biblioteca.Models.Repositories
{
    public class SqlManager
    {
        public static string GetSql(TSql tsql)
        {
            StringBuilder sql = new StringBuilder();

            switch (tsql)
            {
                case TSql.CADASTRAR_LIVRO:
                    
                    sql.AppendLine("INSERT INTO livro")
                        .AppendLine("(")
                        .AppendLine("   id")
                        .AppendLine(",  nome")
                        .AppendLine(",  autor")
                        .AppendLine(",  editora")
                        .AppendLine(")")
                        .AppendLine("VALUES")
                        .AppendLine("(")
                        .AppendLine("   @id")
                        .AppendLine(",  @nome")
                        .AppendLine(",  @autor")
                        .AppendLine(",  @editora")
                        .AppendLine(")");

                    break;
                case TSql.PESQUISAR_LIVRO:

                    sql.AppendLine("SELECT")
                        .AppendLine("   CONVERT(varchar(36), l.id) as id")
                        .AppendLine(",  l.nome")
                        .AppendLine(",  l.autor")
                        .AppendLine(",  l.editora")
                        .AppendLine(",  sl.status")
                        .AppendLine("FROM livro l")
                        .AppendLine("INNER JOIN statusLivro sl ON sl.id = l.es_status")
                        .AppendLine("WHERE l.id = @id");

                    break;
                case TSql.EXCLUIR_LIVRO:

                    sql.AppendLine("DELETE")
                        .AppendLine("FROM livro")
                        .AppendLine("WHERE id = @id");

                    break;
                case TSql.LISTAR_LIVRO:

                    sql.AppendLine("SELECT ")
                        .AppendLine("CONVERT(varchar(36), l.id) as id")
                        .AppendLine(", l.nome")
                        .AppendLine(", l.autor")
                        .AppendLine(", l.editora")
                        .AppendLine(", sl.status")
                        .AppendLine("FROM livro l")
                        .AppendLine("INNER JOIN statusLivro sl ON sl.id = l.es_status");

                    break;
                case TSql.ATUALIZAR_LIVRO:

                    sql.AppendLine("UPDATE livro")
                        .AppendLine("SET")
                        .AppendLine("   nome = @nome")
                        .AppendLine(",  autor = @autor")
                        .AppendLine(",  editora = @editora")
                        .AppendLine("WHERE id = @id");

                    break;
            }

            return sql.ToString();
        }
    }
}
