using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
{
    StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
    emitter.EventReference = eventReference;
    eventEmitters.Add(emitter);

    // Hoparlör simgesini devre dışı bırak
    Renderer renderer = emitterGameObject.GetComponent<Renderer>();
    if (renderer != null)
    {
        renderer.enabled = false;
    }

    return emitter;
}

    private void CleanUp()
    {
        // Stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        // Stop all of the event emitters because if we don't they may hang around in other scenes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }

    internal StudioEventEmitter InitializeEventEmitter(object swordIdle, GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    // Ses olayını durdurmak için metot
    public void StopEvent(GameObject gameObject)
    {
        // Eğer bu nesne bir StudioEventEmitter bileşeni içeriyorsa, onun oynatılan sesini durdur
        StudioEventEmitter emitter = gameObject.GetComponent<StudioEventEmitter>();
        if (emitter != null)
        {
            emitter.Stop();
        }
    }
}
