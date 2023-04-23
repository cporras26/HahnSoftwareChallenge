using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Common.Dto.ResponsesDto
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string Occupation { get; set; }
    }
}
