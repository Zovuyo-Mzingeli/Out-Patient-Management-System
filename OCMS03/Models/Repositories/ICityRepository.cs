using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
        int CountCity(string id);
        City GetCity(string id);
        void Add(City city);
    }
}
