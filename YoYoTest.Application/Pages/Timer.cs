using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYoTest.Library;
using YoYoTest.Library.Infrastructure;

namespace YoYoTest.Application.Pages
{
    public partial class Timer
    {
        #region variables
        private IShuttleService _service = new ShuttleService();
        public int NextLevel { get; set; }
        public int LastLevel { get; set; }
        public int LastShuttle { get; set; }
        public IEnumerable<Candidate> Candidates { get; set; }        
        public int CurrentLevel { get; set; }
        public int TotalDistance { get; set; }
        public int NextShuttle { get; set; }
        public int Shuttle { get; set; }
        public string Speed { get; set; }
        public List<int> Level = new List<int> { 5, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
        #endregion
        public async Task GetShuttlesFor(int level, int shuttle = 1)
        {
            var current = await _service.GetShuttlesFor(level, shuttle);
            var currentShuttle = current.FirstOrDefault();
            Speed = $"{currentShuttle.Speed} km/h";
            Shuttle = Convert.ToInt32(currentShuttle.ShuttleNo);
            TotalDistance = Convert.ToInt32(currentShuttle.AccumulatedShuttleDistance);
            if (level + 1 <= 23)
            {
                GetNextLevelandShuttle(level, shuttle);
                var next = await _service.GetShuttlesFor(NextLevel, NextShuttle);
                var nextShuttleStart = Convert.ToDateTime((next.FirstOrDefault().StartTime));
                nextShuttleValue = new TimeSpan(0, nextShuttleStart.Hour, nextShuttleStart.Minute);
            }
            CurrentLevel = Level[level];
        }
        
        public void TakeAction(bool isWarn, Candidate candidate)
        {
            if(isWarn)
            {
                candidate.IsWarned = true;
            }
            else
            {
                candidate.IsStopped = true;
                GetLastLevelandShuttle(Level.IndexOf(CurrentLevel), Shuttle);
                candidate.Result = $"{LastLevel} - {LastShuttle}";
                if(Candidates.All(x=> x.IsStopped == true))
                {
                    is_stopWatchRunning = false;
                    NextShuttle = 0;
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
        }        

        public void GetLastLevelandShuttle(int level, int currentShuttle)
        {
            if(level == 0)
            {
                LastLevel = Level[level];
                LastShuttle = currentShuttle;
            }    
            if (level == 1)
            {
                LastLevel = Level[level-1];
                LastShuttle = 1;
            }
            else if (level == 2)
            {
                if (currentShuttle > 1)
                {
                    LastLevel = Level[level];
                    LastShuttle = currentShuttle-1;
                }
                else if (currentShuttle < 2)
                {
                    LastLevel = Level[level-1];
                    LastShuttle = 1;
                }
            }
            else if (level == 3)
            {
                if (currentShuttle == 1)
                {
                    LastLevel = Level[level-1];
                    LastShuttle = 2;
                }
                else
                {
                    LastLevel = Level[level];
                    LastShuttle = currentShuttle-1;
                }
            }
            else if (level == 4)
            {
                if (currentShuttle ==1)
                {
                    LastLevel = Level[level-1];
                    LastShuttle = 3;
                }
                else
                {
                    LastLevel = Level[level];
                    LastShuttle = currentShuttle - 1;
                }
            }
            else
            {
                if (currentShuttle == 1)
                {
                    LastLevel = Level[level-1];
                    LastShuttle = 8;
                }
                else
                {
                    LastLevel = Level[level];
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
        
    }
}