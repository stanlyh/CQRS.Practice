using CQRS.Practice.Data;
using CQRS.Practice.Infraestructure.Commands;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly DataContext _dataContext;
        public DeleteTaskHandler(DataContext dataContext) 
        { 
            _dataContext = dataContext; 
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dataContext.TaskItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return false;
            }

            _dataContext.TaskItems.Remove(taskItem);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
