using System;
using System.Collections.Generic;
using UnityEngine;

//52 cards
public class DeckofCards : MonoBehaviour
{
    private List <Card> cards;
    [SerializeField] Sprite[] listOfSprites;
    public GameObject[] playerCards;
    public SpriteRenderer[] cardsVisual;
    void Start()
    {
        cards = new List<Card>();
        playerCards = new GameObject[5];
        CreateDeck();
        Debug.Log("Before shuffle");
        cardsVisual[0].sprite = cards[0].Sprite;
        Debug.Log(cards[0].CurrentSuit + " " + cards[0].CardValue);
        /*cardsVisual[1].sprite = cards[51].Sprite;
        Debug.Log(cards[51].CurrentSuit + " " + cards[51].CardValue );  */
        Debug.Log("After shuffle");
        ShuffledDeck(cards);
        Debug.Log(cards[0].CurrentSuit + " " + cards[0].CardValue);
    } 
    void CreateDeck()
    {
        int spritePlacement = 0;
        foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
        {                  
           for(int i = 14; i > 1; i--)
            {              
                cards.Add(new Card(suit, i, listOfSprites[spritePlacement]));
                spritePlacement++;
            }
        }   
    }

    List<Card> ShuffledDeck(List<Card> deck)
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Card temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
        return deck;
    }
    
}
