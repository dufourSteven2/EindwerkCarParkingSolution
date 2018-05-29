using System;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingCore.ViewModels;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingLib;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace EindwerkCarParkingCore.Controllers
{
    [Route("api/[Controller]")]
    public class LocatiesController : Controller
    {
        private readonly IParkingRepository repository;
        private readonly ILogger<LocatiesController> logger;
        private readonly IMapper mapper;

        public LocatiesController(IParkingRepository repository, ILogger<LocatiesController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult get()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<Locatie>, IEnumerable<LocatieDTO>>(repository.GetAllLocaties()));
            }
            catch(Exception ex)
            {
                logger.LogError($"Failed to get Locaties: {ex}");
                return BadRequest("Failed to get Locaties");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var locatie = repository.GetLocatieById(id);
                if (locatie != null) return Ok(mapper.Map<Locatie, LocatieDTO>(locatie));
                else return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Locaties: {ex}");
                return BadRequest("Failed to get Locaties");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]LocatieDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newLocatie = mapper.Map<LocatieDTO, Locatie>(model);

                    if(newLocatie.Straat == "")
                    {
                        newLocatie.Straat = "";
                    }

                    repository.AddEntity(model);
                    if (repository.SaveAll())
                    {
                       

                        return Created($"api/locaties/{newLocatie.Id}", mapper.Map<Locatie, LocatieDTO>(newLocatie));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Locaties: {ex}");

            }
            return BadRequest("Failed to save new locatie");
        }
    }

    //[Route("api/[Controller]")]
    //public class LocatiesController : Controller
    //{
    //    private readonly IParkingRepository repository;
    //    private readonly ILogger<LocatiesController> logger;
    //    private readonly IMapper mapper;
    //    public LocatiesController(IParkingRepository repository, ILogger<LocatiesController> logger, IMapper mapper)
    //    {
    //        this.repository = repository;
    //        this.logger = logger;
    //        this.mapper = mapper;
    //    }
    //    [HttpGet]
    //    public IActionResult Get() // hier parameter toegevoegd int Id
    //    {

    //        try
    //        {

    //            return Ok(mapper.Map<IEnumerable<Locatie>, IEnumerable<LocatieDTO>>(repository.GetAllLocaties()));
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.LogError($"Failed to get Locaties: {ex}");
    //            return BadRequest("Failed to get Locaties");
    //        }
    //    }

    //    [HttpGet("{id:int}")]
    //    public IActionResult Get(int id)
    //    {
    //        try
    //        {
    //            var locatie = repository.GetLocatieById(id);
    //            if (locatie != null) return Ok(mapper.Map<Locatie, LocatieDTO>(locatie));
    //            else return NotFound();
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.LogError($"Failed to get Locaties: {ex}");
    //            return BadRequest("Failed to get Locaties");
    //        }
    //    }

    //    [HttpPost]
    //    public IActionResult Post([FromBody]Locatie model)
    //    {
    //        try
    //        {
    //            repository.AddEntity(model);
    //            if (repository.SaveAll())
    //            {
    //                return Created($"api/locaties/{model.Id}", model);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.LogError($"Failed to get Locaties: {ex}");

    //        }
    //        return BadRequest("Failed to save new locatie");
    //    }







        //[Produces("application/json")]
        //[Route("api/Locaties")]
        //public class LocatiesController : Controller
        //{
        //    private readonly EindwerkCarParkingContext _context;

        //    public LocatiesController(EindwerkCarParkingContext context)
        //    {
        //        _context = context;

        //    }

        //    // GET: api/Locaties
        //    [HttpGet]
        //    public IEnumerable<Locatie> GetLocaties()
        //    {
        //        return _context.Locaties;
        //    }

        //    // GET: api/Locaties/5
        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetLocatie([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var locatie = await _context.Locaties.SingleOrDefaultAsync(m => m.Id == id);

        //        if (locatie == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(locatie);
        //    }

        //    // PUT: api/Locaties/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutLocatie([FromRoute] int id, [FromBody] Locatie locatie)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != locatie.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(locatie).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LocatieExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Locaties
        //    [HttpPost]
        //    public async Task<IActionResult> PostLocatie([FromBody] Locatie locatie)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _context.Locaties.Add(locatie);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (LocatieExists(locatie.Id))
        //            {
        //                return new StatusCodeResult(StatusCodes.Status409Conflict);
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtAction("GetLocatie", new { id = locatie.Id }, locatie);
        //    }

        //    // DELETE: api/Locaties/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteLocatie([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var locatie = await _context.Locaties.SingleOrDefaultAsync(m => m.Id == id);
        //        if (locatie == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Locaties.Remove(locatie);
        //        await _context.SaveChangesAsync();

        //        return Ok(locatie);
        //    }

        //    private bool LocatieExists(int id)
        //    {
        //        return _context.Locaties.Any(e => e.Id == id);
        //    }
        //}
    
}