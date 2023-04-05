using System.ComponentModel.DataAnnotations;

namespace EMSwebapp.VIewModels
{
    public class LogInUserViewModel
    {
        //VIEW FOR LOGIN
        [Required]
        [EmailAddress] 
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Display(Name=" Remember Me")]
        public bool RememberMe { get; set; }
    }
}
