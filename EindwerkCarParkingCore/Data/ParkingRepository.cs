using EindwerkCarParkingLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Data
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly EindwerkCarParkingContext _ctx;
        private readonly ILogger<ParkingRepository> _logger;

        public ParkingRepository(EindwerkCarParkingContext ctx, ILogger<ParkingRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Parking> GetAllParkings()
        {
            try
            {
                _logger.LogInformation("GetAllParkings was called");
                //return _ctx.Parkings.ToList();
                return _ctx.Parkings
                    .Include(l => l.Locatie)
                    .Include(l => l.Eigenaar)
                    .Include(l => l.Soort)
                    .Include(l => l.Locatie.Gemeente.Land)
                    //.ThenInclude(i => i.Gemeente)
                    .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all parkings: {ex}");
                return null;
            }

        }

        public Parking GetParkingById(int id)
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Parkings.Include(p => p.Locatie)
                    .Where(p => p.Id == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Parking>GetParkingByPlace(string gemeente)
        {
            try
            {
                _logger.LogInformation("GetAllProducts by gemeente");
                return _ctx.Parkings.Where(p => p.Locatie.Gemeente.GemeenteNaam == gemeente).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }

        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
