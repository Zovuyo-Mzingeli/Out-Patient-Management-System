using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace OCMS03.Models.CommonMapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
