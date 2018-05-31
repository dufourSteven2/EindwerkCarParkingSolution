using System.Collections.Generic;
using System.Threading.Tasks;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingLib;

namespace EindwerkCarParkingCore.Data
{
    public interface IParkingRepository
    {
        //deze interface is voor het testen zodanig we statische gegevens testen en niet tegen de database zelf (beter overzicht over query's en testen)
        IEnumerable<LandDTO> getLanden();
        IEnumerable<Parking> GetAllRegistredParkings();
        IEnumerable<Parking> GetLast5AddedParkings();
        IEnumerable<Parking> GetAllParkings();
        IEnumerable<Parking> GetParkingByPlace(string gemeente);
        IEnumerable<Parking> GetAllParkingsByUser(string username);
        Parking  GetParkingById(int id);

        //methods 
       void AddEntity(object model);
        bool SaveAll();
      
    }
}