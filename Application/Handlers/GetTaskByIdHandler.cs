using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Data;
using CQRS.Practice.Infraestructure.Queries;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {
        private readonly DataContext _dataContext;

        public GetTaskByIdHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dataContext.TaskItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null;
            }

            return new TaskItemDto 
            { 
                Id = taskItem.Id, 
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }
    }
}
