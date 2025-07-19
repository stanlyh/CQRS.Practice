using CQRS.Practice.Application.DTOs;
using MediatR;
using System.Collections.Specialized;

namespace CQRS.Practice.Infraestructure.Commands
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;

}
