using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GamePlayer
{
    public Hand myHand;
   protected DeckofCards gameManager;
   
    public GamePlayer( DeckofCards putGameManagerHere, List<Card> cardsToStartWith)
    {
        gameManager = putGameManagerHere;
        myHand =new Hand(cardsToStartWith);

    }


    public abstract void OnTurnStart();
    
    
}
