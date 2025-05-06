using UnityEngine;

public class GolfPuttSound : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip PuttLevelTwoClip;
    public AudioClip InTheCupClip;
    public AudioClip WoodClip;

    [Header("Commentary Clips")]
    public AudioClip[] BallInTheCupClips;
    public AudioClip[] GroundContactClips;
    

    void Start()
    {
        // Get the AudioSource attached to the ball
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Putt sound with Space key 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayPuttSound();
        }
    }

    // Plays the putting sound
    public void PlayPuttSound()
    {
        if (audioSource != null && PuttLevelTwoClip != null)
        {
            audioSource.clip = PuttLevelTwoClip;
            audioSource.Play();
        }
    }

    // Plays sound when ball hits the wall
    public void WallHitSound()
    {
        if (audioSource != null && WoodClip != null)
        {
            audioSource.clip = WoodClip;
            audioSource.Play();
        }
    }

    // Plays sound when ball enters the cup
    public void BallInTheCupSound()
    {
        if (audioSource != null && InTheCupClip != null)
        {
            audioSource.clip = InTheCupClip;
            audioSource.Play();
        }
    }

    public void PlayRandomCupComment()
    {
        if (audioSource != null && BallInTheCupClips.Length > 0)
        {
            int index = Random.Range(0, BallInTheCupClips.Length);
            audioSource.PlayOneShot(BallInTheCupClips[index]);
        }
    }

    public void PlayRandomGroundComment()
    {
        if (audioSource != null && GroundContactClips.Length > 0)
        {
            int index = Random.Range(0, GroundContactClips.Length);
            audioSource.PlayOneShot(GroundContactClips[index]);
        }
    }

    // Detect collision with wall
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallHitSound();
        }
    }
}
