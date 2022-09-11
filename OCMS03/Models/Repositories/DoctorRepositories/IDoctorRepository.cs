using OCMS03.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.DoctorRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorViewModel>> AllAsync();
    }
}
