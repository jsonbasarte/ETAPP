
using Application.Common.Interfaces;
using ETAPP.Domain.Entities;
using MediatR;

namespace Application.Category.Commands;

public class CreateCategoryCommand: IRequest<int>
{
    public string Name { get; set; } = null;
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateCategoryCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Categories { Name = request.Name };
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
