using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public static int itemCount = 3;

    public static int getItemCount()
    {
        return itemCount;
    }
    public static void addItemCount()
    {
        print("Add Item");
        itemCount++;
    }
    public static void minusItemCount()
    {
        print("Minus 1 life");
        itemCount = itemCount - 1;
        if (itemCount < 0)
        {
            SceneManager.LoadScene("GameOverLost");
        }
    }

}
