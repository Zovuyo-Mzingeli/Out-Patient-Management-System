using OCMS03.Models.ViewModels.ClinicViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ClinicRepositories
{
    public interface IClinicRepository
    {
        Task<IEnumerable<ClinicViewModel>> AllAsync();
    }
}
