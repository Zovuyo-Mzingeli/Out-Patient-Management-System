using AutoMapper.QueryableExtensions;
using OCMS03.Data;
using OCMS03.Models.ViewModels.ClinicViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ClinicRepositories
{
    public class ClinicRepository
    {
        private readonly OCMS03_TheCollectiveContext context;
        public ClinicRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        //public async Task<IEnumerable<ClinicViewModel>> AllAsync()
        //    => await context
        //            .tblClinic
        //            .ProjectTo<ClinicViewModel>()
        //            .ToListAsync();
    }
}
