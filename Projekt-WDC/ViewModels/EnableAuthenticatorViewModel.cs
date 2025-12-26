using System.ComponentModel.DataAnnotations;

namespace Projekt_WDC.ViewModels
{
    public class EnableAuthenticatorViewModel
    {
        [Required(ErrorMessage = "Kod weryfikacyjny jest wymagany.")]
        [StringLength(7, ErrorMessage = "{0} musi mieć co najmniej {2} i maksymalnie {1} znaków.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Kod weryfikacyjny")]
        public string Code { get; set; }

        public string? SharedKey { get; set; }

        public string? AuthenticatorUri { get; set; }
    }
}
