using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.ExternalAPI;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.ValidationModel
{
   public class CarValidator:AbstractValidator<Car>
    {
        CarAPI carApi = new CarAPI();

        
        public CarValidator() {


            RuleFor(x => x).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Car model must not be empty.")
            .MustAsync(async (model,CancellationToken) => await BeInAllowedModels(model)).WithMessage("Car model doesnt exist");
            
             

          
        }

        private async Task<bool> BeInAllowedModels(Car car )
        {
            List<string> allowedModels = await carApi.CarAPICall(car.Year,car.Brand);

            return allowedModels.Contains(car.Model);
            
         
           
        }



    }
}
