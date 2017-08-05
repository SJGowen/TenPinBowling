using System;

namespace TenPinBowling
{
    internal class Game
    {
        Frame[] Frames = new Frame[10];
        bool isFirstThrow = true;
        int Frame = 0;

        public Game()
        {
            for (var frame = 0; frame < 10; frame++)
            {
                Frames[frame] = new Frame();
            }
        }

        internal void Thrown(int thrownScore)
        {
            if (thrownScore < 0 || thrownScore > 10)
            {
                throw new ArgumentException($"Thrown has been called with a parameter of {thrownScore} (valid is 0..10).");
            }
            RecordBonusScores(thrownScore);
            if (Frame < 10)
            {
                RecordScore(thrownScore);
                RecordAllowableBonuses(thrownScore);
                if (thrownScore != 10)
                {
                    isFirstThrow = !isFirstThrow;
                }

                if (isFirstThrow)
                {
                    Frame += 1;
                }
            }
        }

        private void RecordAllowableBonuses(int thrownScore)
        {
            if (thrownScore == 10)
            {
                // Player has thrown a Strike
                Frames[Frame].Bonus.RecordStrike(); // Player gets bonus of next two throws 
            }
            else if (Frames[Frame].ScoreForFirstAndSecondThrows() == 10)
            {
                // Player has thrown a Spare
                Frames[Frame].Bonus.RecordSpare(); // Player gets bonus of next throw
            }
        }

        private void RecordScore(int thrownScore)
        {
            if (isFirstThrow)
            {
                Frames[Frame].FirstThrow = thrownScore;
            }
            else
            {
                Frames[Frame].SecondThrow = thrownScore;
            }
        }

        private void RecordBonusScores(int thrownScore)
        {
            // Go back two frames from current frame, and check for bonus shots
            for (var frame = Math.Max(Frame - 2, 0); frame < Frame; frame++)
            {
                if (Frames[frame].Bonus.Bonuses > 0)
                {
                    Frames[frame].Bonus.DecrementBonuses();
                    Frames[frame].Bonus.RecordBonusScore(thrownScore);
                }
            }
        }

        internal int ScoreForFrame(int frame)
        {
            return Frames[frame].ScoreForFrame();
        }

        internal int TotalScore()
        {
            var Score = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                Score += ScoreForFrame(frame);
            }
            return Score;
        }

        internal bool ValidateFrames()
        {
            var ValidFrames = true;
            for (var frame = 0; frame < 10; frame++)
            {
                if (!Frames[frame].ValidFrame())
                {
                    Console.WriteLine($"The {frame} frame (0..9), is invalid...\n" +
                        $"For the first throw a score of {Frames[frame].FirstThrow} is recorded.\n" +
                        $"For the second throw a score of {Frames[frame].SecondThrow} is recorded.\n" +
                        $"(first and second throws should never sum to a value exceeding 10.)\n");
                    ValidFrames = false;
                }
            }
            return ValidFrames;
        }
    }
}