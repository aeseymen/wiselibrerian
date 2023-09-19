using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business
{
    public class BookManager
    {
        public List<BookViewModel> GetBooks()
        {
            using (var db = new DapperRepository())
            {
                var book = new Book();
                book.SetRepository(db);
                var sql = "Select * From Books";
                var booksData = book.Repository.GetAll<Book>(sql).Select(s => new BookViewModel()
                {
                    BookId = s.BookId,
                    BookName = s.BookName,
                    BookNumber = s.BookNumber,
                    BookIsbn = s.BookIsbn,
                    BookPageCount = s.BookPageCount,
                    BookStatus = s.BookStatus,
                    BookThumbnailUrl = s.BookThumbnailUrl,
                    AuthorId = s.AuthorId,
                    CategoryId = s.CategoryId,
                    MaterialTypeId = s.MaterialTypeId,
                    AdminId = s.AdminId

                }).ToList();
                return booksData;
            }
        }

        public BookViewModel GetBook(int id)
        {

            using (var db = new DapperRepository())
            {
                var book = new Book();
                book.SetRepository(db);
                var sql = "Select * From Books where BookId = @id";
                var bookData = book.Repository
                    .GetById<Book>(sql, new { id })
                    .Select(s => new BookViewModel()
                    {
                        BookId = s.BookId,
                        BookNumber = s.BookNumber,
                        BookName = s.BookName,
                        BookIsbn = s.BookIsbn,
                        BookPageCount = s.BookPageCount,
                        BookStatus = s.BookStatus,
                        BookThumbnailUrl = s.BookThumbnailUrl,
                        AuthorId = s.AuthorId,
                        CategoryId = s.CategoryId,
                        MaterialTypeId = s.MaterialTypeId,
                        AdminId = s.AdminId
                    }).FirstOrDefault();
                return bookData;

            }
        }

        public int DeleteBook(Book book)
        {
            using (var db = new DapperRepository())
            {
                book.SetRepository(db);
                var sql = $"Delete from Books where BookId = {book.BookId}";
                return book.Repository.Delete(sql);
            }
        }

        public int DeleteAllBooks()
        {
            using (var db = new DapperRepository())
            {
                var book = new Book();
                book.SetRepository(db);
                var sql = "DELETE FROM Books";
                var deletedDatas = book.Repository.DeleteAll<Book>(sql);
                return deletedDatas;
            }
        }


        public int InsertBook(Book book)
        {
            using (var db = new DapperRepository())
            {
                book.SetRepository(db);
                var sql = $"Insert into Books (BookName, BookNumber, BookIsbn, BookPageCount, BookStatus, BookThumbnailUrl, AuhorId, CategoryId, MaterialTypeId, AdminId) values ('{book.BookName}', {book.BookNumber},{book.BookIsbn}, {book.BookPageCount}, '{book.BookStatus}', '{book.BookThumbnailUrl}', {book.AuthorId}, {book.CategoryId}, {book.MaterialTypeId}, {book.AdminId})";
                return book.Repository.Insert(sql);
            }
        }

        public int UpdateBook(Book book)
        {
            using (var db = new DapperRepository())
            {
                book.SetRepository(db);
                var sql = $"Update Books set BookName='{book.BookName}', BookNumber={book.BookNumber}, BookIsbn={book.BookIsbn}, BookPageCount={book.BookPageCount}, BookStatus='{book.BookStatus}', BookThumbnailUrl='{book.BookThumbnailUrl}', AuthorId={book.AuthorId}, CategoryId={book.CategoryId}, MaterialTypeId='{book.MaterialTypeId}' Where BookId={book.BookId}";
                return book.Repository.Update(sql);
            }
        }

    }
}
    