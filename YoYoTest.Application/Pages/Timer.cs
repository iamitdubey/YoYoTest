using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYoTest.Library;

namespace YoYoTest.Application.Pages
{
    public partial class Timer
    {
        ShuttleService service = new ShuttleService();

        public async Task GetShuttlesFor(int level, int shuttle = 1)
        {
            if (level > 0)
            {
                TotalDistance += 40;
            }
            var current = await service.GetShuttlesFor(level, shuttle);
            Speed = $"{current.FirstOrDefault().Speed} km/h";
            Shuttle = Convert.ToInt32(current.FirstOrDefault().ShuttleNo);
            if (level + 1 <= 23)
            {
                GetNextLevelandShuttle(level, shuttle);
                var next = await service.GetShuttlesFor(NextLevel, NextShuttle);
                var nextShuttleStart = Convert.ToDateTime((next.FirstOrDefault().StartTime));
                nextShuttleValue = new TimeSpan(0, nextShuttleStart.Hour, nextShuttleStart.Minute);
            }
            CurrentLevel = Level[level];
        }

        public IEnumerable<Candidate> Candidates { get; set; }

        public void TakeAction(bool isWarn, Candidate candidate)
        {
            if(isWarn)
            {
                candidate.IsWarned = true;
            }
            else
            {
                candidate.IsStopped = true;
                GetLastLevelandShuttle(CurrentLevel, Shuttle);
                candidate.Result = $"{LastLevel} - {LastShuttle}";
                if(Candidates.All(x=> x.IsStopped == false))
                {
                    is_stopWatchRunning = false;
                }
            }

        }

        private void EnableEditing(bool flag, Candidate instanceData)
        {
            instanceData.IsEditing = flag;
        }

        private void UpdateInstance(Candidate instanceData)
        {
            EnableEditing(false, instanceData);

            //call the repository to update the instance here.
            //show toast after done.
        }

        private void InitializeCandidates()
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
                CandidateId = 2,
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
                CandidateId = 2,
                FirstName = "Usain",
                LastName = "Bolt",
                Street = "New Street",
                IsStopped = false,
                IsWarned = false,
                Zip = "2000"
            };
            Candidates = new List<Candidate> { e1, e2, e3, e4 };
        }

        public void GetLastLevelandShuttle(int level, int currentShuttle)
        {
            if(level == 0)
            {
                LastLevel = level;
                LastShuttle = currentShuttle;
            }    
            if (level == 1)
            {
                LastLevel = level - 1;
                LastShuttle = 1;
            }
            else if (level == 2)
            {
                if (currentShuttle > 1)
                {
                    LastLevel = level;
                    LastShuttle = currentShuttle-1;
                }
                else if (currentShuttle < 2)
                {
                    LastLevel = level-1;
                    LastShuttle = 1;
                }
            }
            else if (level == 3)
            {
                if (currentShuttle == 1)
                {
                    LastLevel = level-1;
                    LastShuttle = 2;
                }
                else
                {
                    LastLevel = level;
                    LastShuttle = currentShuttle-1;
                }
            }
            else if (level == 4)
            {
                if (currentShuttle ==1)
                {
                    LastLevel = level-1;
                    LastShuttle = 3;
                }
                else
                {
                    LastLevel = level;
                    LastShuttle = currentShuttle - 1;
                }
            }
            else
            {
                if (currentShuttle == 1)
                {
                    LastLevel = level-1;
                    LastShuttle = 8;
                }
                else
                {
                    LastLevel = level;
                    LastShuttle = currentShuttle -1;
                }
            }
        }

        public void GetNextLevelandShuttle(int level, int currentShuttle)
        {
            if (level == 0 || level == 1)
            {
                NextLevel = level + 1;
                NextShuttle = 1;
            }
            else if (level == 2)
            {
                if (currentShuttle == 1)
                {
                    NextLevel = level;
                    NextShuttle = 2;
                }
                else if (currentShuttle == 2)
                {
                    NextLevel = level + 1;
                    NextShuttle = 1;
                }
            }
            else if (level == 3)
            {
                if (currentShuttle < 3)
                {
                    NextLevel = level;
                    NextShuttle += 1;
                }
                else
                {
                    NextLevel = level + 1;
                    NextShuttle = 1;
                }
            }
            else if (level == 4)
            {
                if (currentShuttle < 4)
                {
                    NextLevel = level;
                    NextShuttle += 1;
                }
                else
                {
                    NextLevel = level + 1;
                    NextShuttle = 1;
                }
            }
            else
            {
                if (currentShuttle < 8)
                {
                    NextLevel = level;
                    NextShuttle += 1;
                }
                else
                {
                    NextLevel = level + 1;
                    NextShuttle = 1;
                }
            }
        }
        public int NextLevel { get; set; }
        public int LastLevel { get; set; }
        public int LastShuttle { get; set; }

        public List<int> Level = new List<int> { 5, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

        public int CurrentLevel { get; set; }
        public int TotalDistance { get; set; }
        public string TotalTime { get; set; }
        public int NextShuttle { get; set; }
        public string SpeedLevel { get; set; }
        public int Shuttle { get; set; }
        public string Speed { get; set; }
    }
}
