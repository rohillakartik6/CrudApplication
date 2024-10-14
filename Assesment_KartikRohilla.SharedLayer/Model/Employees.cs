using System.ComponentModel.DataAnnotations;

namespace Assesment_KartikRohilla.Model
{
    public class Employees
    {
        public int Row_Id { get; set; }
        public string? EmployeeCode { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Pan Number is Required")]
        public string PanNumber { get; set; }
        [Required(ErrorMessage = "Passport Number is Required")]
        public string PassportNumber { get; set; }
        public string? ProfileImage { get; set; }
        public string? ProfileImageBase64 { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? Gender { get; set; }
        public bool? IsActive { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Date of Joinee is Required")]
        public DateTime DateOfJoinee { get; set; }
    }
}
