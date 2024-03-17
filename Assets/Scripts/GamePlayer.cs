using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GamePlayer
{
   public Hand myHand;
   protected DeckofCards gameManager;
   protected List<Card> deck;
    public GamePlayer( DeckofCards putGameManagerHere, List<Card> cardsToStartWith, ref List <Card> putDeckHere)
    {
        gameManager = putGameManagerHere;
        myHand =new Hand(cardsToStartWith);
        deck = putDeckHere;
    }


    public abstract void OnTurnStart();
    
    
    
}
