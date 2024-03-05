using Core.Helpers;
using Core.Models.Filters;
using Core.Models.Responses;
using MediatR;

namespace Core.Queries
{
    public class GetUserQuery : IRequest<Result<IEnumerable<UserResponse>>>
    {
        public GetUserRequestFilter Filter;

        public GetUserQuery(GetUserRequestFilter filter)
        {
            Filter = filter;
        }
    }
}
