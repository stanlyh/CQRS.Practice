using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Data;
using CQRS.Practice.Domain;
using CQRS.Practice.Infraestructure.Commands;
using MediatR;
using System.Runtime.InteropServices;

namespace CQRS.Practice.Application.Handlers
{
    public class CreateTaskHandler
        : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly DataContext _dataContext;
        public CreateTaskHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description
            };

            _dataContext.TaskItems.Add(taskItem);
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
