using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void Sfx1()
    {
        src.clip = sfx1;
        src.Play();
    }
    public void Sfx2()
    {
        src.clip = sfx2;
        src.Play();
    }
}
