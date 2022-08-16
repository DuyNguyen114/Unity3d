using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip footstep;

    void footsound()
    {
        source.clip = footstep;
        source.Play();
        Debug.Log("footsound");
    }
}
