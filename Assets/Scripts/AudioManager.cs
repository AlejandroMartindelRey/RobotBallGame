using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Singleton pattern.
    //1. Only one instance of Audio manager.
    //2. Accessible from any kind of entity into your project
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
