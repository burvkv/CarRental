using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //bu methoda bir validator gelecek(carvalidator vb.) ve bir de entity gelecek. Fakat bu entity Dto da IEntity de olabileceği için object verdik.
        public static void Validate(IValidator validator, object entity)
        {
            // bir validationcontext instance'ı oluşturuyoruz. bu context object türündeki entity ile çalışacak.
            var context = new ValidationContext<object>(entity);

            //parametre ile gelen validatore contextimizdeki objeyi göndererek validate ediyoruz.
            var result = validator.Validate(context);

            //eğer validate sonucu false döndüyse validatordeki erroru göreceğiz.
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
