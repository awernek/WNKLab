using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WNKLab.Infra.Repository.Factory
{
    public class FactoryConnection
    {
        #region Propriedades da Conexao

        string strConn = ConfigurationManager.AppSettings["ConexaoDB"]; //@"Server=.\sqlexpress;Database=TorneioWebAppDB;User Id=sa;Password=123456"; 
        SqlTransaction objTransacao = null;
        SqlConnection objConn = null;

        #endregion

        #region Métodos Conexão

        /// <summary>
        /// Conecta ao banco
        /// </summary>
        /// <returns>verdade ou falso</returns>
        public bool Conectar()
        {
            ///Abre a conexão passando a string de configuração.
            objConn = new SqlConnection(strConn);

            try
            {
                objConn.Open();
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// limpa e fecha a conexão
        /// </summary>
        /// <returns>verdade ou falso</returns>
        public bool Desconectar()
        {
            try
            {
                ///Verifica se o estado da conexão está diferente de fechado
                if (objConn.State != ConnectionState.Closed)
                {
                    //fecha a conexão
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return true;
        }

        #endregion

        #region Métodos de Retorno

        /// <summary>
        /// Retornar Dados - Select
        /// </summary>
        /// <param name="strSql">Comando SQL</param>
        /// <param name="strNomeTabela">Nome da Tabela</param>
        /// <returns>Retornar um DataSet</returns>
        public DataTable RetornarDados(String strSql, String strNomeTabela)
        {
            DataSet ds = new DataSet();

            try
            {
                if (!this.Conectar())
                {
                    return null;
                }

                objTransacao = objConn.BeginTransaction();
                SqlCommand objCmd = new SqlCommand(strSql, objConn); //classe que implementa um comando no SQL Server

                SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);


                try
                {
                    objTransacao.Commit();
                    objAdp.Fill(ds, strNomeTabela);
                }
                catch (Exception ex)
                {
                    objTransacao.Rollback();
                    return null;
                    throw ex;
                }

                this.Desconectar();
            }
            catch (Exception ex)
            {
                String strMsg = ex.Message;
            }

            return ds.Tables[strNomeTabela];
        }

        /// <summary>
        /// Retornar Dados Com StoredProcedure - Select
        /// </summary>
        /// <param name="strSql">Comando SQL</param>
        /// <param name="strNomeTabela">Nome da Tabela</param>
        /// <returns>Retornar um DataSet</returns>
        public DataTable RetornarDadosComStoredProcedure(String strSql, String strNomeTabela)
        {
            if (!this.Conectar())
            {
                return null;
            }

            objTransacao = objConn.BeginTransaction();
            SqlCommand objCmd = new SqlCommand(strSql, objConn); //classe que implementa um comando no SQL Server

            objCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
            DataSet ds = new DataSet();

            try
            {
                objTransacao.Commit();
                objAdp.Fill(ds, strNomeTabela);
            }
            catch (Exception ex)
            {
                objTransacao.Rollback();
                return null;
                throw ex;
            }

            this.Desconectar();

            return ds.Tables[strNomeTabela];
        }

        #endregion

        #region Métodos de Ação

        /// <summary>
        /// Executar Dados de Modificação - Update, Insert, Delete
        /// </summary>
        /// <param name="strSql">Comando SQL</param>
        /// <returns>Verdade ou Falso</returns>
        public bool ExecutarDados(string strSql)
        {
            bool blnResult = false;
            if (!this.Conectar())
            {
                return false;
            }

            objTransacao = objConn.BeginTransaction();

            SqlCommand objCmd = new SqlCommand(strSql, objConn);

            try
            {
                objTransacao.Commit();
                blnResult = (objCmd.ExecuteNonQuery() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                objTransacao.Rollback();
                blnResult = false;
                throw ex;
            }

            this.Desconectar();

            return blnResult;
        }

        /// <summary>
        /// Executar Dados de Modificação com Stored Procedure - Update, Insert, Delete
        /// </summary>
        /// <param name="strSql">Comando SQL</param>
        /// <returns>Verdade ou Falso</returns>
        public bool ExecutarDadosComStoredProcedure(string strSql)
        {
            bool blnResult = false;

            if (!this.Conectar())
            {
                return false;
            }

            objTransacao = objConn.BeginTransaction();

            SqlCommand objCmd = new SqlCommand(strSql, objConn);

            objCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                objTransacao.Commit();
                blnResult = (objCmd.ExecuteNonQuery() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                objTransacao.Rollback();
                blnResult = false;
                throw ex;
            }

            this.Desconectar();

            return blnResult;
        }

        #endregion
    }
}
