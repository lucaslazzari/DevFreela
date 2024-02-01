using Devfreela.Infrastructure.Persistence;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (user == null) return null;

            var userViewModel = new UserViewModel(
                user.FullName,
                user.Email
                );

            return userViewModel;
        }
    }
}
