using System.Collections.Generic;
using System.Data.SqlClient;
using WNKLab.Domain.Interfaces.Repositories;
using WNKLab.Infra.Repository.Helper;

namespace WNKLab.Infra.Repository.Repositories
{
    public class ExemploRepository<T> : IRepositoryBase<T> where T : class
    {
        public void Adicionar(T obj)
        {
            string sql = string.Format(@"INSERT INTO Tabela ....");

            using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            {
                DataHelper.Execute(conn, sql);
            }
        }

        public void Atualizar(T obj)
        {
            string sql = string.Format(@"UPDATE Tabela ...");

            using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            {
                DataHelper.Execute(conn, sql);
            }
        }

        public void Excluir(T obj)
        {
            string sql = string.Format(@"DELETE FROM Tabela ...");

            using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            {
                DataHelper.Execute(conn, sql);
            }
        }

        public T RetornarPor(int id)
        {
            string sql = string.Format(@"SELECT * FROM Tabela", id);

            //using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            //{
            //    var produto = DataHelper.GetFirstOrDefault<Produto>(conn,
            //                        sql,
            //                        new[]
            //                        {
            //                            typeof(Produto),
            //                            typeof(Categoria)
            //                        },
            //                        objects =>
            //                        {
            //                            var prod = objects[0] as Produto;
            //                            prod.Categoria = objects[1] as Categoria;

            //                            return prod;
            //                        }, "ProdutoId, CategoriaId");

            //    return produto;
            //}

            using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            {
                var produto = DataHelper.GetFirstOrDefault<T>(conn, sql);

                return produto;
            }
        }

        public IEnumerable<T> RetornarTodos()
        {
            string sql = string.Format(@"SELECT * FROM ...");

            //using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            //{
            //    List<Produto> produtos = DataHelper.GetList<Produto>(conn,
            //                        sql,
            //                        new[]
            //                        {
            //                            typeof(Produto),
            //                            typeof(Categoria)
            //                        },
            //                        objects =>
            //                        {
            //                            var produto = objects[0] as Produto;
            //                            produto.Categoria = objects[1] as Categoria;

            //                            return produto;
            //                        }, "ProdutoId, CategoriaId");

            //    return produtos;
            //}

            #region Exemplo sem instanciar objetos

            using (SqlConnection conn = new SqlConnection(DataHelper.ConnectionString))
            {
                var produtos = DataHelper.GetList<T>(conn, sql);

                return produtos;
            }

            #endregion

            #region exemplo com join
            /*
                 using (OracleConnection conn = new OracleConnection(DataReaderHelper.ConnectionString))
                {
                    List<AlarmeDocumentoLegal> lista = DataReaderHelper.GetList<AlarmeDocumentoLegal>(conn,
                        sqlString,
                        new[]
                        {
                            typeof(AlarmeDocumentoLegal),
                            typeof(ForcaTrabalho),
                            typeof(DocumentoLegal),
                            typeof(TipoDocumento)
                        },
                        objects =>
                        {
                            var alarme = objects[0] as AlarmeDocumentoLegal;

                            alarme.ForcaTrabalho = objects[1] as ForcaTrabalho;
                            alarme.DocumentoLegal = objects[2] as DocumentoLegal;
                            alarme.DocumentoLegal.TipoDocumento = objects[3] as TipoDocumento;

                            alarme.CodigoDocumentoLegal = alarme.DocumentoLegal.CodigoDocumentoLegal;
                            alarme.CodigoUsuario = alarme.ForcaTrabalho.Codigo;
                            alarme.ListAlarmeTermoLegal = RetornarListaAlarmeTermoLegal(alarme, conn);
                            alarme.ListAlarmeDestinatario = RetornarListaAlarmeDestinatario(alarme, conn);

                            return alarme;
                        }, "CodigoAlarmeDocumentoLegal, Codigo, CodigoDocumentoLegal, Codigo");

                    return lista;
                }
                 */
            #endregion
        }
    }
}
