using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip jumpFx;
    public AudioClip attackFx;
    public AudioClip dieFx;
    public AudioClip hurtFx;
    public AudioClip levelCompleteFx;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    public void JumpFx()
    {
        audioSource.clip = jumpFx;
        audioSource.Play();
    }

    public void AttackFx()
    {
        audioSource.clip = attackFx;
        audioSource.Play();
    }

    public void DieFx()
    {
        audioSource.clip = dieFx;
        audioSource.Play();
    }
    public void HurtFx()
    {
        audioSource.clip = hurtFx;
        audioSource.Play();
    }

    public void LevelCompleteFx()
    {
        audioSource.clip = levelCompleteFx;
        audioSource.Play();
    }

}
