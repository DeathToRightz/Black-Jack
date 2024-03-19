using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack
//Name: Logan Cordova
//Section: SGD.213.2172
//Instructor: Professor Sowers
//Date: 03/18/2024
/////////////////////////////////////////////
public abstract class GamePlayer
{
    //Reference to the hand script, DeckOfCards script and the list of cards being used
   public Hand myHand;
   protected DeckofCards gameManager;
   protected List<Card> deck;

    //Passes a reference of the DeckofCards script, the list of cards, and the specific cards the ai starts with
    public GamePlayer( DeckofCards putGameManagerHere, List<Card> cardsToStartWith, ref List <Card> putDeckHere)
    {
        gameManager = putGameManagerHere;
        myHand =new Hand(cardsToStartWith);
        deck = putDeckHere;
    }

    //Sets so both player and ai can use this function
    public abstract void OnTurnStart();
    
    
    
}
