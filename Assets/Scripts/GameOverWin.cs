using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWin : MonoBehaviour
{
    /*public Text outputText1;

    var output = Login.yourName;
    outputText1.text = output;
    */
    public void OnPlayAgainButtonClicked()
    {
        MainGame.itemCount = 3;
        SceneManager.LoadScene("Level 1 - Cargo Bay (Caitlin)");
    }
}
