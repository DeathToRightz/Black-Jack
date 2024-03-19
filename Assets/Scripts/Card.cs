
using UnityEngine;
[System.Serializable]
//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack
//Name: Logan Cordova
//Section: SGD.213.2172
//Instructor: Professor Sowers
//Date: 03/18/2024
/////////////////////////////////////////////
public class Card
{
    //Value for the card
    int _cardValue;
    
    //Card will have a suit
    public enum Suit
    {
        Clubs = 0,
        Spades = 1,
        Diamonds = 2,
        Hearts = 3,
    }

    //Each card will have a suit, card value, and a sprite for the face of the card
    public Card(Suit suit, int cardValue, Sprite cardFace)
    {
        CurrentSuit = suit;
        Sprite = cardFace;
        CardValue = cardValue;
    }
  
    //Function to set and get the Suit if needed
    public Suit CurrentSuit { get; private set; }
    
   
    //Function to set and get sprite
    public Sprite Sprite { get; private set; }
    
    //Function to set and get card value
    public int CardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }
}
