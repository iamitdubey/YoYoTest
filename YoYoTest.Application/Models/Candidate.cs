using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Application
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
        public static List<Candidate> InitializeCandidates()
        {
            var e1 = new Candidate
            {
                CountryId = 1,
                BirthDate = new DateTime(1989, 3, 11),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                CandidateId = 1,
                FirstName = "Ashton",
                LastName = "Eaton",
                Street = "Grote Markt 1",
                IsStopped = false,
                IsWarned = false,
                Zip = "1000"
            };

            var e2 = new Candidate
            {
                CountryId = 2,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                CandidateId = 2,
                FirstName = "Bryan",
                LastName = "Clay",
                Street = "New Street",
                IsStopped = false,
                IsWarned = false,
                Zip = "2000"
            };

            var e3 = new Candidate
            {
                CountryId = 3,
                BirthDate = new DateTime(1979, 5, 16),
                City = "Antwerp",
                Email = "gilly@bethanyspieshop.com",
                CandidateId = 3,
                FirstName = "Dean",
                LastName = "Karnazes",
                Street = "New Street",
                IsStopped = false,
                IsWarned = false,
                Zip = "2000"
            };

            var e4 = new Candidate
            {
                CountryId = 3,
                BirthDate = new DateTime(1979, 5, 16),
                City = "Antwerp",
                Email = "gilly@bethanyspieshop.com",
                CandidateId = 4,
                FirstName = "Usain",
                LastName = "Bolt",
                Street = "New Street",
                IsStopped = false,
                IsWarned = false,
                Zip = "2000"
            };
            return new List<Candidate> { e1, e2, e3, e4 };
        }
    }
}
