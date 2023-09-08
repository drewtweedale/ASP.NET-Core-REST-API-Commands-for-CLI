namespace Commander.Dtos // This is the name of the project.
    { 
    public class CommandReadDto // Maps to our command model
    {
        public int ID { get; set; }

        public required string HowTo { get; set; }

        public required string Line { get; set; } 

        // We've commented out the "platform" feature since (suppose we don't want to show it to a client).
        // public required string Platform { get; set; } 
    }

}