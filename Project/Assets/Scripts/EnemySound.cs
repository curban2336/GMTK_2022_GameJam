using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    // Variables
    AudioSource audioSource;

    // Sound Variants

    public AudioClip[] deathClip;

    public AudioClip gunShotClip;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Death()
    {
        int index = Random.Range(0, deathClip.Length);

        AudioClip clip = deathClip[index];
        audioSource.PlayOneShot(clip);
    }
    public void Shoot()
    {
        audioSource.PlayOneShot(gunShotClip);
    }
}
