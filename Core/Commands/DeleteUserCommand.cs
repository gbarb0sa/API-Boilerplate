using Core.Helpers;
using Core.Models.Responses;
using MediatR;

namespace Core.Commands
{
    public class DeleteUserCommand : IRequest<Result<UserResponse>>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
