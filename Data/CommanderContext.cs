using Commander.Models;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        //Use the "base" keyword to call the constructer of the derived class.
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }
        // A representation of our "command" object to our database as a DbSet.
        public DbSet<Command> Commands { get; set; }
    }
}