using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float lifeTime = 3;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;
        StartCoroutine(AutoDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();

        if (enemy != null)
        {
            enemy.TakeDamage();
        }
    }

    IEnumerator AutoDestroy()
    {
        //Wait for for cooldown
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
