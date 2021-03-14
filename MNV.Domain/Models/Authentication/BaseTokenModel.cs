using System.ComponentModel.DataAnnotations;

namespace MNV.Domain.Models.Authentication
{
    public class BaseTokenModel
    {
        [Required]
        public string Token { get; set; }
    }
}
