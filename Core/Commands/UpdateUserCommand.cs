using Core.Helpers;
using Core.Models.Requests;
using Core.Models.Responses;
using MediatR;

namespace Core.Commands
{
    public class UpdateUserCommand : IRequest<Result<UserResponse>>
    {
        public int Id { get; set; }
        public UpdateUserRequest Request { get; set; }

        public UpdateUserCommand(int id, UpdateUserRequest request)
        {
            Id = id;
            Request = request;
        }

    }
}

