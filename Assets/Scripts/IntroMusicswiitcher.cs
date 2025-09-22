using UnityEngine;

public class IntroMusicSwitcher : MonoBehaviour
{
    [Header("References")]
    public AudioSource audioSource;

    [Header("Clips")]
    public AudioClip introClip;
    public AudioClip normalClip;

    [Header("Timing")]
    public float introDuration = 3f; // seconds

    float timer;

    void Start()
    {
        if (!audioSource) audioSource = GetComponent<AudioSource>();
        if (introClip)
        {
            audioSource.clip = introClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (!audioSource || !normalClip) return;

        timer += Time.deltaTime;

        if ((timer >= introDuration || !audioSource.isPlaying) && audioSource.clip != normalClip)
        {
            audioSource.clip = normalClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
