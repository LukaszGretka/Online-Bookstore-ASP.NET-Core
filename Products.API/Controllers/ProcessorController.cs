using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.API.Common;
using Products.API.Database;
using Products.API.Model;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessorController : Controller
    {
        private readonly ProductContext _productContext;

        public ProcessorController(ProductContext productContext)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        [HttpPost]
        [Route("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProcessorAsync([FromBody] Processor processor)
        {
            var processorItem = new Processor
            {
                Name = processor.Name,
                Description = processor.Description,
                Price = processor.Price,
                Producer = processor.Producer,
                Socket = processor.Socket,
                StandardFrequency = processor.StandardFrequency,
                TurboFrequency = processor.TurboFrequency
            };

            _productContext.Processors.Add(processorItem);
            await _productContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcessorByIdAsync), new { id = processorItem.ID }, processorItem);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Processor), (int)HttpStatusCode.OK)]
        [ActionName(nameof(GetProcessorByIdAsync))]
        public async Task<ActionResult<Processor>> GetProcessorByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(id)));
            }

            var processor = await _productContext.Processors.SingleOrDefaultAsync(item => item.ID == id);

            if (processor is null)
            {
                return NotFound();
            }

            return processor;
        }

        [HttpGet]
        [Route("producer/{producerName}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Processor), (int)HttpStatusCode.OK)]
        [ActionName(nameof(GetProcessorsByProducersAsync))]
        public async Task<ActionResult<IList<Processor>>> GetProcessorsByProducersAsync(string producerName)
        {
            if (string.IsNullOrEmpty(producerName))
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(producerName)));
            }

            var processors = await _productContext.Processors.Where(item => item.Producer.ToLower().Equals(producerName.ToLower())).ToListAsync();

            if (!processors.Any())
            {
                return NotFound();
            }

            return processors;
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateProcessorAsync([FromBody] Processor processorToUpdate)
        {
            if (processorToUpdate.ID <= 0)
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(processorToUpdate.ID)));
            }

            var processorItem = await _productContext.Processors.AsNoTracking()
                                                     .SingleOrDefaultAsync(item => item.ID == processorToUpdate.ID);

            if (processorItem is null)
            {
                return NotFound(ErrorResponse.ItemWithValueNotFound(nameof(processorItem), processorToUpdate.ID));
            }

            processorItem = processorToUpdate;
            _productContext.Processors.Update(processorItem);

            await _productContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcessorByIdAsync), new { id = processorItem.ID }, processorItem);
        }

        [Route("remove/{id:int}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteProcessorByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(id)));
            }

            var processorItem = _productContext.Processors.SingleOrDefault(item => item.ID.Equals(id));

            if (processorItem is null)
            {
               return NotFound(ErrorResponse.ItemWithValueNotFound(nameof(processorItem), id));
            }

            _productContext.Processors.Remove(processorItem);
            await _productContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
