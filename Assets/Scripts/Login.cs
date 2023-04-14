using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField yourName;
    public InputField password;
    
    public void OnLoginButtonClicked()
    {
        var output = yourName.text;
        print(output);
        SceneManager.LoadScene("Level 1 - Cargo Bay (Caitlin)");

    }
}
