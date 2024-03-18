
using System.Collections.Generic;

public class Hand 
{
    //Uses the list of Cards and has reference for the cards value in the hand
   public  List<Card> cardsInHand = new List<Card>();
   public int handValue;

    public Hand(List<Card> putCardsHere)
    {
        cardsInHand = putCardsHere;
        handValue = CalaculateHandValue();

    }
    //Function draws a card from the list of cards and then removes that same card from the list
    public void DrawCard(ref List<Card>deckOfCards)
    {
        
        cardsInHand.Add(deckOfCards[0]);
        deckOfCards.RemoveAt(0);
        handValue =   CalaculateHandValue();
    }
    //Sets the handValue to 0 each time the funciton is called and adds up the value of each card in the hand
    public int CalaculateHandValue()
    {
        int handValue = 0;
        
        if(cardsInHand.Count <= 0)
        {
            return 0;
        }
        foreach (Card card in cardsInHand)
        {
            
            handValue += card.CardValue;
            //If the card is an ace it will check whether or not to set the value to 1 or not depending if it will help the hand 
            if(card.CardValue == 11 && handValue >21)
            {
                card.CardValue = 1;
            }
        }
        
        return handValue;
    }

    
}
