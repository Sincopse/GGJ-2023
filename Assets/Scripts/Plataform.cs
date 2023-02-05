using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public float bounce = 20;
    public bool isActive = false;

    private float smoothing = 12;
    private Rigidbody2D rb;
    private Vector2 activePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            activePos = new Vector3(0, .25f, 2);

            transform.localPosition = Vector3.Lerp(transform.localPosition, activePos, smoothing * Time.deltaTime);
        }
        else
        {
            activePos = new Vector3(0, -.25f, 2);

            transform.localPosition = Vector3.Lerp(transform.localPosition, activePos, smoothing * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bounce, ForceMode2D.Impulse);
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.Angle(new Vector2(0, 0), new Vector2(2, 2) * bounce, ForceMode2D.Impulse);
            }
        }
    }

    public void OnClick()
    {
        if (!isActive)
        {
            isActive = true;
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
