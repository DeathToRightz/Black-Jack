using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        cardsVisual[0].sprite = cards[0].Sprite;
        Debug.Log(cards[0].CurrentSuit + " " + cards[0].CardValue);
        cardsVisual[1].sprite = cards[51].Sprite;
        Debug.Log(cards[51].CurrentSuit + " " + cards[51].CardValue );
       
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

    Sprite SetSpriteOnCard(int suitValue)
    {
        switch(suitValue)
        {
            case 0:
                for (int i = 0; i <= 13; i++)
                {
                    return listOfSprites[i];
                }
                break;
            case 1:
                for (int i = 13; i <= 26; i++)
                {
                    return listOfSprites[i];
                }
                break;
            case 2:
                for (int i = 26; i <= 39; i++)
                {
                    return listOfSprites[i];
                }
                break;
            case 3:
                for (int i = 39; i <= 52; i++)
                {
                    return listOfSprites[i];
                }
                break;
        }
        return null;
    }

    void GetSpriteRenderer(GameObject[] cards)
    {
        
        for (int i = 0; i < cards.Length; i++)
        {
            //cardsVisual[i] = cards[i].GetComponent<SpriteRenderer>();
            
        }
        
    }
}
