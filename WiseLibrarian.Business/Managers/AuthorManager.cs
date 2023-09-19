using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business
{
    public class AuthorManager
    {
        public List<AuthorViewModel> GetAuthors() 
        {
            using (var db = new DapperRepository())
            {
                var author = new Author();
                author.SetRepository(db);
                var sql = "Select * From Authors";
                var authorsData = author.Repository.GetAll<Author>(sql).Select(s => new AuthorViewModel() 
                { 
                    AuthorId = s.AuthorId,
                    AuthorFirstName = s.AuthorFirstName,
                    AuthorLastName = s.AuthorLastName,
                    AuthorFullName = s.AuthorFullName
                }).ToList();
                return authorsData;
            }
        }

        public AuthorViewModel GetAuthor(int id)
        {
            using (var db = new DapperRepository())
            {
                var author = new Author();
                author.SetRepository(db);
                var sql = "Select * From Authors where AuthorId = @id";
                var authorData = author.Repository
                    .GetById<Author>(sql, new { id })
                    .Select(s => new AuthorViewModel() 
                { 
                   AuthorId= s.AuthorId,
                   AuthorFirstName = s.AuthorFirstName,
                   AuthorLastName = s.AuthorLastName   

                }).FirstOrDefault();
                return authorData;
            }
        }

        public int DeleteAuthor(Author author)
        {
            using (var db = new DapperRepository())
            {
                author.SetRepository(db);
                var sql = $"Delete from Authors where AuthorId ='{author.AuthorId}'";
                return author.Repository.Delete(sql);
            }
        }

        public int DeleteAllAuthors()
        {
            using (var db = new DapperRepository())
            {
                var author = new Author();
                author.SetRepository(db);
                var sql = "DELETE FROM Authors";
                var deletedDatas = author.Repository.DeleteAll<Author>(sql);
                return deletedDatas;
            }
        }

        public int InsertAuthor(Author author)
        {
            using (var db = new DapperRepository())
            {
                author.SetRepository(db);
                var sql = $"Insert into Authors (AuthorFirstName, AuthorLastName) values ('{author.AuthorFirstName}','{author.AuthorLastName}'";
                return author.Repository.Insert(sql);
            }
        }

        public int UpdateAuthor(Author author)
        {
            using (var db = new DapperRepository())
            {
                author.SetRepository(db);
                var sql = $"Update Authors set AuthorFirstName='{author.AuthorFirstName}', AuthorLastName='{author.AuthorLastName}' where AuthorId={author.AuthorId}";
                return author.Repository.Update(sql);
            }
        }

    }
}
