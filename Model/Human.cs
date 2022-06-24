namespace c1m1h1.Model
{
    internal class Human : Player
    {

        public override void NameSelf(int order)
        {
            this.Id = order;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hello Player, please tell me your name: ", order);
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                this.NameSelf(order);
            }
            else
            {
                this.Name = name;
            }
        }

        protected override ExchangeHands? DecideExchangeHands()
        {
            _ = this.Game ?? throw new ArgumentException(nameof(this.Game));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Would you like to perform hands exchange? (y/n): ");
            var answer = Console.ReadLine()?.ToLower().Trim();
            if (answer == "y")
            {
                var players = this.Game.GetPlayers().Where(o => o.Id != this.Id).ToList();
                return SelectExchangeHandsTarget(players);
            }
            else
            {
                return null;
            }
        }

        private ExchangeHands SelectExchangeHandsTarget(IEnumerable<Player> players)
        {
            var playerList = players.ToList();
            ShowPlayerChoices(playerList);
            if (!int.TryParse(Console.ReadLine(), out var targetIndex) || targetIndex >= playerList.Count || targetIndex < 0)
            {
                return SelectExchangeHandsTarget(playerList);
            }
            return new ExchangeHands(this, playerList[targetIndex]);
        }

        private void ShowPlayerChoices(IEnumerable<Player> players)
        {
            var playerList = players.Select((player, i) => $"{i}.{player.DisplayText}").ToList();
            var targets = string.Join("\n", playerList);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select the target: \n{0}", targets);
        }

        protected override Card Show()
        {
            ShowCardSelections();
            try
            {
                if (!int.TryParse(Console.ReadLine(), out var targetIndex) || targetIndex >= Hand.Size() || targetIndex < 0)
                {
                    return Show();
                }
                return Hand.Show(targetIndex);
            }
            catch (Exception)
            {
                return Show();
            }
        }

        private void ShowCardSelections()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select the card to play: ");
            var cardList = Hand.Cards.Select((card, i) => $"{i}.[{card.Show()}]");
            Console.WriteLine(string.Join(" ", cardList));
        }
    }
}
