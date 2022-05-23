using LibraryReact.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryReact.Services
{
    public class AuthorsServices : IAuthorsServices
    {

        public static readonly List<Author> authors = new List<Author>()
        {
            new Author {AuthorID="A101",AuthorName="Akash" },
            new Author { AuthorID = "A102", AuthorName = "Aayush"},
        };

        public async Task<IEnumerable<Author>> GetAuthors()
        {

            return authors;

        }

        public async Task<Author> GetAuthorById(string authorObj)
        {
            return authors.SingleOrDefault(c => c.AuthorID == authorObj);
        }


        public async Task<Author> CreateAuthor(Author authorObj)
        {
            authors.Add(authorObj);
            return authorObj;
        }

        public async Task<Author> UpdateAuthor(Author authorObj)
        {
            var result = authors.Find(c => c.AuthorID == authorObj.AuthorID);

            if (result != null)
            {
                result.AuthorName = authorObj.AuthorName;

                return result;
            }

            return null;

        }

        public async Task<Author> DeleteAuthor(string authorObj)
        {
            var result = authors.Find(c => c.AuthorID == authorObj);
            if (result != null)
            {
                authors.Remove(result);

            }
            return result;
        }
    }
}
