using System.ComponentModel.DataAnnotations;

namespace Commander.Models // This is the name of the project.
    { 
    public class Command // The blueprint for the Command object.
    {
        // We've set the atributes to required to state that they cannot be null.
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)] // Max length of input string
        public required string HowTo { get; set; }

        [Required]
        public required string Line { get; set; } // command line text stored in database.

        [Required]
        public required string Platform { get; set; } // app platform
    }

}