using System.ComponentModel.DataAnnotations;

namespace Projekt_WDC.ViewModels
{
    public class LoginWith2faViewModel
    {
        [Required(ErrorMessage = "Kod uwierzytelniający jest wymagany.")]
        [StringLength(7, ErrorMessage = "{0} musi mieć co najmniej {2} i maksymalnie {1} znaków.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Kod uwierzytelniający")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Zapamiętaj to urządzenie")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
