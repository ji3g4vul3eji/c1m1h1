namespace c1m1h1.Model
{
    internal class Game
    {
        private readonly List<Player> _players;
        private readonly Deck _deck;
        private readonly int _rounds = 13;
        private readonly List<Turn> _turns = new();

        public Game(Deck deck, IEnumerable<Player> players)
        {
            _players = players.ToList();
            _deck = deck;
            _players.ForEach(player => player.SetGame(this));
        }

        public void Start()
        {
            NamePlayers();
            _deck.Shuffle();
            DrawHands();
            Play();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GetResult());
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void NamePlayers()
        {
            for (var i = 0; i < _players.Count; i++)
            {
                _players[i].NameSelf(i);
            }
        }

        private void DrawHands()
        {
            var deckSize = _deck.GetSize();
            for (var i = 0; i < deckSize; i++)
            {
                var card = _deck.Draw();
                _players[i % _players.Count].AddToHand(card);
            }
        }

        private void Play()
        {
            for (var i = 0; i < _rounds; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Round {i+1}");
                _players.ForEach(TakeTurn);
                Showdown();
                _players.ForEach(player => player.ExchangeHands?.CountDown());
                _turns.ForEach(turn => turn.ExchangeHands?.Exchange());
                _turns.Clear();
            }
        }

        private void TakeTurn(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("It's {0}'s turn.\n", player.DisplayText);
            var turn = player.TakeTurn();
            _turns.Add(turn);
        }

        private void Showdown()
        {
            ShowCards();
            var winnerTurn = _turns.MaxBy(turn => turn.ShowCard);
            var winner = winnerTurn?.Player;
            winner?.GainPoint();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} wins this round.\n", winner?.DisplayText);
        }

        private void ShowCards()
        {
            var showCards = string.Join(" ", _turns.Select(turn => turn.ShowCard).Select(card => card.Show()));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Show cards: {0}", showCards);
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        internal string GetResult()
        {
            var player = _players.MaxBy(p => p.GetPoint());
            return $"The winner is {player?.DisplayText}!";
        }

    }
}
