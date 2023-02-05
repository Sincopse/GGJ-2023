using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpotController : MonoBehaviour
{
    public float bounce = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerMovement2D>().rb.velocity = new Vector2(collision.GetComponent<PlayerMovement2D>().rb.velocity.x, bounce);
            gameObject.transform.parent.GetComponent<EnemyBehaviour>().TakeDamage();
        }
    }
}
