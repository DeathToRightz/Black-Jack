using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : GamePlayer
{
    public bool isMyTurn {  get;  set; }

    public User(DeckofCards deckofCardsHere, List<Card> cardsToStartWith) : base(deckofCardsHere,cardsToStartWith) { }
    
    public override void OnTurnStart()
    {
        isMyTurn = true;   
    }

    public void TurnEnd()
    {
        gameManager.OnTurnFinished();
        
    }
}
