using UnityEngine;
using FMODUnity;

public class footsteps : MonoBehaviour
{
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
    }

    void Update()
    {
        // Yer değiştikçe adım sesi çalma
        // Adımların sıklığını burada kontrol edebilirsiniz
    }

    void PlayFootstepSound(string tag)
    {
        foreach (FootstepSound sound in footstepSounds)
        {
            if (sound.tag == tag)
            {
                FMOD.Studio.EventInstance footstep = RuntimeManager.CreateInstance(sound.footstepEventPath);
                footstep.setParameterByName(sound.parameterName, sound.parameterValue);
                footstep.start();
                footstep.release();
                break; // Eşleşen etiket bulunduğunda döngüden çık
            }
        }
    }

    // Diğer yöntemler gibi, OnCollisionEnter2D() veya OnTriggerEnter2D() kullanarak
    // Yürüme yüzeyine göre etiket kontrolü yapabilirsiniz
}
