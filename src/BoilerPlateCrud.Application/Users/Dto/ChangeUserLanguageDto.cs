using System.ComponentModel.DataAnnotations;

namespace BoilerPlateCrud.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}