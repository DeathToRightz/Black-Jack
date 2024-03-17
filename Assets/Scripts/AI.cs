using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : GamePlayer
{
    private DeckofCards deckOfCards;

    public AI(DeckofCards putGameManagerHere, List<Card> cardsToStartWith, List<Card> putDeckHere) : base(putGameManagerHere, cardsToStartWith, ref putDeckHere) { }
    
        
    
    public override void OnTurnStart()
    {
        //gameManager.OnTurnFinished();

        while(myHand.handValue <= 17 && myHand.cardsInHand.Count < 5)
        {
            myHand.DrawCard(ref deck);
            gameManager.OnClickDrawCardBtn();
        }
    }
}
