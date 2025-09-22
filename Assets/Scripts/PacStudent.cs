using UnityEngine;

public class PacStudentSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip moveClip;
    public AudioClip eatClip;
    public AudioClip deathClip;

    // moving
    public void PlayMove()
    {
        if (moveClip) audioSource.PlayOneShot(moveClip);
    }

    // eating
    public void PlayEat()
    {
        if (eatClip) audioSource.PlayOneShot(eatClip);
    }

    // gameover
    public void PlayDeath()
    {
        if (deathClip) audioSource.PlayOneShot(deathClip);
    }
}
