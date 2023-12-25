using Application.UserWallet.Commands;
using Application.UserWallet.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetAllWalletQueryDto>> GetAll()
        {
            return await Mediator.Send(new GetAllWalletQuery());
        }

        [HttpPost]
        public async Task<int> Create(CreateWalletCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<bool> Update(UpdateWalletCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<(bool State, string Message)> Delete(DeleteWalletCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
