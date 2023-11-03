using Application.Category.Commands;
using Application.Category.Queries;
using ETAPP.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CategoryController : ApiControllerBase
{
    [HttpPost]
    public async Task<int> Create(CreateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }

    [HttpGet]
    public async Task<PaginatedList<CategoryDto>> GetAll()
    {
        return await Mediator.Send(new GetAllCategoriesQuery());
    }
}
