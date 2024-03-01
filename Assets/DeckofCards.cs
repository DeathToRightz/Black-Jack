using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckofCards : MonoBehaviour
{
    [SerializeField] GameObject card1, card2;
    private Card testCard;
    [SerializeField] Sprite[] listOfSprites;
    private SpriteRenderer cardVisual1, cardVisual2;
    void Start()
    {
        cardVisual1 = card1.GetComponent<SpriteRenderer>();
        cardVisual1.sprite = listOfSprites[0];
        /*testCard = new Card(5, listOfSprites[0]);
        cardVisual = GetComponent<SpriteRenderer>();
        cardVisual.sprite = listOfSprites[0];*/
        
    }

   
    void Update()
    {
        
    }
}
