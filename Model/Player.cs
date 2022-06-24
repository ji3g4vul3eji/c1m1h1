namespace c1m1h1.Model
{
    internal abstract class Player
    {

        public int Id { get; protected set; }

        protected string? Name { get; set; }

        protected Game? Game { get; private set; }

        private int Point { get; set; }

        public Hand Hand { get; set; } = new();

        public ExchangeHands? ExchangeHands { get; set; }

        public string DisplayText => $"{Name} #{Id}";

        public abstract void NameSelf(int order);

        protected abstract ExchangeHands? DecideExchangeHands();

        public void SetGame(Game? game)
        {
            this.Game = game;
        }

        public void AddToHand(Card card)
        {
            Hand.AddCard(card);
        }

        public Turn TakeTurn()
        {
            ExchangeHands? exchangeHands = null;
            if (ExchangeHands == null)
            {
                exchangeHands = DecideExchangeHands();
                ExchangeHands = exchangeHands;
            }
            var turn = new Turn(this, exchangeHands, Show());
            return turn;
        }

        protected abstract Card Show();

        public void GainPoint()
        {
            Point++;
        }

        public int GetPoint()
        {
            return Point;
        }
    }
}
