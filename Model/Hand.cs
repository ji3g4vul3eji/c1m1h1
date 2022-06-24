namespace c1m1h1.Model
{
    internal class Hand
    {
        public List<Card> Cards { get; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            if (Cards.Count >= 13)
            {
                throw new Exception("The hand's size must not exceed 13.");
            }
            Cards.Add(card);
        }

        private Card Get(int index)
        {
            return Cards.ElementAt(index);
        }

        public Card Show(int index)
        {
            var card = Get(index);
            Cards.RemoveAt(index);
            return card;
        }

        public int Size()
        {
            return Cards.Count;
        }
    }
}