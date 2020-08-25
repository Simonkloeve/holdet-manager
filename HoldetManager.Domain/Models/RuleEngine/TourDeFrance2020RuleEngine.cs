using System;
namespace HoldetManager.Models.RuleEngine
{
    public class TourDeFrance2020RuleEngine : IRuleEngine
    {
        
        public double CalculateIndividualGrowth(StageResult result)
        {
            var growth = 0.0;
            //Stage placement
            growth += CalculateStagePlacementBonus(result);

            //Overall classification
            growth += CalculateOverallClassificationBonus(result);

            //Jerseybonus
            growth += CalculateJerseyBonus(result);

            //Red number
            growth += CalculateRedNumberBonus(result);

            //Late arrival
            growth += CalculateLateArrivalPenalty(result);

            //Sprint/mountain points
            growth += CalculateSprintAndMountainPointsBonus(result);

            //Team time trial
            growth += CalculateTeamTimeTrialBonus(result);
            
            return growth;
        }

        private static double CalculateStagePlacementBonus(StageResult result)
        {
            //Not applicable if team time trial or DNF
            if (!result.RiderCompletedStage ||
                result.StageType == StageTypeEnum.TeamTimeTrial)
                return 0;

            return result.StagePosition <= StagePlacementBonusInThousands.Length
                ? StagePlacementBonusInThousands[result.StagePosition - 1] * 1000
                : 0;
        }

        private static double CalculateOverallClassificationBonus(StageResult result)
        {
            //Not applicable if DNF
            if (!result.RiderCompletedStage)
                return 0;

            return result.ClassificationAfterStage <= OverallPalcementBonusInThousands.Length
                ? OverallPalcementBonusInThousands[result.ClassificationAfterStage - 1] * 1000
                : 0;
        }

        private static double CalculateJerseyBonus(StageResult result)
        {
            //Not applicable if DNF
            if (!result.RiderCompletedStage)
                return 0;

            var bonus = 0.0;

            //Yellow
            bonus += result.ClassificationAfterStage == 1 ? 25000 : 0;

            //Green
            bonus += result.IsInGreen ? 25000 : 0;

            //Polka dots
            bonus += result.IsInPolkaDots ? 25000 : 0;

            //White
            bonus += result.IsInWhite ? 15000 : 0;

            return bonus;
        }

        private static double CalculateRedNumberBonus(StageResult result)
        {
            //Not applicable if DNF
            if (!result.RiderCompletedStage)
                return 0;

            return result.HasRedStartNumber
                ? 50000 : 0;
        }

        private static double CalculateLateArrivalPenalty(StageResult result)
        {
            if(!result.RiderStartedStage)            
                return 100000;
            

            if (!result.RiderCompletedStage)
                return 150000;

            if (result.StageType == StageTypeEnum.TeamTimeTrial)
                return 0;

            var penalty = 3000 * (int) result.TimeDiffToWinner.TotalMinutes;

            return penalty < 90000 ? -penalty : -90000;
        }

        private static double CalculateSprintAndMountainPointsBonus(StageResult result)
        {
            //Not applicable if DNF
            if (!result.RiderCompletedStage)
                return 0;

            return 3000 * (result.MountainPoints + result.SprintPoints);
        }

        private static double CalculateTeamTimeTrialBonus(StageResult result)
        {
            //Not applicable if DNF
            if (!result.RiderCompletedStage || result.StageType != StageTypeEnum.TeamTimeTrial)
                    return 0;

            return result.StagePosition <= TeamTimeTrialBonusInThousands.Length
                ? TeamTimeTrialBonusInThousands[result.StagePosition - 1] * 1000
                : 0;
        }

        private static readonly int[] StagePlacementBonusInThousands = new int[15] { 200, 150, 130, 120, 110, 100, 95, 90, 85, 80, 70, 55, 40, 30, 15 };

        private static readonly int[] OverallPalcementBonusInThousands = new int[10] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };

        private static readonly int[] TeamTimeTrialBonusInThousands = new int[5] { 200, 150, 100, 50, 25 };
    }
}
