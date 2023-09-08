using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Commander.Controllers;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo // Mock-implementation of the ICommanderRepo interface. Decouples code!
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {

            var commands = new List<Command>
            {
                // Mock-data used for implementation.
                new Command{ID= 0, HowTo = "Boil an egg", Line = "Boil water", Platform="Kettle and pan"},
                new Command{ID= 1, HowTo = "Slice bread", Line = "Get knife", Platform="Cutting board"},
                new Command{ID= 2, HowTo = "Spead Jam", Line = "Get knife and bread", Platform="Countertop"}
            };
            
            return commands; 

        }

        public Command GetCommandByID(int ID)
        {
            return new Command{ID= 0, HowTo = "Boil an egg", Line = "Boil water", Platform="Kettle and pan"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
        