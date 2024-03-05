using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : GamePlayer
{
    
    public AI(DeckofCards putGameManagerHere, List<Card> cardsToStartWith) : base(putGameManagerHere, cardsToStartWith) { }
    
        
    
    public override void OnTurnStart()
    {
        gameManager.OnTurnFinished();
    }
}
