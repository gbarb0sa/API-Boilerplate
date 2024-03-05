using AutoMapper;
using Core.Helpers;
using Core.Interfaces;
using Core.Models.Responses;
using MediatR;

namespace Core.Commands.Handler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserResponse>>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Result<UserResponse>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = new Result<UserResponse>();

            try
            {
                var user = await _service.GetById(command.Id);

                if (user == null) { result.WithNotFound("Usuário não encontrado"); }

                var userToBeUpdated = _mapper.Map(command.Request, user);

                if (userToBeUpdated != null)
                {
                    await _service.UpdateAsync(userToBeUpdated);

                    result.Value = _mapper.Map<UserResponse>(userToBeUpdated);
                }
            }
            catch
            {
                result.WithException("Ocorreu um erro no sistema.");
            }

            return result;
        }

    }
}
