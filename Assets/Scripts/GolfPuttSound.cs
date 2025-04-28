using UnityEngine;

public class GolfPuttSound : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip PuttLevelTwoClip;
    public AudioClip WoodClip;
    public AudioClip AlmostHadItClip;
    public AudioClip InTheCupClip;
    public AudioClip NiceShotClip;

    void Start()
    {
        // Get the AudioSource attached to the ball
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Test play Putt sound with Space key (for quick testing only)
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

    // Plays "Nice Shot" sound
    public void NiceShot()
    {
        if (audioSource != null && NiceShotClip != null)
        {
            audioSource.clip = NiceShotClip;
            audioSource.Play();
        }
    }

    // Plays "Almost Had It" sound
    public void AlmostHadIt()
    {
        if (audioSource != null && AlmostHadItClip != null)
        {
            audioSource.clip = AlmostHadItClip;
            audioSource.Play();
        }
    }

    // Detect collision with wall (play wall hit sound)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallHitSound();
        }
    }
}
