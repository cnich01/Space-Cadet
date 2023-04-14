using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text itemCount;

    // Update is called once per frame
    void Update()
    {
        itemCount.text = MainGame.getItemCount().ToString();
    }
}
