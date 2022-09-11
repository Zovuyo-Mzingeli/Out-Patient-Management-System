using OCMS03.Data;
using OCMS03.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.DoctorRepositories
{
    public class DoctorRepository
    {
        private readonly OCMS03_TheCollectiveContext context;
        public DoctorRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        //public async Task<IEnumerable<DoctorViewModel>> AllAsync()
        //   => await this.context
        //           .Users
        //           .Where(u => u.IsDoctor)
        //           .ProjectTo<DoctorViewModel>()
        //           .ToListAsync();
    }
}
