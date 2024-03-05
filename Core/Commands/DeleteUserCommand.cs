using Core.Helpers;
using MediatR;

namespace Core.Commands
{
    public class DeleteUserCommand : IRequest<Result<DeleteMessage>>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
