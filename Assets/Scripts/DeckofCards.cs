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
    [SerializeField] TMP_Text playerScoreTxt,aiScoreTxt;
    [SerializeField] TMP_Text winResultsTxt,lossResultsTxt,tieResultsTxt;
    User player;
    AI ai;
   
    private int playerScore, aiScore; 
    
    private GameObject lossScreen, winScreen, tieScreen;
    void Start()
    {
       
        cards = new List<Card>(); //Makes the cards list 
       
        CreateDeck(); // Creates the list of cards
       
        ShuffledDeck(cards); //Shuffles the list of cards
        
        lossScreen = GameObject.Find("Loss Panel"); 
        winScreen = GameObject.Find("Win Panel");
        tieScreen = GameObject.Find("Tie Panel");  //Turns off the game results panels
        lossScreen.gameObject.SetActive(false);
        tieScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);             

        player = new User(this, new List<Card>(),  cards);  //Creates the player
                                                                  
        ai = new AI(this, new List<Card>(), cards); //Creates the ai 

        player.OnTurnStart(); //Starts on the player's turn

        DealStarterCards(); //Calles the funciton to deal the starting cards
    }

    //Creates the deck using a list of the Cards setting a value and sprite to each card object throught all the suits
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
            for (int i = 9; i >= 2; i--)
            {
                cards.Add(new Card(suit, i, listOfSprites[spritePlacement]));
                spritePlacement++;
            }
            
        }
        
    }

    //Shuffles the list of Cards 
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

    //Gives the results of the game comparing the scores of the player and ai
    private void ResultsOfGame()
    {
        if (playerScore > 21 || (aiScore == 21 && playerScore > 21) || (aiScore <= 21 & aiScore > playerScore))
        {
            lossScreen.gameObject.SetActive(true);
            lossResultsTxt.text = $"You busted, your hand's value was {playerScore} while the house's hand was {aiScore}";
        }
        if (playerScore == 21 || (playerScore <= 21 && aiScore > 21))
        {
            winScreen.gameObject.SetActive(true);
            winResultsTxt.text = $"You win, your hand's value was {playerScore} while the house's hand was {aiScore}";
        }
        if (playerScore == aiScore)
        {
            tieScreen.gameObject.SetActive(true);
            tieResultsTxt.text = $"Both you and the house tied with a score of {playerScore} and {aiScore}";
        }
    }
    //Function switch turn to ai and calles the ai to start drawing cards from it's funciton, then it will call the ResultsOfGame function
    public void OnTurnFinished()
    {

        if (player.isMyTurn)
        {
            player.isMyTurn = false;

            ai.OnTurnStart();
        }
        ResultsOfGame();
    }
    //Function switch the visuals of the back of the cards to the corrisponding card that was drawn, if it's the players turn it will change the player's cards and if it's the ai's turn it will change the ai's cards. 

    public void OnClickDrawCardBtn()
    {
        if (player.isMyTurn && player.myHand.cardsInHand.Count < 5)
        {
            player.myHand.DrawCard(ref cards);
            for (int i = 0; i < player.myHand.cardsInHand.Count; i++)
            {
                cardsVisual[i].sprite = player.myHand.cardsInHand[i].Sprite;
            }
            playerScore = player.myHand.CalaculateHandValue();
            playerScoreTxt.text = $"Your score: {player.myHand.CalaculateHandValue()}";
        }
        if (!player.isMyTurn)
        {
            Debug.Log("ai turn");

            for (int i = 0; i < ai.myHand.cardsInHand.Count; i++)
            {
                opponentsCardsVisual[i].sprite = ai.myHand.cardsInHand[i].Sprite;
            }
            aiScore = ai.myHand.CalaculateHandValue();
            aiScoreTxt.text = $"Opponent score: {ai.myHand.CalaculateHandValue()}";
        }
        
        //If during when the player is drawing cards and their score goes over 21 it will call the ResultsOfGame function
        if (playerScore > 21)
        {
            ResultsOfGame();
        }

    }
    //Calles the function when the button is pressed, I know that i couldve made the function be called by the button but I thought this would be easier to understand with a different name attached to it.
    public void OnClickEndTurn()
    {
        OnTurnFinished();
    }

    //This deals the starting cards at the beggining of each game, similar to the draw card function, but deals two cards to the player and 1 to the ai.
    private void DealStarterCards()
    {
        player.myHand.DrawCard(ref cards);
        player.myHand.DrawCard(ref cards);
        for (int i = 0; i < player.myHand.cardsInHand.Count; i++)
        {
            cardsVisual[i].sprite = player.myHand.cardsInHand[i].Sprite;
        }
        playerScore = player.myHand.CalaculateHandValue();
        playerScoreTxt.text = $"Your score: {player.myHand.CalaculateHandValue().ToString()}";

        ai.myHand.DrawCard(ref cards);
        for (int i = 0; i < ai.myHand.cardsInHand.Count; i++)
        {
            opponentsCardsVisual[i].sprite = ai.myHand.cardsInHand[i].Sprite;
        }
        aiScore = ai.myHand.CalaculateHandValue();
        aiScoreTxt.text = $"Opponent score: {ai.myHand.CalaculateHandValue().ToString()}";
    }
}
