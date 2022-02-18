using System.Collections.Generic;

namespace TabloidCLI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public bool IsDeleted { get; set; }
        //taking BIT and converting into bool

        //Is BIT bool or Int
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
