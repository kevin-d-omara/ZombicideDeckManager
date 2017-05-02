using System;
using System.Collections.Generic;

namespace ZombicideDeckManager
{
    /// <summary>
    /// Defines an interface for a generic deck of cards.
    /// </summary>
    /// <typeparam name="T">The type of cards in this deck.</typeparam>
    public interface IDeck<T> : IEnumerable<T> where T : class
    {
        /// <summary>
        /// Returns an iterator which reads from the top of the deck to the bottom (in draw order).
        /// </summary>
        IEnumerable<T> TopToBottom { get; }

        /// <summary>
        /// Returns an iterator which reads from the bottom of the deck to the top.
        /// </summary>
        IEnumerable<T> BottomToTop { get; }

        /// <summary>
        /// True if there are no cards in the deck, false otherwise.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Removes the top card of the deck and returns it, or null if the deck is empty.
        /// </summary>
        T Draw();

        /// <summary>
        /// Places the card on top of the deck.
        /// </summary>
        void Add(T card);

        /// <summary>
        /// Randomizes the order of all cards in the deck.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Removes all cards from the graveyard and adds them to this deck, then shuffles this deck.
        /// </summary>
        void ShuffleIn(IDeck<T> graveyard);
    }
}
