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
    [SerializeField] SpriteRenderer[] cardsVisual, opponentsCardsVisual;
    [SerializeField] TMP_Text playerScoreTxt;
    [SerializeField] TMP_Text winResultsTxt,lossResultsTxt;
    User player;
    AI ai;
    bool playerTurnEnd;
    private int playerScore; 
    
    private GameObject lossScreen, winScreen;
    void Start()
    {
       
        cards = new List<Card>(); //Makes the cards list 
        CreateDeck();
        lossScreen = GameObject.Find("Loss Panel");
        winScreen = GameObject.Find("Win Panel");
        lossScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
         //Creates the deck of cards  

        
        player = new User(this, new List<Card>());
        
        player.OnTurnStart();
        ai = new AI(this, new List<Card>());
        ai.myHand.DrawCard(ref cards);
        ai.myHand.DrawCard(ref cards);
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
    public void OnTurnFinished()
    {

        if(player.isMyTurn)
        {
            player.isMyTurn = false;
            ai.OnTurnStart();
        }
    }

    public void OnClickDrawCard()
    {
       
        player.myHand.DrawCard(ref cards);
        for(int i = 0; i < player.myHand.cardsInHand.Count; i++)
        {
            cardsVisual[i].sprite = player.myHand.cardsInHand[i].Sprite;
        }


    }
    public void OnClickEndTurn()
    {
        player.TurnEnd();
    }
}
