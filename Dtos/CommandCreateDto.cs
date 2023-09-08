using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos // This is the name of the project.
    { 
    public class CommandCreateDto // Maps to our command model
    {
        // We don't require an ID for the CreateDto object, since the ID is created by the database.
        //public int ID { get; set; }
        [Required]
        [MaxLength(250)] // Max length of input string
        public required string HowTo { get; set; }

        [Required]
        public required string Line { get; set; } 
        
        [Required]
        public required string Platform { get; set; } 
    }

}