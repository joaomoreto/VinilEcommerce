using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using VinilEcommerce.Domain.Commands.SellDisks;
using VinilEcommerce.Domain.Commands.UpdateTableSpotify;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById;

namespace VinilEcommerce.Controllers
{
    [Route("api/disks")]
    [ApiController]
    public class VinilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VinilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Updates the table spotify asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/spotify")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<HttpStatusCode> UpdateTableSpotifyAsync([FromBody] UpdateTableSpotifyCommand request)
        {
            await _mediator.Send(request);

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Gets the disks by genre asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/disks/genre")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<GetDisksByGenreCommandResponse> GetDisksByGenreAsync([FromQuery] GetDisksByGenreCommand request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Gets the disks by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/disks/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<GetDisksByIdCommandResponse> GetDisksByIdAsync(int id)
        {
            var request = new GetDisksByIdCommand { Id = id };
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Gets the sales by date asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/sales/date")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<GetSalesByDateCommandResponse> GetSalesByDateAsync([FromQuery] GetSalesByDateCommand request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Gets the sales by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/sales/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<GetSalesByIdCommandResponse> GetSalesByIdAsync(int id)
        {
            var request = new GetSalesByIdCommand { Id = id };
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Sells the disks asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/sales")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<HttpStatusCode> SellDisksAsync([FromBody] SellDisksCommand request)
        {
            var teste = await _mediator.Send(request);

            return HttpStatusCode.OK;
        }
    }
}