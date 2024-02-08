using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // api/projects?query = query
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            try
            {
                var getAllProjectsQuery = new GetAllProjectsQuery(query);

                var projects = await _mediator.Send(getAllProjectsQuery);

                return Ok(projects);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
        }

        // api/projects/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                var getProject = new GetProjectByIdQuery(id);

                var projects = await _mediator.Send(getProject);

                return Ok(projects);
            }
            catch(ProjectNonExistentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new { id = id }, command);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
        }

        // api/projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] DeleteProjectCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }          
        }

        // api/projects/{id}/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
        }

        // api/projects/{id}/start
        [HttpPut("{id}/start")]
        [AllowAnonymous]
        public async Task<IActionResult> Start(int id, [FromBody] StartProjectCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);

                return NoContent();
            }
            catch(ProjectAlreadyStartedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ProjectAlredyFinishedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ProjectNonExistentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ProjectCancelledException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
            
        }

        // api/projects/{id}/finish
        [HttpPut("{id}/finish")]
        [AllowAnonymous]
        public async Task<IActionResult> Finish(int id, [FromBody] FinishProjectCommand command)
        {
            try
            {
                command.Id = id;

                var result = await _mediator.Send(command);

                if (!result)
                {
                    return BadRequest("O pagamento não pode ser processado");
                }

                return Accepted();
            }
            catch(ProjectNonExistentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ProjectAlredyFinishedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ProjectCancelledException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
            
        }
    }
}
