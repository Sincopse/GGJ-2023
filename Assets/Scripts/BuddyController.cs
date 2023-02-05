using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyController : MonoBehaviour
{
    public GameObject player;
   
    public float smoothing;
    private Vector3 playerPosition;
    public Vector2 localScale;

    // Start is called before the first frame update
    void Start()
    {
       PlayerMovement2D player = GetComponent<PlayerMovement2D>();
       localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector2(player.transform.position.x - 1, player.transform.position.y + 1);
        
        transform.position = Vector2.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);

       
    }

}
