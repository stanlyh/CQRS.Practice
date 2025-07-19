using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Data;
using CQRS.Practice.Infraestructure.Commands;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly DataContext _dataContext;

        public UpdateTaskHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dataContext.TaskItems
                .FindAsync(new object[] { request.Id } ,cancellationToken);

            if (taskItem == null) {
                return null;
            }

            taskItem.Id = request.Id;
            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;

            await _dataContext.SaveChangesAsync(cancellationToken);

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
