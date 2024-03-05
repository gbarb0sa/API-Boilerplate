using Core.Helpers;
using Core.Models.Requests;
using Core.Models.Responses;
using MediatR;

namespace Core.Commands
{
    public class CreateUserCommand : IRequest<Result<UserResponse>>
    {
        public CreateUserRequest Request { get; set; }

        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;
        }
    }
}
