using UnityEngine;
using FMODUnity;

public class Footsteps2D : MonoBehaviour
{
    [EventRef]
    public string footstepEventPath = "event:/footsteps"; // FMOD Studio'da oluşturduğunuz yürüme sesi olayının yolu
    public float stepDistance = 2.0f;
    private float distanceTraveled;
    private Vector2 previousPosition;

    [System.Serializable]
    public struct FootstepSound
    {
        public string tag;
        public string footstepEventPath;
        public string parameterName;
        public float parameterValue;
    }

    public FootstepSound[] footstepSounds;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousPosition = rb.position;
    }

    void Update()
    {
        float distance = Vector2.Distance(rb.position, previousPosition);
        distanceTraveled += distance;

        if (distanceTraveled >= stepDistance)
        {
            string surfaceTag = GetSurfaceTag();
            PlayFootstepSound(surfaceTag);
            distanceTraveled = 0f;
        }

        previousPosition = rb.position;
    }

    void PlayFootstepSound(string tag)
{
    foreach (FootstepSound sound in footstepSounds)
    {
        if (sound.tag == tag)
        {
            FMOD.Studio.EventInstance footstep = RuntimeManager.CreateInstance(sound.footstepEventPath);
            footstep.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            footstep.setParameterByName(sound.parameterName, sound.parameterValue);
            footstep.start();
            footstep.release();
            break;
        }
    }
}

    string GetSurfaceTag()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider != null)
        {
            return hit.collider.tag;
        }
        return "Default"; // Yer tespit edilemezse varsayılan etiket
    }
}
