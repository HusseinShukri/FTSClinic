using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace PatientRegistrySystem.API.ControllersHelper
{
    public static class ErrorsResult
    {
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToString();
        }
        public static string GetErrors(this IdentityResult result)
        {
            string e = "";
            foreach (var error in result.Errors)
            {
                e +=  error.Description + "\n";
            }
            return e;
        }
    }
}
