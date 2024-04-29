using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Instance : MonoBehaviour
{
    public FMODUnity.EventReference BirdEvent;
    public bool debug = false;

    private FMOD.Studio.EventInstance bird_event_instance;
    private float timer = 0.0f;

    void Start()
    {
        float x = gameObject.transform.position.x + Random.Range(-10.0f, 10.0f);
        float y = gameObject.transform.position.y + Random.Range(-2.0f, 2.0f);
        float z = gameObject.transform.position.z + Random.Range(-10.0f, 10.0f);
        Vector3 new_position = new Vector3(x, y, z);
        gameObject.transform.position = new_position;

        bird_event_instance = FMODUnity.RuntimeManager.CreateInstance(BirdEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(bird_event_instance, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4.0f)
        {
            PlayBirdSound();
            timer = 0.0f;
        }
    }

    private void PlayBirdSound()
    {
        bird_event_instance.start();
    }

    private void OnDrawGizmos()
    {
        if(debug)
        {
            FMOD.Studio.PLAYBACK_STATE state;
            bird_event_instance.getPlaybackState(out state);
            if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(transform.position, 0.3f);
            }
            else
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(transform.position, 0.25f);
            }
        }
    }
}