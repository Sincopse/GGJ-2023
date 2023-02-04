using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float limitX;
    public float offsetY;
    public float smoothing;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position.x - player.transform.position.x);

        float playerDistance = transform.position.x - player.transform.position.x;

        var playerPosX = playerDistance > limitX ? player.transform.position.x
                       : playerDistance < -limitX ? player.transform.position.x : transform.position.x;

        playerPosition = new Vector3(playerPosX, player.transform.position.y > 3 ? player.transform.position.y : offsetY, -10);
        
        transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);
    }
}
