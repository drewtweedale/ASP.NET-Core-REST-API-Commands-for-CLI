using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        // This is an instance of our DbContext class called "context".
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd ==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList(); // This returns a list of commands from our database.
        }

        public Command GetCommandByID(int ID)
        {
            return _context.Commands.FirstOrDefault(p => p.ID == ID); // Returns the first ID that matches the given ID.
        }

        // Must call SaveChanges in order to finalize a change in the database.
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCommand(Command cmd)
        {
            // Nothing, this is taken care of through DbContext.
        }
    }
}