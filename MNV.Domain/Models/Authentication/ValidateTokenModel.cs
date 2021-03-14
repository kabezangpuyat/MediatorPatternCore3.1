namespace MNV.Domain.Models.Authentication
{
    public class ValidateTokenModel : BaseTokenModel
    {
        public string ExpiryDate { get; set; }
    }
}
