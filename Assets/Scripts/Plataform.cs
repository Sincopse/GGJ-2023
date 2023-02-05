using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public float bounce = 20;
    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
        }
    }

    void OnMouseDown()
    {
        if (!isActive)
        {
            isActive = true;
            print("jump pad on");
            StartCoroutine(ActivatePlataform());
        }
    }

    IEnumerator ActivatePlataform()
    {
        //Wait for 2 seconds
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        isActive = false;
    }
}
