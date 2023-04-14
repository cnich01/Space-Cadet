using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            //makes the object disappear
            collision.gameObject.SetActive(false);
            print("Enemy Died!");
        }
    }
}
