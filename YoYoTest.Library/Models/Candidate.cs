using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Library.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public bool IsWarned { get; set; }
        public bool IsStopped { get; set; }
        public string Result { get; set; }
        [JsonIgnore]
        public bool IsEditing { get; set; }
    }
}
