
using System.Collections.Generic;


public class User : GamePlayer
{
    public bool isMyTurn {  get;  set; }

    public User(DeckofCards deckofCardsHere, List<Card> cardsToStartWith, List<Card> putDeckHere) : base(deckofCardsHere,cardsToStartWith, ref putDeckHere) { }
    
    public override void OnTurnStart()
    {
        isMyTurn = true;   
    }

    public void TurnEnd()
    {
        gameManager.OnTurnFinished();      
    }

    
}
