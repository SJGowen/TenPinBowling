namespace TenPinBowling
{
    internal class Frame
    {
        private int firstThrow;
        private int secondThrow;
        private Bonus bonus;

        public int FirstThrow
        {
            get { return firstThrow; }
            set { firstThrow = value; }
        }

        public int SecondThrow
        {
            get { return secondThrow; }
            set { secondThrow = value; }
        }

        public Bonus Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public Frame()
        {
            Bonus = new Bonus();
        }

        public int ScoreForFirstAndSecondThrows()
        {
            return FirstThrow + SecondThrow;
        }

        public int ScoreForFrame()
        {
            return FirstThrow + SecondThrow + Bonus.BonusScore;
        }

        public bool ValidFrame()
        {
            return FirstThrow + SecondThrow <= 10;
        }
    }
}