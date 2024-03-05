using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Hand : MonoBehaviour
{
    [SerializeField] TMP_Text playersScoreTxt;
    [SerializeField] TMP_Text opponentsScoreTxt;
    private int playerScore, opponentScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore > 21)
        {

        }
    }
}
