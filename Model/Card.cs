namespace c1m1h1.Model
{
    public class Card : IComparable<Card>
    {
        private readonly Rank _rank;

        private readonly Suit _suit;

        public Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }

        private Rank GetRank()
        {
            return _rank;
        }

        private Suit GetSuit()
        {
            return _suit;
        }

        public string Show()
        {
            return SuitDisplay(this._suit) + RankDisplay(this._rank);
        }

        public int CompareTo(Card? card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (this.GetRank() == card.GetRank())
            {
                return this.GetSuit() - card.GetSuit();
            }
            else
            {
                return this.GetRank() - card.GetRank();
            }
        }

        public enum Rank
        {
            R2 = 2,
            R3 = 3,
            R4 = 4,
            R5 = 5,
            R6 = 6,
            R7 = 7,
            R8 = 8,
            R9 = 9,
            T = 10,
            J = 11,
            Q = 12,
            K = 13,
            A = 14
        }

        public enum Suit
        {
            Club = 0,
            Diamond = 1,
            Heart = 2,
            Spade = 3
        }

        private string SuitDisplay(Suit suit)
        {
            return suit switch
            {
                Suit.Club => "♣",
                Suit.Diamond => "♦",
                Suit.Heart => "♥",
                Suit.Spade => "♠",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private string RankDisplay(Rank rank)
        {
            return rank switch
            {
                Rank.R2 => "2",
                Rank.R3 => "3",
                Rank.R4 => "4",
                Rank.R5 => "5",
                Rank.R6 => "6",
                Rank.R7 => "7",
                Rank.R8 => "8",
                Rank.R9 => "9",
                Rank.T => "T",
                Rank.J => "J",
                Rank.Q => "Q",
                Rank.K => "K",
                Rank.A => "A",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}