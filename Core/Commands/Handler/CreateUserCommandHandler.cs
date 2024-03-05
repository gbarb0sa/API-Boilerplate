using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Models.Responses;
using MediatR;

namespace Core.Commands.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserResponse>>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Result<UserResponse>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = new Result<UserResponse>();

            var user = _mapper.Map<User>(command.Request);

            var newUser = await _service.AddAsync(user);
            result.Value = _mapper.Map<UserResponse>(newUser);

            return result;
        }
    }
}
