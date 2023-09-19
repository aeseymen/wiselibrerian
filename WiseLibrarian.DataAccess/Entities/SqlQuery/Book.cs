using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class Book:IDbModel
    {
        public int BookId { get; set; }
        public int BookNumber { get; set; }
        public string BookName { get; set; }
        public int BookIsbn { get; set; }
        public int BookPageCount { get; set; }
        public string BookThumbnailUrl { get; set; }
        public string BookStatus { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public int AdminId { get; set; }
       
        
        #region Implement IDbModel
        public AbstractDapperRepository Repository { get; set; }

        public void SetRepository(AbstractDapperRepository dappperRepository)
        {
            Repository = dappperRepository;
        } 
        #endregion
    }
}
