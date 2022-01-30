using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip click;

    public void PlayClick()
    {
        sfx.clip = click;
        sfx.Play();
    }
}
