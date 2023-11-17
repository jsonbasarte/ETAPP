using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ETAPP.Application.Common.Mappings;
using ETAPP.Application.Common.Models;
using ETAPP.Domain.Entities;
using MediatR;


namespace Application.Category.Queries;

public class CategoryDto : IMapFrom<Categories>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetAllCategoriesQuery : IRequest<PaginatedList<CategoryDto>>
{
    //public string? Name { set; get; }
    //public int Page { set; get; }
    //public int PageSize { set; get; }
}
public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PaginatedList<CategoryDto>> 
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Categories> q = _dbContext.Categories;

        return await q.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).PaginatedListAsync(1, 50);
    }
}
 