using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIProject1.CustomDataAnnotations;

namespace WebAPIProject1.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Please Enter name ...!")]
        [StringLength(15,ErrorMessage ="Please Enter Upto 15 Chars Only ...!")]
       // [RegularExpression("^[a-z]{2,}\\d*$", ErrorMessage ="Name Should be chars only ...!")]
        public string EName { get; set; }

        [Required(ErrorMessage = "Please Enter Password ...!")]
        public string Password { get; set; }


        //[Required(ErrorMessage = "Please Enter Confirm Password ...!")]
        //[Compare("Password",ErrorMessage ="Password Mismatch Happend ...!")]
       // public string CnfPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Gender ...!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number ...!")]
       [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$", ErrorMessage = " Phone Number should be digits and 10 numbers only ...!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Email address ...!")]
        [RegularExpression("(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))", ErrorMessage = " Please enter proper email address  ...!")]
        //[ExistingEmailCheck(ErrorMessage ="This Email Address Is already Exists . Please Provide New Email Address ...!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Salary ...!")]
        [RegularExpression("^[1-9][0-9]*(\\.[0-9]+)?|0+\\.[0-9]*[1-9][0-9]*$.", ErrorMessage = "  Salary Should be digits only ...!")]
        // [Range(5000,50000,ErrorMessage = "Please Enter Salary In between [Including] 5000 to  [Including] [50000]")]
        [ZeroOrNegetive(ErrorMessage ="Salary should not Accept zero And Negetive values....!")]
        [SalaryCheck(ErrorMessage ="Salary Should Between 5000 and 50000 . And It Should be divisible By 10.....!")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Address ...!")]
        public string Address { get; set; }

        [ForeignKey( "Department")]

        [Required(ErrorMessage = "Please Select Department ...!")]
        [ZeroOrNegetive(ErrorMessage ="Please Select Department.....!")]
        public int DeptNo {  get; set; }

        public Department Department { get; set; }
        


    }
}
