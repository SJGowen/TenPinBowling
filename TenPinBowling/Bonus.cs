using System;

namespace TenPinBowling
{
    public class Bonus
    {
        private int bonuses;
        private int bonusScore;

        public int Bonuses
        {
            get { return bonuses; }
            set { bonuses = value; }
        }

        public int BonusScore
        {
            get { return bonusScore; }
            set { bonusScore = value; }
        }

        public void RecordSpare()
        {
            Bonuses = 1;
        }

        public void RecordStrike()
        {
            Bonuses = 2;
        }

        internal void DecrementBonuses()
        {
            Bonuses -= 1;
        }

        internal void RecordBonusScore(int thrownScore)
        {
            BonusScore += thrownScore;
        }
    }
}