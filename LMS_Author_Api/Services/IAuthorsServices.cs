using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;

namespace LibraryReact.Services
{
    public interface IAuthorsServices
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorById(string authorObj);
        Task<Author> UpdateAuthor(Author authorObj);
        Task<Author> CreateAuthor(Author authorObj);
        Task<Author> DeleteAuthor(string authorObj);

    }
}