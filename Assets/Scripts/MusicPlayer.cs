using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource musicSource;
    AudioClip musicClip;

    int rand;
    public AudioSource audioSource;
    public AudioClip[] Home;
    public AudioClip[] Dungeon;
    public AudioClip[] Boss;
    public AudioClip[] Menu;
    AudioClip lastClip;

    public bool isHome;

    void Start()
    {

        audioSource.PlayOneShot(RandomClip());
    }

    AudioClip RandomClip()
    {
        int attempts = 3;
        AudioClip newClip = Home[Random.Range(0, Home.Length)];

        while (newClip == lastClip && attempts > 0)
        {
            newClip = Home[Random.Range(0, Home.Length)];
            attempts--;
        }

        lastClip = newClip;
        return newClip;
    }
}
