using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100f; // Dönme hýzý (derece/saniye)

    void Update()
    {
        // Her saniye, transform.Rotate() fonksiyonu ile nesneyi Z ekseni etrafýnda döndürürüz.
        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }
}


