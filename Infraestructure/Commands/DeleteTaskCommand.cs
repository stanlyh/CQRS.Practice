using CQRS.Practice.Application.DTOs;
using MediatR;

namespace CQRS.Practice.Infraestructure.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
    
}
