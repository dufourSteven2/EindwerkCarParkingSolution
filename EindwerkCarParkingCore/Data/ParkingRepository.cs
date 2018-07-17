using EindwerkCarParkingCore.Models;
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
                    .ThenInclude(i => i.Gemeente)
                    .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all parkings: {ex}");
                return null;
            }

        }

        public IEnumerable<Parking> GetAllParkingsByUser(string username)
        {
            try
            {
                _logger.LogInformation("GetAllParkings was called");
                //return _ctx.Parkings.ToList();
                return _ctx.Parkings
                    .Where(p => p.ParkingUsersName == username)
                    .Include(l => l.Locatie)
                    .Include(l => l.Eigenaar)
                    .Include(l => l.Soort)
                    .Include(l => l.Locatie.Gemeente.Land)
                    .ThenInclude(i => i.Gemeente)
                    .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all parkings: {ex}");
                return null;
            }
        }

        public IEnumerable<Parking> GetAllRegistredParkings()
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
                    .ThenInclude(i => i.Gemeente)
                    .Where(p => p.PublicatieToelating ==true)
                    .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all parkings: {ex}");
                return null;
            }

        }

        public IEnumerable<LandDTO> getLanden()
        {
            _logger.LogInformation("get all landen");
            IEnumerable<LandDTO> landen = _ctx.Lands.AsNoTracking()
                .OrderBy(l => l.LandNaam).Select(
                l => new LandDTO
                {
                    Id = l.Id,
                    LandNaam = l.LandNaam
                }).ToList();

            return landen;
        }

        public IEnumerable<Parking> GetLast5AddedParkings()
        {
            _logger.LogInformation("get 5 last added Parkings");

            return _ctx.Parkings.Include( p => p.Locatie.Gemeente)
                .OrderByDescending(p => p.Id).Take(5);
        }

        public Parking GetParkingById(int id)
        {
            try
            {
                return _ctx.Parkings.Where(p => p.Id == id)
                    .Include(l => l.Locatie)
                    .Include(s => s.Soort) //soort toegevoegd
                    .Include(l => l.Locatie.Gemeente)
                    .Include (p => p.Locatie.Gemeente.Land)
                    .FirstOrDefault();
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

        //public IEnumerable<TotaalDTO> GetTotalen()
        //{
        //    try
        //    {
        //        IEnumerable<TotaalDTO> totalen = _ctx.Totaals.Include(s => s.Soorts).Select(
        //            l => new TotaalDTO
        //            {
        //                Id = l.Id,
        //                BezetteParkings = l.BezetteParkings,
        //                MaxParkings = l.MaxParkings,
        //                SoortId = l.SoortId
        //            }
        //            ).ToList();
        //        return totalen;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get all Totalen: {ex}");
        //        return null;
        //    }
        //}

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        //IEnumerable<Parking> IParkingRepository.GetParkingById(int id)
        //{
        //    try
        //    {
        //        _logger.LogInformation("GetAllParkings was called");
        //        //return _ctx.Parkings.ToList();
        //        return _ctx.Parkings.Where(p => p.Id == id)
        //            .Include(l => l.Locatie)
        //            .Include(l => l.Eigenaar)
        //            .Include(l => l.Soort)
        //            .Include(l => l.Locatie.Gemeente.Land)
        //            //.ThenInclude(i => i.Gemeente)
        //            .ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get all parkings: {ex}");
        //        return null;
        //    }
        //}
    }
}
