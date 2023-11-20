using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Category.Commands;

public class DeleteCategoryCommand : IRequest<(bool State, string Message )>
{
    public int CategoryId { get; set; }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, (bool State, string Message)>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteCategoryCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool State, string Message)> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstAsync(c => c.Id == request.CategoryId);

        _dbContext.Categories.Remove(category);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return (true, "OK");
    }
}