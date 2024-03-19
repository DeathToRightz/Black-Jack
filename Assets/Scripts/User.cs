
using System.Collections.Generic;

//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack
//Name: Logan Cordova
//Section: SGD.213.2172
//Instructor: Professor Sowers
//Date: 03/18/2024
/////////////////////////////////////////////
public class User : GamePlayer
{
    //Determines if its the player's turn yet
    public bool isMyTurn {  get;  set; }

    //Passes a reference of the DeckofCards script, the list of cards, and the specific cards the ai starts with
    public User(DeckofCards deckofCardsHere, List<Card> cardsToStartWith, List<Card> putDeckHere) : base(deckofCardsHere,cardsToStartWith, ref putDeckHere) { }
    
    //Function that determines its the player's turn
    public override void OnTurnStart()
    {
        isMyTurn = true;   
    }

    //Ends the player's turn
    public void TurnEnd()
    {
        gameManager.OnTurnFinished();      
    }

    
}
