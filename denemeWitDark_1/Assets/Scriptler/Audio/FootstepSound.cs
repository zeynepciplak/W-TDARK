using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FootstepSound : MonoBehaviour
{
    public enum SurfaceType
    {
        Dirt,
        Sand,
        Water,
        Wood,
        Grass
    }

    [System.Serializable]
    public struct SurfaceSound
    {
        public string tag; // Yüzey tag'i
        public SurfaceType surfaceType; // Yüzey türü
    }

    public SurfaceSound[] surfaceSounds; // Yüzey sesleri dizisi
    private CharacterController characterController;
    private float stepTimer = 0f;
    public float stepInterval = 0.5f; // Adımlar arası süre

    public EventReference footstepEvent; // FMOD yürüme sesi eventi

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Oyuncu hareket ediyorsa adım seslerini çal
        if (characterController.isGrounded && characterController.velocity.magnitude > 2f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlayFootstepSound();
                stepTimer = 0f;
            }
        }
    }

    void PlayFootstepSound()
    {
        // Oyuncunun altındaki yüzeyi belirlemek için bir ray atışı yapın
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            foreach (SurfaceSound surfaceSound in surfaceSounds)
            {
                if (hit.collider.CompareTag(surfaceSound.tag))
                {
                    FMOD.Studio.EventInstance instance = RuntimeManager.CreateInstance(footstepEvent);
                    instance.setParameterByName("SurfaceType", (float)surfaceSound.surfaceType);
                    instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
                    instance.start();
                    instance.release();
                    break;
                }
            }
        }
    }
}
