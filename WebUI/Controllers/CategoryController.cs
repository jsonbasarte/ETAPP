using Application.Category.Commands;
using Application.Category.Queries;
using ETAPP.Application.Common.Models;
using ETAPP.Application.Common.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Authorize]
public class CategoryController : ApiControllerBase
{
    [HttpPost]
    public async Task<int> Create(CreateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        return await Mediator.Send(new GetAllCategoriesQuery());
    }

    [HttpPut]
    public async Task<bool> Update(UpdateCategoryCommand command)
    {
        var result = await Mediator.Send(command);

        return result;
    }

    [HttpDelete]
    public async Task<(bool State, string Message)> Delete(DeleteCategoryCommand command)
    {
        var result = await Mediator.Send(command);

        return result;
    }
}
