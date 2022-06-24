namespace c1m1h1.Model
{
    internal class ExchangeHands
    {
        private int _countdown = 3;
        private readonly Player _player1;
        private readonly Player _player2;

        public ExchangeHands(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        internal void CountDown()
        {
            _countdown--;
            if (_countdown == 0)
            {
                Exchange();
            }
        }

        internal void Exchange()
        {
            (_player1.Hand, _player2.Hand) = (_player2.Hand, _player1.Hand);
            Console.ForegroundColor = ConsoleColor.Green;
            if (_player1 is Human)
            {
                Console.WriteLine("You have exchanged your hand with the player {0}.\n", _player2.DisplayText);
            }
            else
            {
                Console.WriteLine("{0} has exchanged the hand with {1}.\n", _player1.DisplayText, _player2.DisplayText);
            }
        }
    }
}