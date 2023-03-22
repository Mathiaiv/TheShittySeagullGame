using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    private AudioSource audioSource;

    public void SetSound(bool isFelmale)
    {
        if (isFelmale)
        {
            audioSource = audioSources[Random.Range(0, audioSources.Length - 1)];
        }
    }

    public void Play()
    {
        audioSource.Play();
    }
}
