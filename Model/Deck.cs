namespace c1m1h1.Model
{
    public class Deck
    {
        private static Deck? _deck;

        private Stack<Card> Cards { get; set; } = new();

        private Deck()
        {
            foreach (var suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (var rank in Enum.GetValues(typeof(Card.Rank)))
                {
                    Cards.Push(new Card((Card.Rank)rank, (Card.Suit)suit));
                }
            }
        }

        public static Deck GetDeck()
        {
            return _deck ??= new Deck();
        }

        public void Push(Card card)
        {
            Cards.Push(card);
        }

        public Card Draw()
        {
            return Cards.Pop();
        }

        public int GetSize()
        {
            return Cards.Count;
        }

        public void Shuffle()
        {
            var random = new Random();
            Cards = new Stack<Card>(Cards.OrderBy(_ => random.Next()));
        }
    }
}