
using System.Collections.Generic;


public class AI : GamePlayer
{
    

    public AI(DeckofCards putGameManagerHere, List<Card> cardsToStartWith, List<Card> putDeckHere) : base(putGameManagerHere, cardsToStartWith, ref putDeckHere) { }
    
        
    
    public override void OnTurnStart()
    {
       

        while(myHand.handValue <= 17 && myHand.cardsInHand.Count < 5)
        {
            myHand.DrawCard(ref deck);
            gameManager.OnClickDrawCardBtn();
        }
    }
}
