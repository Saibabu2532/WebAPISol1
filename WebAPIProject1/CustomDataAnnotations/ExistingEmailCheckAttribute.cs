using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPIProject1.DataAccess.IRepository;

namespace WebAPIProject1.CustomDataAnnotations
{
    public class ExistingEmailCheckAttribute :ValidationAttribute
    {
            public IEmpRepository IEmpRef;
            public ExistingEmailCheckAttribute(IEmpRepository _empRef)
            {
                IEmpRef = _empRef;
            }
            public override bool IsValid(object value)
            {
                bool flag = true;
                string emailVal = value.ToString();

                // Write a logic check email is already available or not 

            var Emp = IEmpRef.GetEmployeeByOnlyEmail(emailVal);

            if (Emp != null) 
            {
            flag = false;
            }
            return flag;
            }
        }
    }

