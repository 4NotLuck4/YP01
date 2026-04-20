using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractWork2.Models
{
    public partial class UserCredentials : ObservableValidator
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        [MinLength(3)]
        [MaxLength(20)]
        private string? _login;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$")]
        private string? _password;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private string? _confirmPassword;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [EmailAddress]
        private string? _email;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [Phone]
        private string? _phone;

        // Валидация совпадения паролей через кастомный метод
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult(
                    "Пароли не совпадают",
                    new[] { nameof(ConfirmPassword) });
            }
        }
    }
}