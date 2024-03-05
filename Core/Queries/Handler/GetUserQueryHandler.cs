using AutoMapper;
using Core.Helpers;
using Core.Interfaces;
using Core.Models.Responses;
using MediatR;

namespace Core.Queries.Handler
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<IEnumerable<UserResponse>>>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<Result<IEnumerable<UserResponse>>> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var result = new Result<IEnumerable<UserResponse>>();

            try
            {
                var users = await _service.GetAll(query.Filter);

                var enumerable = users.ToList();
                result.Value = enumerable.Select(u => _mapper.Map<UserResponse>(u));
                result.Count = enumerable.Count;

                return result;
            }
            catch
            {
                result.WithException("Erro no sistema.");
            }

            return result;
        }
    }
}
