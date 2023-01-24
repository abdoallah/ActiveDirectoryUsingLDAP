using System.ComponentModel.DataAnnotations;

namespace ActiveDirectoryTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}