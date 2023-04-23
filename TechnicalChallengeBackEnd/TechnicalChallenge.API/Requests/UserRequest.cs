using System.ComponentModel.DataAnnotations;

namespace TechnicalChallenge.API.Requests
{
    public class UserRequest
    {
        public long? Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public short Age { get; set; }
        [Required] public string Occupation { get; set; }
    }
}
