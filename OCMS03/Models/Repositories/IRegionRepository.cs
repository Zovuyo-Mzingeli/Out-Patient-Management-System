using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<District> GetRegions();
        int CountRegion(string id);
        District GetRegion(string id);
        void Add(District region);
    }
}
