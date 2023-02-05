using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformBtn : MonoBehaviour
{
    public bool e;
    public float bounce = 20;
    private void OnMouseDown()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            print("ENTREI");
        }   
        
    }
}
