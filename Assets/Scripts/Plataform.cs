using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    private bool isActive = false;
    public CharacterController2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            print("e");
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            StartCoroutine(waiter());
        }
    }

    void OnMouseDown()
    {
        isActive = true;
    }

    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
