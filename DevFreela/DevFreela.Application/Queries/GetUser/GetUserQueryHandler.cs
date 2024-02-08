using DevFreela.Application.ViewModels;
using DevFreela.Core.Exceptions;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByidAsync(request.Id);

            if (user == null) 
                throw new UserNonExistentException();

            var userViewModel = new UserViewModel(
                user.FullName,
                user.Email
                );

            return userViewModel;
        }
    }
}
