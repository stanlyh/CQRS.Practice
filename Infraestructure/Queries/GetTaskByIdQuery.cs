using CQRS.Practice.Application.DTOs;
using MediatR;

namespace CQRS.Practice.Infraestructure.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskItemDto>;

}
