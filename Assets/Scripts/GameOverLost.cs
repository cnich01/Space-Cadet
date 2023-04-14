using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverLost : MonoBehaviour
{
    public void OnPlayAgainButtonClicked()
    {
        MainGame.itemCount = 3;
        //gameObject.SetActive(false);
        SceneManager.LoadScene("Level 1 - Cargo Bay (Caitlin)");
    }
}
