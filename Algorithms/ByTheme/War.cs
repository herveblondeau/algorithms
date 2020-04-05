using System;
using System.Collections.Generic;

public class War
{
    // Returns a tuple:
    // - winner: 0 if PAT, player number otherwise
    // - number of rounds played
    public (int, int) Play(Queue<int> p1Deck, Queue<int> p2Deck)
    {
        int nbRounds = 0;
        bool isWar = false;

        // Keep track of the cards at stake, dealt by each player during a fight (battle or war)
        Queue<int> p1FightCards = new Queue<int>();
        Queue<int> p2FightCards = new Queue<int>();

        while (true)
        {
            // War
            if (isWar)
            {
                // Run out of cards during a war => PAT
                if (p1Deck.Count < 4 || p2Deck.Count < 4)
                {
                    return (0, nbRounds);
                }

                // Deal 3 cards into the war pile
                for (int i = 0; i < 3; i++)
                {
                    p1FightCards.Enqueue(p1Deck.Dequeue());
                    p2FightCards.Enqueue(p2Deck.Dequeue());
                }
            }
            // Battle
            else
            {
                // Run out of cards during a battle => other player's victory
                if (p1Deck.Count == 0)
                {
                    return (2, nbRounds);
                }
                else if (p2Deck.Count == 0)
                {
                    return (1, nbRounds);
                }

                // 
                nbRounds++;
            }

            // Compare each player's next card
            int p1Card = p1Deck.Dequeue();
            int p2Card = p2Deck.Dequeue();
            p1FightCards.Enqueue(p1Card);
            p2FightCards.Enqueue(p2Card);
            if (p1Card > p2Card)
            {
                isWar = false;
                p1Deck.Enqueue(p1FightCards);
                p1Deck.Enqueue(p2FightCards);
            }
            else if (p2Card > p1Card)
            {
                isWar = false;
                p2Deck.Enqueue(p1FightCards);
                p2Deck.Enqueue(p2FightCards);
            }
            else
            {
                isWar = true;
            }
        }
    }
}

public static class QueueExtensions
{
    public static void Enqueue(this Queue<int> initial, Queue<int> extension)
    {
        while (extension.Count > 0)
        {
            initial.Enqueue(extension.Dequeue());
        }
    }
}
