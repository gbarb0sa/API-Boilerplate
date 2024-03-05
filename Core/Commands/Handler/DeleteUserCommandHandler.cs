using AutoMapper;
using Core.Helpers;
using Core.Interfaces;
using Core.Models.Responses;
using MediatR;

namespace Core.Commands.Handler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<DeleteMessage>>
    {
        private readonly IUserService _service;

        public DeleteUserCommandHandler(IUserService service)
        {
            _service = service;
        }
        
        public async Task<Result<DeleteMessage>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var result = new Result<DeleteMessage>();

            try
            {
                var user = await _service.GetById(command.Id);
                if (user == null) { result.WithNotFound("Usuário não encontrado"); }

                var deleted = user != null && await _service.DeleteAsync(user);

                if (deleted) result.Value = new DeleteMessage("Deletado com sucesso");
            }
            catch
            {
                result.WithException("Ocorreu um erro no sistema.");
            }
            
            return result;
        }
    }
}
