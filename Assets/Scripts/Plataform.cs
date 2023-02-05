using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    
    public bool isActive = false;
    public bool e;
    private float smoothing = 12;
    public float bounce = 20;
    private Vector2 activePos;
    private float positionY;
    // Start is called before the first frame update
    void Start()
    {
        positionY= transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            activePos = new Vector3(transform.position.x,positionY + 1f, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, activePos, smoothing * Time.deltaTime);
        }
        else
        {
            activePos = new Vector3(transform.position.x, positionY, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, activePos, smoothing * Time.deltaTime);
        }
    }

    IEnumerator ActivatePlataform()
    {
        //Wait for 2 seconds
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        isActive = false;
    }
    private void OnMouseDown()
    {  
        isActive = true;
        StartCoroutine(ActivatePlataform());     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive)
        {
            print("ENTREI");
            collision.GetComponent<PlayerMovement2D>().rb.velocity = new Vector2(collision.GetComponent<PlayerMovement2D>().speed, bounce);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive)
        {
            print("ENTREI");
            collision.GetComponent<PlayerMovement2D>().rb.velocity = new Vector2(collision.GetComponent<PlayerMovement2D>().speed, bounce);
        }
    }

}
