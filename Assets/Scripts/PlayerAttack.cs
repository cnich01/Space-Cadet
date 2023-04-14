using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int maxAttackDamage = 20;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform bulletSpwanPoint;

    [SerializeField]
    float shootDelay;

    bool isShooting = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            print("*******************Attack*******************");
            // Play an Attack Animation
            animator.SetTrigger("Attack");

            // Detect enemies in Range
            Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayers);

            // Damage enemy
            /*if (enemy != null)
            {
                int damage = Random.Range(1, maxAttackDamage);
                enemy.GetComponent<EnemyController>().TakeDamage(damage);
                print("Damage: " + damage);
            }*/
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            float horizontalInput = Input.GetAxis("Horizontal")*speed;
            if (isShooting)
                return;

            print("Shoot");
            isShooting = true;

            GameObject b = Instantiate(bullet);
            b.transform.position = bulletSpwanPoint.position;
            if (horizontalInput < 0)
            {
                b.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
            }
            else if (horizontalInput > 0 || horizontalInput == 0)
            {
                b.GetComponent<Rigidbody2D>().velocity = new Vector2(4, 0);
            }
            
            

            Invoke("ResetShoot", shootDelay);
        }
    }

    void ResetShoot()
    {
        isShooting = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
