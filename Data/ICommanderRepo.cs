using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo // Creating an abstract interface to act as a repository for commands.
    {
        // This SaveChanges method is required to actually save changes on the database.
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandByID(int ID);
        
        // Creating a Command object "POST"
        void CreateCommand(Command cmd);

        // Creating the command object "PUT"
        void UpdateCommand(Command cmd);

        // Creating the command object "DELETE"
        void DeleteCommand(Command cmd);
    }
}