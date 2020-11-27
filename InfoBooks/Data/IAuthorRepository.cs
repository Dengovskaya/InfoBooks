using InfoBooks.Models;
using System.Linq;

namespace InfoBooks.Data
{
    public interface IAuthorRepository
    {
        Author CreateAuthor(Author author);
        Author GetAuthourById(int id);
        Author ChangeAuthour(string name, int id);
        Author GetAuthorByName(string name);
        IQueryable<Author> Authors { get; }

        void DeleteAuthor(Author author);
    }
}