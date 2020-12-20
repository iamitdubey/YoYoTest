using System.Threading.Tasks;
using YoYoTest.Library.Models;

namespace YoYoTest.Library.Services
{
    interface ICandidateService
    {
        Task AddCandidate(Candidate candidate);
        Task UpdateCandidate(Candidate candidate);
    }
}
