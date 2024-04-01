using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectMixer;

    public AudioSource wotgAS , wotfAS , wotlAS ,rainAS ,thunderAS;

    [Range(-80,20)]
    public float effectVol, masterVol;

    public static AudioManager instance;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void MasterVolume(){
        musicMixer.SetFloat("masterVolume", masterVol);
    }

    public void EffectVolume(){

        effectMixer.SetFloat("effectVolume", effectVol);

    }
    void Start()
    {

        PlayAudio(wotgAS);
        PlayAudio(thunderAS);
        
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectVolume();
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
//AudioManager.instance.Playaudio(AudioManager.instance.ses);