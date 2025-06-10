using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
        else
        {
            musicSource.Play();
        }
    }
}
