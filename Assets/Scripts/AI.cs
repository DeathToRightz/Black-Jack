
using System.Collections.Generic;

//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack
//Name: Logan Cordova
//Section: SGD.213.2172
//Instructor: Professor Sowers
//Date: 03/18/2024
/////////////////////////////////////////////
public class AI : GamePlayer
{
    
    //Passes a reference of the DeckofCards script, the list of cards, and the specific cards the ai starts with
    public AI(DeckofCards putGameManagerHere, List<Card> cardsToStartWith, List<Card> putDeckHere) : base(putGameManagerHere, cardsToStartWith, ref putDeckHere) { }
    
        
    //When the function is called it will continue to draw cards from the DeckOfCards script until its hand value is over 16 or if it's drawn 5 cards already
    public override void OnTurnStart()
    {
       

        while(myHand.handValue <= 17 && myHand.cardsInHand.Count < 5)
        {
            myHand.DrawCard(ref deck);
            gameManager.OnClickDrawCardBtn();
        }
    }
}
