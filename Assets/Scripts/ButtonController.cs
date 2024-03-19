using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack
//Name: Logan Cordova
//Section: SGD.213.2172
//Instructor: Professor Sowers
//Date: 03/18/2024
/////////////////////////////////////////////
public class ButtonController : MonoBehaviour
{
    //Switches scenes depending on which button is pressed
  public void StartButtonClick()
    {
        SceneManager.LoadScene(2);
    }
    public void RulesButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void BackButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
