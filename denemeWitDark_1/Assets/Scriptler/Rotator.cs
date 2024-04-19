/*
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
*/


using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Coroutine d�nmeCoroutine; // D�nme i�lemi coroutine'unun referans�
    private bool donuyorMu = false; // D�nme durumu
    public float donusHizi = 360; // D�n�� h�z�

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!donuyorMu)
            {
                d�nmeCoroutine = StartCoroutine(DonmeIslemi());
            }
        }
        // Input.GetKeyDown(KeyCode.H)
        if (transform.rotation.eulerAngles.z > 357)
        {
            if (donuyorMu && d�nmeCoroutine != null)
            {
                StopCoroutine(d�nmeCoroutine); // D�nme i�lemi coroutine'unu durdur
                donuyorMu = false;
                transform.rotation = Quaternion.identity;

            }
        }
    }
    IEnumerator DonmeIslemi()
    {
        donuyorMu = true;
        float initialRotation = transform.rotation.eulerAngles.z;
        float targetRotation = initialRotation + 360f;

        while (transform.rotation.eulerAngles.z < targetRotation)
        {
            transform.Rotate(Vector3.forward * -donusHizi * Time.deltaTime);
            yield return null;
        }

        // D�nd�rme i�lemi tamamland���nda d�nme durumunu false yaparak durduruyoruz
        donuyorMu = false;
    }
}

