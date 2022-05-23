using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Author
    {
        [Key]
        public string AuthorID { get; set; }
        public string AuthorName { get; set; }

    }
}
