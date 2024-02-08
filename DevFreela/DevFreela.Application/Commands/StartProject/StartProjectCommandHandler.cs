using DevFreela.Core.Enums;
using DevFreela.Core.Exceptions;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public StartProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project.Status == ProjectStatusEnum.InProgress) 
                throw new ProjectAlreadyStartedException();

            if (project.Status == ProjectStatusEnum.Finished) 
                throw new ProjectAlredyFinishedException();

            project.Start();

            await _projectRepository.SaveChangesAsync(project);

            return Unit.Value;
        }
    }
}
