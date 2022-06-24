namespace c1m1h1.Model
{
    internal class Turn
    {
        public Player Player { get; }

        public ExchangeHands? ExchangeHands { get; }

        public Card ShowCard { get; }

        public Turn(Player player, ExchangeHands? exchangeHands, Card showCard)
        {
            Player = player;
            ExchangeHands = exchangeHands;
            ShowCard = showCard;
        }
    }
}
