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
        CreateDeck();
        ShuffledDeck(cards);
        lossScreen = GameObject.Find("Loss Panel");
        winScreen = GameObject.Find("Win Panel");
        tieScreen = GameObject.Find("Tie Panel");
        lossScreen.gameObject.SetActive(false);
        tieScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);              
        player = new User(this, new List<Card>(),  cards);       
        player.OnTurnStart();
        ai = new AI(this, new List<Card>(), cards);
        
        
        
        DealStarterCards();
    }

    private void Update()
    {
       
        
       
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
            for (int i = 9; i >= 2; i--)
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
        public void OnTurnFinished()
        {

            if (player.isMyTurn)
            {
                player.isMyTurn = false;

                ai.OnTurnStart();
            }
            ResultsOfGame();
        }

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
                playerScoreTxt.text = $"Your score: {player.myHand.CalaculateHandValue().ToString()}";
            }
            if (!player.isMyTurn)
            {
                Debug.Log("ai turn");

                for (int i = 0; i < ai.myHand.cardsInHand.Count; i++)
                {
                    opponentsCardsVisual[i].sprite = ai.myHand.cardsInHand[i].Sprite;
                }
                aiScore = ai.myHand.CalaculateHandValue();
                aiScoreTxt.text = $"Opponent score: {ai.myHand.CalaculateHandValue().ToString()}";
            }
        if (playerScore > 21 )
        {
            ResultsOfGame();
        }

    }
        public void OnClickEndTurn()
        {
            OnTurnFinished();
        }

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
