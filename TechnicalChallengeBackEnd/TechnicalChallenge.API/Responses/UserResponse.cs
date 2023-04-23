using System.ComponentModel.DataAnnotations;

namespace TechnicalChallenge.API.Responses
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string Occupation { get; set; }
    }
}
