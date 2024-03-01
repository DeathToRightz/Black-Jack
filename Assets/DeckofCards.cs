using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Card;
//52 cards
public class DeckofCards : MonoBehaviour
{
    [SerializeField] GameObject playerCard1, playerCard2;
    private List <Card> cards;
    [SerializeField] Sprite[] listOfSprites;
    private SpriteRenderer cardVisual1, cardVisual2;
    void Start()
    {
        cards = new List<Card> ();  
       cardVisual1 = playerCard1.GetComponent<SpriteRenderer> ();
       // cardVisual1.sprite = listOfSprites[0];
         CreateDeck();
        
         Instantiate(playerCard1, playerCard1.transform.position, Quaternion.identity);
       cardVisual1.sprite = cards[0].Sprite;
        Debug.Log(cards[0].CardValue);
    }

   
   

    void CreateDeck()
    {
        
       

        foreach(Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
        {
            
           for(int i = 14; i > 1; i--)
            {

                cards.Add(new Card(suit, i, SetSpriteOnCard()));

            }
           
        }
        
    }

    Sprite SetSpriteOnCard()
    {
        return listOfSprites[0];
    }

    
}
