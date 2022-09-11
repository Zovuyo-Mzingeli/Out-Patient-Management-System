using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ProfileImage
{
    public interface IUnitOfWork
    {
        void UploadImage(IFormFile file);
    }
}
