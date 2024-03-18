using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
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
