using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solutions.Day02
{
    public class Day02Solution
    {
        public int GetRockPaperScissorsResult()
        {
            //A = Rock
            //B = Paper
            //C = Scissors

            var fileContents = Helpers.ReadEmbeddedFile(2, "Input.txt");
            var lines = Regex.Split(fileContents, "\r\n");

            var rpsTurns = lines.Select(_ =>
                {
                    var (opponent, player, _) = _.Split(' ');
                    return (Opponent: opponent, Player: player);
                })
                .Select(_ => (Opponent: MapToRps(_.Opponent), Player: MapToRps(_.Player)));
            var totalScore = 0;

            foreach (var rpsTurn in rpsTurns)
            {
                
                var turnResult = GetTurnResult(rpsTurn.Opponent, rpsTurn.Player);
                var score = GetScore(rpsTurn.Player, turnResult);

                //Console.WriteLine($"{rpsTurn.Opponent} vs {rpsTurn.Player} : {turnResult} : {score}");
                totalScore += score;
            }

            Console.WriteLine($"Total Score: {totalScore}");

            return totalScore;
        }

        private static int GetScore(Rps player, TurnResult turnResult)
        {
            //X = Rock -     1 Points
            //Y = Paper -    2 Points
            //Z = Scissors - 3 Points
            var score = (int)player;

            //Lost = 0 points
            //Draw = 3 points
            //Won = 6 points
            switch (turnResult)
            {
                case TurnResult.OpponentWins:
                    return score + 0;
                case TurnResult.Draw:
                    return score + 3;
                case TurnResult.PlayerWins:
                    return score + 6;
                default:
                    throw new InvalidOperationException("Couldn't calculate score due to unknown result.");
            }
        }

        public TurnResult GetTurnResult(Rps opponent, Rps player)
        {
            if (opponent == player)
                return TurnResult.Draw;

            if (opponent == Rps.Rock && player == Rps.Paper)
                return TurnResult.PlayerWins;
            else if (opponent == Rps.Rock && player == Rps.Scissors)
                return TurnResult.OpponentWins;
            else if (opponent == Rps.Paper && player == Rps.Rock)
                return TurnResult.OpponentWins;
            else if (opponent == Rps.Paper && player == Rps.Scissors)
                return TurnResult.PlayerWins;
            else if (opponent == Rps.Scissors && player == Rps.Rock)
                return TurnResult.PlayerWins;
            else if (opponent == Rps.Scissors && player == Rps.Paper)
                return TurnResult.OpponentWins;
            else
                throw new InvalidOperationException("Could not determine the outcome.");
        }

        public Rps MapToRps(string rps)
        {
            switch (rps.ToUpper())
            {
                case "A":
                case "X":
                    return Rps.Rock;
                case "B":
                case "Y":
                    return Rps.Paper;
                case "C":
                case "Z":
                    return Rps.Scissors;
            }

            throw new InvalidOperationException("Unable to parse turn");
        }
    }

    public enum TurnResult
    {
        PlayerWins,
        OpponentWins,
        Draw
    }

    public enum Rps
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}
