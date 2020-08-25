using System;

namespace HoldetManager.Models
{
    public class StageResult
    {
        public long RiderId { get; }
        public int StagePosition { get; }
        public int ClassificationAfterStage { get; }
        public bool RiderStartedStage { get;  }
        public bool RiderCompletedStage { get; }
        public TimeSpan Time { get; }
        public TimeSpan TimeDiffToWinner { get; }
        public int SprintPoints { get; }
        public int MountainPoints { get; }
        public int BonusSeconds { get; }
        public StageTypeEnum StageType { get; }
        public bool IsInGreen { get; }
        public bool IsInPolkaDots { get; }
        public bool IsInWhite { get; }
        public bool HasRedStartNumber { get; }

        public StageResult()
        {
            
        }




    }
}
