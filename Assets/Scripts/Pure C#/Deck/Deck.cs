using System;
using System.Collections;
using System.Collections.Generic;

namespace ZombicideDeckManager.Deck
{
    /// <summary>
    /// Generic deck of cards.
    /// </summary>
    /// <typeparam name="T">The class of the cards in this deck.</typeparam>
    public class Deck<T> : IDeck<T>, IEnumerable<T> where T : class
    {
        public bool IsEmpty { get { return !(Cards.Count > 0); } }

        private List<T> Cards = new List<T>();

        /// <summary>
        /// Create an empty deck.
        /// </summary>
        public Deck() { }

        /// <summary>
        /// Create a deck with a shallow copy of the provided cards. Does not shuffle the cards.
        /// </summary>
        /// <param name="cards">Cards in reverse order (i.e. last element is top of the deck</param>
        public Deck(IList<T> cards)
        {
            Cards = new List<T>(cards);
        }
        
        /// <summary>
        /// Remove the top card of the deck and return it, or null if the deck is empty.
        /// </summary>
        public T Draw()
        {
            if (IsEmpty) { return null; }

            var endIndex = Cards.Count - 1;
            var topCard = Cards[endIndex];
            Cards.RemoveAt(endIndex);
            return topCard;
        }
        
        /// <summary>
        /// Place the card on top of the deck.
        /// </summary>
        public void Add(T card)
        {
            if (card == null)
            {
                throw new System.ArgumentNullException("Cannot add a null card to the deck.");
            }

            Cards.Add(card);
        }

        /// <summary>
        /// Randomize the order of all cards in the deck.
        /// </summary>
        public void Shuffle()
        {
            var length = Cards.Count;
            for (int i = 0; i < length; ++i)
            {
                Swap(i, i + RandomProvider.Random.Next(length - i));
            }
        }

        /// <summary>
        /// Remove all cards from the graveyard and add them to this deck, then shuffle this deck.
        /// </summary>
        public void ShuffleIn(IDeck<T> graveyard)
        {
            while (!graveyard.IsEmpty)
            {
                Cards.Add(graveyard.Draw());
            }
            Shuffle();
        }

        /// <summary>
        /// Swap the position of two cards.
        /// </summary>
        private void Swap(int indexA, int indexB)
        {
            var length = Cards.Count;
            if (indexA < 0 || indexA >= length)
            {
                throw new System.ArgumentOutOfRangeException("indexA", indexA, String.Format("The first index is out of the range [0, {0}].", length - 1));
            }
            if (indexB < 0 || indexB >= length)
            {
                throw new System.ArgumentOutOfRangeException("indexB", indexB, String.Format("The second index is out of the range [0, {0}].", length - 1));
            }

            var a = Cards[indexA];
            var b = Cards[indexB];
            var tmp = a;
            a = b;
            b = tmp;
        }



        // Enumberable<T> --------------------------------------------------------------------------

        /// <summary>
        /// Return an iterator reading from the top of the deck to the bottom (in draw order).
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var top = Cards.Count - 1;
            for (int i = top - 1; i >= 0; --i)
            {
                yield return Cards[i];
            }
        }

        /// <summary>
        /// Return an iterator reading from the top of the deck to the bottom (in draw order).
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Return an iterator reading from the top of the deck to the bottom (in draw order).
        /// </summary>
        public IEnumerable<T> TopToBottom
        {
            get { return this; }
        }

        /// <summary>
        /// Return an iterator reading from the bottom of the deck to the top.
        /// </summary>
        public IEnumerable<T> BottomToTop
        {
            get
            {
                var top = Cards.Count - 1;
                for (int i = 0; i < top; ++i)
                {
                    yield return Cards[i];
                }
            }
        }
    }
}
