using AutoMapper;
using Core.Helpers;
using Core.Interfaces;
using Core.Models.Responses;
using MediatR;

namespace Core.Queries.Handler
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var result = new Result<UserResponse>();

            try
            {
                var user = await _service.GetById(query.Id);

                if (user == null) { result.WithNotFound("Usuário não encontrado"); }

                result.Value = _mapper.Map<UserResponse>(user);
            }
            catch
            {
                result.WithException("Ocorreu um erro no sistema.");
            }

            return result;
        }
    }
}
