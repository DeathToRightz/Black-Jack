
using UnityEngine;

public class Card  
{
    private int _cardValue;
    private Sprite _cardface;

    
    public Card(int cardValue, Sprite cardFace)
    {
        _cardface = cardFace;
        _cardValue = cardValue;
    }

    public int SetValue
    {
        get
        {
            return _cardValue;
        }
        set
        {
            _cardValue = value;
        }
    }

    public Sprite Cardface
    {
        get
        {
            return _cardface;
        }
        set
        {
            _cardface = value;
        }
    }
}
