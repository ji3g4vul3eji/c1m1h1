namespace c1m1h1.Model
{
    internal class Ai : Player
    {
        public override void NameSelf(int order)
        {
            this.Id = order;
            this.Name = "AI";
        }

        protected override ExchangeHands? DecideExchangeHands()
        {
            var random = new Random();
            return random.Next(2) == 0 ? null : RandomlyExchangeHands();
        }

        private ExchangeHands RandomlyExchangeHands()
        {
            _ = this.Game ?? throw new ArgumentException(nameof(this.Game));
            var random = new Random();
            var players = this.Game.GetPlayers().Where(o => o.Id != this.Id).ToList();
            var player = players[random.Next(players.Count)];
            return new ExchangeHands(this, player);
        }

        protected override Card Show()
        {
            return Hand.Size() == 1 ? Hand.Cards[0] : Hand.Show(new Random().Next(Hand.Size()));
        }
    }
}
