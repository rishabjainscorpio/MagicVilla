using MagicVilla.DataStore;
using MagicVilla.Logging;
using MagicVilla.Models;
using MagicVilla.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private ILogging logger;
        private ApplicationDbContext dbContext;
        public VillaAPIController(ILogging logger, ApplicationDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            logger.Log("Getting all villas.", "info");
            return Ok(dbContext.Villas);
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                logger.Log("Getting villa with id: " + id, "error");
                return BadRequest();
            }

            var villa = dbContext.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest();
            }

            if (dbContext.Villas.FirstOrDefault(v => v.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Key Already Exists");
                return BadRequest(ModelState);
            }

            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa villa = new Villa()
            {
                Name = villaDTO.Name,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                Amenity = villaDTO.Amenity,
                Rate = villaDTO.Rate,
                ImageUrl = villaDTO.ImageUrl,
                CreatedDate = DateTime.Now
            };

            dbContext.Villas.Add(villa);
            dbContext.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villa.Id}, villaDTO);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = dbContext.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            dbContext.Villas.Remove(villa);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }

            var villa = dbContext.Villas.FirstOrDefault(v => v.Id == villaDTO.Id);
            if (villa == null)
            {
                return NotFound();
            }

            villa.Name = villaDTO.Name;
            villa.Occupancy = villaDTO.Occupancy;
            villa.Sqft = villaDTO.Sqft;
            villa.Rate = villaDTO.Rate;
            villa.ImageUrl = villaDTO.ImageUrl;
            villa.Amenity = villaDTO.Amenity;
            villa.UpdatedDate = DateTime.Now;

            dbContext.Villas.Update(villa);
            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (id == 0 || patchDTO == null)
            {
                return BadRequest();
            }

            var villa = dbContext.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            VillaDTO villaDTO = new VillaDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Amenity = villa.Amenity,
                Sqft = villa.Sqft,
                Rate = villa.Rate,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl
            };

            patchDTO.ApplyTo(villaDTO, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa model = new Villa()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Sqft = villaDTO.Sqft,
                Rate = villaDTO.Rate,
                Amenity = villaDTO.Amenity,
                ImageUrl = villaDTO.ImageUrl,
                UpdatedDate = DateTime.Now
            };

            dbContext.Villas.Update(model);
            dbContext.SaveChanges();
            return NoContent();

        }
    }
}
