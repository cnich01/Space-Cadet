using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Vector3 baseScale;
    bool hasKey;
    //private gameObject keycard;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator >();
        baseScale = transform.localScale;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal")*speed;
        Vector3 newScale = baseScale;
        if (horizontalInput < -0.1)
        {
            newScale.x = (-1) * baseScale.x;
            anim.SetBool("Moving", true);
        }
        else if (horizontalInput > 0.1)
        {
            newScale.x = baseScale.x;
            anim.SetBool("Moving", true);
        }
        else{
            anim.SetBool("Moving", false);
        }
        if((Input.GetKey(KeyCode.Space)) && (rigidbody.velocity.y < .01) && (rigidbody.velocity.y > -.01)){
            rigidbody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }

        transform.localScale = newScale;
        rigidbody.velocity = new Vector2(horizontalInput, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject.name);

        if(collision.gameObject.tag == "Key")
        {
            //makes the object disappear
            collision.gameObject.SetActive(false);
            hasKey = true;
        }
        if (collision.gameObject.tag == "Exit")
        {
            if (hasKey == true)
            {
                SceneManager.LoadScene("Level 2 - Andrija");
            }
            else
            {
                //tells player to find key (probably HUD)
            }
        }
        if (collision.gameObject.tag == "Exit2")
        {
            if (hasKey == true)
            {
                SceneManager.LoadScene("Level 3 - Wyatt");
            }
            else
            {
                //tells player to find key (probably HUD)
            }
            
        }
        if (collision.gameObject.tag == "Exit3")
        {
            if (hasKey == true)
            {
                SceneManager.LoadScene("GameOverWin");
            }
            else
            {
                //tells player to find key (probably HUD)
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Life")
        {
            MainGame.addItemCount();
            Destroy(collision.gameObject);
        }

        //IF IT COLLIDES WITH THE ENEMY, LOAD CURRENT SCENE MINUS NUMBER OF LIVES(JUST TYPE IN YOUR TAG)
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            MainGame.minusItemCount();
        }

        if (collision.gameObject.tag == "Hammer")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            MainGame.minusItemCount();
        }
        if (collision.gameObject.tag == "Saw")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            MainGame.minusItemCount();
        }
    }
}
