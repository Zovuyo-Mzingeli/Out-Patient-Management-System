using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OCMS03.Extensions.WebConstants;

namespace OCMS03.Extensions
{
    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataErrorMessageKey] = message;
        }
    }
}