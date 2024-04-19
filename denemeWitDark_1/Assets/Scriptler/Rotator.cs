/*
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
*/


using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Coroutine dönmeCoroutine; // Dönme iþlemi coroutine'unun referansý
    private bool donuyorMu = false; // Dönme durumu
    public float donusHizi = 360; // Dönüþ hýzý

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!donuyorMu)
            {
                dönmeCoroutine = StartCoroutine(DonmeIslemi());
            }
        }
        // Input.GetKeyDown(KeyCode.H)
        if (transform.rotation.eulerAngles.z > 357)
        {
            if (donuyorMu && dönmeCoroutine != null)
            {
                StopCoroutine(dönmeCoroutine); // Dönme iþlemi coroutine'unu durdur
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

        // Döndürme iþlemi tamamlandýðýnda dönme durumunu false yaparak durduruyoruz
        donuyorMu = false;
    }
}

