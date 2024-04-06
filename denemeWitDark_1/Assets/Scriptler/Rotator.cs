using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100f; // D�nme h�z� (derece/saniye)

    void Update()
    {
        // Her saniye, transform.Rotate() fonksiyonu ile nesneyi Z ekseni etraf�nda d�nd�r�r�z.
        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }
}


