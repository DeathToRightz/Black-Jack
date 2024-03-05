using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//52 cards
public class DeckofCards : MonoBehaviour
{
    private List <Card> cards;
    [SerializeField] Sprite[] listOfSprites;
    [SerializeField] SpriteRenderer[] cardsVisual;
    [SerializeField] TMP_Text playerScoreTxt;
    [SerializeField] TMP_Text winResultsTxt,lossResultsTxt;
    private int playerScore; 
    private int cardplace = 9;
    private int hand = 0;
    private GameObject lossScreen, winScreen;
    void Start()
    {
        cards = new List<Card>(); //Makes the cards list 
        lossScreen = GameObject.Find("Loss Panel");
        winScreen = GameObject.Find("Win Panel");
        lossScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        CreateDeck(); //Creates the deck of cards  
      
    }
    private void Update()
    {
        ResultsOfGame();
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
    
    public void DrawCard()
    {
        if( hand <=4)
        {
            cardsVisual[hand].sprite = cards[cardplace].Sprite;
            
            playerScore += cards[cardplace].CardValue;
            cardplace++;
            hand++;
        }
        playerScoreTxt.text = $"Player's score: {playerScore}";
    }

   private void ResultsOfGame()
    {
        if (playerScore > 21)
        {
            lossScreen.gameObject.SetActive(true);
            lossResultsTxt.text = $"You lost, your hand's value was {playerScore}";
        }
        if(playerScore == 21)
        {
            winScreen.gameObject.SetActive(true);
            winResultsTxt.text = $"You win, your hand's value was {playerScore}";
        }
    }
}
