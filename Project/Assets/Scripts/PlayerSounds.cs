using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip[] roarClips;

    public AudioClip attackClip;

    public AudioClip deathClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Death()
    {
        audioSource.PlayOneShot(deathClip);
    }
    public void Attack()
    {
        audioSource.PlayOneShot(attackClip);
    }
    public void Roar()
    {
        int index = Random.Range(0, roarClips.Length);

        AudioClip clip = roarClips[index];
        audioSource.PlayOneShot(clip);
    }
}
