using AutoMapper;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingLib;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Controllers
{
    [Route("api/[Controller]")]
   // [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ParkingsController : Controller
    {
        private readonly IParkingRepository repository;
        private readonly ILogger<ParkingsController> logger;
        private readonly IMapper mapper;

        public ParkingsController(IParkingRepository repository, ILogger<ParkingsController>logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.GetAllParkings());
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Parkingen: {ex}");
                return BadRequest("Failed to get Parkingen");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var parking = repository.GetParkingById(id);
                if (parking != null) return Ok(parking);
                else return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Parkingen: {ex}");
                return BadRequest("Failed to get Parkingen");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Parking model)
        {
            //add to db
            try
            {
                repository.AddEntity(model);
                if (repository.SaveAll())
                {
                    return Created($"api/parkings/{model.Id}", model);
                }



            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to save a new Parking {ex}");
            }
            return BadRequest("Failed to save new order");

        }
    }

}
