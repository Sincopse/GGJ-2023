using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector3 LocationA;
    private Vector3 LocationB;
    private Vector3 nextLocation;

    [SerializeField] private UnityEngine.Transform Enemy;
    [SerializeField] private UnityEngine.Transform MovingToLocation;

    public float speed;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        LocationA = Enemy.localPosition;
        LocationB = MovingToLocation.localPosition;
        nextLocation = LocationB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Enemy.localPosition = Vector3.MoveTowards(Enemy.localPosition, nextLocation, speed * Time.deltaTime);
        if (Vector3.Distance(Enemy.localPosition, nextLocation) <= 0.1)
        {
            ChangePosition();
        }
    }
    private void ChangePosition()
    {
        nextLocation = nextLocation != LocationA ? LocationA : LocationB;
    }
    public void FlipEnemy()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x = -1;
        transform.localScale = Scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}