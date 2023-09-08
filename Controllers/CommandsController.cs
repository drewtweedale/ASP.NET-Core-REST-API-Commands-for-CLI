using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using System.Collections.Generic;
using Commander.Data;
using AutoMapper;
using Commander.Dtos;
using Azure;
using Microsoft.AspNetCore.JsonPatch;


namespace Commander.Controllers
{
    [Route("api/commands")] //Gives the base route to our controller.
    [ApiController] // Gives behaviors that will make our lives easier.
    public class CommandsController : ControllerBase
    {
        // These are simply declaring instances of our interface and AutoMapper objects.
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        // Whatever we inject via the dependency injection system, we want to assign it to _repository.

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Below are the implementations of the action result endpoints.
        // Responds to the GET command.
        [HttpGet] 
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            
            // Return output unique to .NET CORE, essentially represents a "thumbs up".
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems)); 
        }
        
        [HttpGet("{ID}", Name ="GetCommandByID")] // Responds to the GET command with an associated ID.
        public ActionResult <CommandReadDto> GetCommandByID(int ID) // The ID is then passed to this action result.
        {
            var commandItem = _repository.GetCommandByID(ID);
            
            // Check to see if the GET request returns a value.
            if(commandItem != null) 
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));               
            }
            return NotFound();
        }

        
        // POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreatedDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreatedDto); // Mapo from commandCreateDto to command object, this returns a mapped object.
            _repository.CreateCommand(commandModel); // Create a command model in the db context.
            _repository.SaveChanges(); // Save the changes so the object is created in the database.

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel); // Instead, we return a read dto.
            
            return CreatedAtRoute(nameof(GetCommandByID), new {ID = commandReadDto.ID}, commandReadDto); // This passes back the URI + 201 status (REST principle)
            //return Ok(commandReadDto); // Returns status 200
        }

        // PUT api/commands/{ID}
        [HttpPut("{ID}")]
        public ActionResult UpdateCommand(int ID, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandByID(ID);
            
            // First check to see if the model exists
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            // Map the new model to the requested one.
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            // Call the repository, even though it's empty. Best practice.
            _repository.UpdateCommand(commandModelFromRepo);

            // Save changes to the database.
            _repository.SaveChanges();

            // Return 204 status update.
            return NoContent();
        }

        // PATCH api/commands/{ID}
        [HttpPatch("{ID}")]
        public ActionResult PartialCommandUpdate(int ID, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandByID(ID);
            
            // Check to see if the model exists
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            // To apply the patch, first map the model to a dto.
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            // Then apply the patch
            patchDoc.ApplyTo(commandToPatch, ModelState);

            // Validate the new model.
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // Map the new patched dto to the one in the repository.
            _mapper.Map(commandToPatch, commandModelFromRepo);

            // Redundant command, but still best practice.
            _repository.UpdateCommand(commandModelFromRepo);

            // Save changes made to the database.
            _repository.SaveChanges();

            // Return 204 status.
            return NoContent();
        }

        // DELETE api/commands/{ID}
        [HttpDelete("{ID}")]
        public ActionResult DeleteCommand(int ID)
        {
            var commandModelFromRepo = _repository.GetCommandByID(ID);
            
             // Check to see if the model exists
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            // Delete command from the database.
            _repository.DeleteCommand(commandModelFromRepo);

            // Save changes made to the database.
            _repository.SaveChanges();

            // Returning status 204
            return NoContent();
        }
    }
}