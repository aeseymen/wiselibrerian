using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using WiseLibrarian.DataAccess.Entities.Interface;

namespace WiseLibrarian.DataAccess.Entities.Repository
{

    public abstract class AbstractDapperRepository : IDisposable
    {
        #region Connection Information
        // using System data kütühanesi eklenmeli.
        public readonly IDbConnection dbConnection;

        // Proporties and Methods
        // protected çünkü her yerden ulaşılmasın
        protected AbstractDapperRepository()
        {
            //add System.ConfigurationManager
            dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["WiseLibrarianModel"].ConnectionString);
        }

        protected AbstractDapperRepository(string connectionName)
        {
            // web configden connection string değerini alıcak
            dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
        }

        public AbstractDapperRepository(IDbConnection dbConnection)
        {

        }
        #endregion


        #region Crud Operations
        //Crud
        // add using WiseLibrarian.DataAccess.Entities.Interface;

        public int Insert(string sqlQuery, object param = null)
        {
            int result = 0;
            try
            {
                //add using Dapper;
                result = dbConnection.Execute(sqlQuery, param);
            }
            catch (Exception ex)
            {

                // ToDo log
            }
            return result;
        }
        //sql query'i çağırmak için where kısmını oluşturduk 
        public IEnumerable<TEntity> GetAll<TEntity>(string sqlQuery) where TEntity : IDbModel
        {
            try
            {
                return dbConnection.Query<TEntity>(sqlQuery).ToList();
            }
            catch (Exception ex)
            {
                //ToDo log
                return null;
            }
        }

        public IEnumerable<TEntity> GetById<TEntity>(string sqlQuery, object parameters) where TEntity : IDbModel
        {
            try
            {
                return dbConnection.Query<TEntity>(sqlQuery, parameters).ToList();
            }
            catch (Exception ex)
            {

                //ToDo log
                return null;
            }
        }

        public int Update(string sqlQuery)
        {
            int result = 0;

            try
            {
              result = dbConnection.Execute(sqlQuery);
            }
            catch (Exception ex)
            {
                //ToDo log               
            }
            return result;
        }

        public int Delete(string sqlQuery)
        {

            int result = 0;
            try
            {
               result = dbConnection.Execute(sqlQuery);
            }
            catch (Exception ex)
            {
                //ToDo log                
            }
            return result;
        }

        public int DeleteAll<TEntity>(string sqlQuery) where TEntity : IDbModel
        {
            try
            {
              int  affectedRows = dbConnection.Execute(sqlQuery);
                return affectedRows;
            }
            catch (Exception ex)
            {
                //ToDo log
                return -1;      
            }
        }



        #endregion


        #region Execute

        public void ExecuteNonQuery(string sqlQuery, object parameter)
        {
            try
            {
                dbConnection.Execute(sqlQuery, parameter);
            }
            catch (Exception ex)
            {

                //ToDo log
            }
        }

        public void ExecuteNonQuery(string sqlQuery)
        {
            try
            {
                dbConnection.Execute(sqlQuery);
            }
            catch (Exception ex)
            {
                //ToDo log                
            }
        }

        public int Execute(string sqlQuery, object parameter)
        {
            try
            {
                return dbConnection.ExecuteScalar<int>(sqlQuery, parameter);
            }
            catch (Exception ex)
            {
                // ToDo log
                return -1;
            }
        }

        public object Execute<T>(String sqlQuery, object parameter)
        {
            try
            {
                return dbConnection.ExecuteScalar<T>(sqlQuery, parameter);
            }
            catch (Exception ex)
            {
                //ToDo log
                return null;
            }
        }

        #endregion


        #region Dispose işlemleri
        // Virtual dispose method action DONE => İşlemlerin bittiği yer #Garbage Collector#
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
                dbConnection?.Dispose();
        }

        //dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
