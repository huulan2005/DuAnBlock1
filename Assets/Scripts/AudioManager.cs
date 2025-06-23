using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager intance;
    [SerializeField]
    private AudioSource effectSourece;
    [SerializeField]
    private AudioClip Jumclip;
    [SerializeField]
    private AudioClip tapclip;
    [SerializeField] private AudioClip hurtclip;
    [SerializeField]
    private AudioClip crackeggclip;
    private bool hasplay = false;
    private void Awake()
    {
        if (intance == null)
        {
            intance = this;
        }
    }
    void Start()
    {
        effectSourece.Stop();
        hasplay = true;
    }
    public bool hasplayeEffectSound()
    {
        return hasplay;
    }
    public void SetHasPlayEffSound(bool value)
    {
        hasplay = value;
    }
    // Update is called once per frame
    public void PlayJumpclip()
    {
        effectSourece.PlayOneShot(Jumclip);
    }
    public void playtapclip()
    {
        effectSourece.PlayOneShot(tapclip);
    }
    public void playHUrtclip()
    {
        effectSourece.PlayOneShot(hurtclip);
    }
    public void ccrackeggclip()
    {
        effectSourece.PlayOneShot(crackeggclip);
    }
}
    

    
