using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class Hand 
{
   public  List<Card> cardsInHand = new List<Card>();
    public int handValue;

    public Hand(List<Card> putCardsHere)
    {
        cardsInHand = putCardsHere;
        handValue = CalaculateHandValue();

    }

    public void DrawCard(ref List<Card>deckOfCards)
    {
        
        cardsInHand.Add(deckOfCards[0]);
        deckOfCards.RemoveAt(0);
        handValue =   CalaculateHandValue();
    }
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
        }
        return handValue;
    }

    
}
