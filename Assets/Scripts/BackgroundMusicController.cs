using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private static BackgroundMusicController obj;
    
    [Header("Audio Settings")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] playlist;

    private int currentTrack = 0;
    
    private void Awake()
    {
        obj = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayCurrentTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayCurrentTrack()
    {
        audioSource.clip = playlist[currentTrack];
        audioSource.Play();
    }

    private void PlayNextTrack()
    {
        // go back to 0 if you hit the end
        currentTrack = (currentTrack + 1) % playlist.Length;
        PlayCurrentTrack();
    }
}
