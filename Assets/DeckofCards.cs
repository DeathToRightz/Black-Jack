using System;
using System.Collections.Generic;
using UnityEngine;

//52 cards
public class DeckofCards : MonoBehaviour
{
    private List <Card> cards;
    [SerializeField] Sprite[] listOfSprites;
    [SerializeField] GameObject[] playerCards;
    [SerializeField] SpriteRenderer[] cardsVisual;
    void Start()
    {
        cards = new List<Card>(); //Makes the cards list 
        playerCards = new GameObject[5]; //Makes the reference with the five player cards
        CreateDeck(); //Creates the deck of cards
        int x = 3;
        for (int i = 0; i < 5; i++)
        {
            
            cardsVisual[i].sprite = cards[x].Sprite;
            Debug.Log(cards[x].CurrentSuit + " " + cards[x].CardValue);
            x++;
        }
        //cardsVisual[0].sprite = cards[6].Sprite;
        
        
        
        
        //Debug.Log("After shuffle");
        //ShuffledDeck(cards); //Shuffles the deck of cards
        
    } 
    void CreateDeck()
    {
        int spritePlacement = 0;
        
        
        foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
        {
            cards.Add(new Card(suit, 11, listOfSprites[spritePlacement]));
            spritePlacement++;
            for (int j = 0; j <= 3; j++)
            {
                cards.Add(new Card(suit, 10, listOfSprites[spritePlacement]));
                spritePlacement++;
            }
            for (int i = 9; i > 2; i--)
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
