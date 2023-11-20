using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Category.Commands;

public class UpdateCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateCategoryCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstAsync(d => d.Id == request.Id);

        category.Name = request.Name;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}