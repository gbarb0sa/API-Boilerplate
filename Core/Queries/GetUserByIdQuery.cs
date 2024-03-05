using Core.Helpers;
using Core.Models.Responses;
using MediatR;

namespace Core.Queries
{
    public class GetUserByIdQuery : IRequest<Result<UserResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
