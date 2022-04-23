using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PersistantBGMPlayer : MonoBehaviour
{
     public AudioSource sfxPlayer;
     static AudioSource SFXRef;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SFXRef = sfxPlayer;
    }

  //oh god im doing it again, i make a simple class to handle playing music between scenes and turn it into an audio manager
    public static void PlaySFX(AudioClip clipToPlay)
    {
        SFXRef.PlayOneShot(clipToPlay);
    }

}
