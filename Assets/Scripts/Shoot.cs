using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Animator animBuddy;
    private bool onCoolDown = false;

    private void Start()
    {
        //animBuddy = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !onCoolDown)
        {
            animBuddy.SetTrigger("isShooting");
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        //Wait for for cooldown
        onCoolDown = true;
        yield return new WaitForSeconds(0.3f);
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        onCoolDown = false;
        animBuddy.SetTrigger("isntShooting");
    }
}
