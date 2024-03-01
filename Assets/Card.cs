
using UnityEngine;
[System.Serializable]
public class Card
{
    int _cardValue;
    public enum Suit
    {
        Clubs = 0,
        Spaces = 1,
        Diamonds = 2,
        Hearts = 3,
    }

    public Card(Suit suit, int cardValue, Sprite cardFace)
    {
        CurrentSuit = suit;
        Sprite = cardFace;
        CardValue = cardValue;
    }
    public Suit CurrentSuit { get; private set; }
    
    public Sprite Sprite { get; private set; }

    public int CardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }
}
