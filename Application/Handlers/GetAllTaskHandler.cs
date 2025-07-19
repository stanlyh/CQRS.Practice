using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Data;
using CQRS.Practice.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practice.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDto>>
    {
        private readonly DataContext _dataContext;

        public GetAllTaskHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dataContext.TaskItems.ToListAsync(cancellationToken);

            return tasks.Select(task => new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
