using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectMixer;

    public AudioSource coinAS, hitAS, bgmAS, rainAS, 
    thunderAS, raindropsAS, churchBellAS, pickUpItemAS,
     hitTheWallAS, hitTheTreeAS, wotfAS, wotgAS, wotlAS, windInTreeAS, riverAS; 

     public static AudioManager instance;


private void Awake()
{
    if(instance == null)
    {
        instance = this;
    }
}    

// Start is called before the first frame update
    void Start()
    {
        
        PlayAudio(bgmAS);
    }


    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    private void footStep(){
        
    }
}
