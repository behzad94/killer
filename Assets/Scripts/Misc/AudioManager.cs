using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPlayerObject;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string gameplaySnapshotName = "Default";
    [SerializeField] string gameOverSnapshotName = "GameOver";

    AudioSource gameOverAudioSource;

    void Start()
    {
        gameOverAudioSource = gameOverPlayerObject.GetComponentInChildren<AudioSource>();
        SetGameplaySnapshot();
    }

    public void SetSnapshot(string snapshotName, float transitionTime = 0.5f)
    {
        audioMixer.FindSnapshot(snapshotName).TransitionTo(transitionTime);
    }

    public void SetGameplaySnapshot()
    {
        SetSnapshot(gameplaySnapshotName);

        if (gameOverAudioSource != null && gameOverAudioSource.isPlaying)
        {
            gameOverAudioSource.Stop();
        }

    }

    public void SetGameOverSnapshot()
    {
        SetSnapshot(gameOverSnapshotName);

        if (gameOverAudioSource != null && !gameOverAudioSource.isPlaying)
        {
            gameOverAudioSource.Play();
        }
    }
}
