using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MNV.Commands;
using MNV.Core.Exceptions;
using MNV.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNV.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class _BaseController : Controller
    {
        protected readonly IMediator _mediator;

        public _BaseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ExecuteCommand(ICommand command)
        {
            try
            {
                var result = await _mediator
                    .Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.GetType() == typeof(EntityNotCreatedException))
                {
                    message = ((EntityNotCreatedException)ex).Message;
                }
                return BadRequest(new { message = message });
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ExecuteQuery(IQuery query)
        {
            try
            {
                var result = await _mediator
                    .Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.GetType() == typeof(Exception))
                    return BadRequest(new { message = ex.Message });

                if (ex.GetType() == typeof(DataNoFoundException))
                {
                    message = ((DataNoFoundException)ex).Message;
                }
                return NotFound(new { message = message });
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ExecuteCollectionQuery(CollectionQuery query)
        {
            try
            {
                var result = await _mediator
                    .Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.GetType() == typeof(Exception))
                    return BadRequest(new { message = ex.Message });

                if (ex.GetType() == typeof(EntityNotFoundException))
                {
                    message = ((EntityNotFoundException)ex).Message;
                }
                return NotFound(new { message = message });
            }
        }
    }
}
