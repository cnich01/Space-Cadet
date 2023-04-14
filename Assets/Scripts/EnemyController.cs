using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemy;
    SpriteRenderer spriteRenderer;
    public float moveSpeed = 2;
    bool facingRight = false;

    [SerializeField]
    Transform castPosition;

    [SerializeField]
    float baseCastDistance;
    
    Vector3 baseScale;

    [SerializeField]
    public int maxHealth;

    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.velocity = new Vector2(moveSpeed, enemy.velocity.y);

        if(IsHittingWall() || IsOnEdge()) {
            if(facingRight) {
                facingRight = false;
                baseCastDistance = baseCastDistance * (-1);
            }

            else 
                facingRight = true;

            Vector3 newScale = baseScale;

            if(facingRight) {
                newScale.x = (-1) * baseScale.x;
            }

            else {
                newScale.x = baseScale.x;

            }


            transform.localScale = newScale;

            moveSpeed = moveSpeed * (-1);
            
        }
    }

    bool IsHittingWall() {

        float castDistance = baseCastDistance;

        Vector3 targetPosition = castPosition.position;
        targetPosition.x += castDistance;

        Debug.DrawLine(castPosition.position, targetPosition, Color.green);

        if(Physics2D.Linecast(castPosition.position, targetPosition, 1 << LayerMask.NameToLayer("Wall"))) {
            return true;
        }

        return false;
    }

    bool IsOnEdge() {
        float castDistance = baseCastDistance;

        Vector3 targetPosition = castPosition.position;

        targetPosition.y -= castDistance;

        Debug.DrawLine(castPosition.position, targetPosition, Color.green);

        if(Physics2D.Linecast(castPosition.position, targetPosition, 1 << LayerMask.NameToLayer("Wall"))) {
            return false;

        }

        return true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        print("Current Health: " + currentHealth);

        if (currentHealth < 0)
        {
            // Die
            print("Enemy Died!");
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            TakeDamage(Random.Range(1, 10));
            print("Enemy Hit!");
        }
    }
}
