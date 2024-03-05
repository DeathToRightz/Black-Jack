using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameResults : MonoBehaviour
{
    [SerializeField] TMP_Text lossText;
    [SerializeField] TMP_Text playersHandText;
    void Start()
    {
        lossText.text = $"You lost, your hand's value was: {playersHandText}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
