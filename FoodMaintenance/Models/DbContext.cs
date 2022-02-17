using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FoodMaintenance.Models
{
    public class DbContext
    {
        #region Properties
        private SQLiteAsyncConnection Con { get; set; }
        #endregion

        #region Constructors
        public DbContext(string DbName, string DbDirectory)
        : this(Path.Combine(DbDirectory, DbName))
        {
        }
        public DbContext(string DbPath)
        {
            Con = new SQLiteAsyncConnection(DbPath);
        }
        #endregion

        #region Methods
        public async Task<SQLiteAsyncConnection> GetConnection<T>() where T : new()
        {
            await Con.CreateTableAsync<T>();
            return Con;
        }
        #endregion  
    }
}
