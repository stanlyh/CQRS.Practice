using CQRS.Practice.Application.DTOs;
using MediatR;

namespace CQRS.Practice.Infraestructure.Commands
{
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted) : IRequest<TaskItemDto>;

}
