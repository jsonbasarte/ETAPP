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

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>{}

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>> 
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Categories.ProjectToListAsync<CategoryDto>(_mapper.ConfigurationProvider);

        return result;
    }
}
 