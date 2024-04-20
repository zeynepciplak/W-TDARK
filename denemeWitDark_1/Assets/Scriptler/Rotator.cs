using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Coroutine donmeCoroutine; // Donme iþlemi coroutine'unun referansý
    private bool donuyorMu = false; // Donme durumu
    public float donusHizi = 360; // Donme hýzý

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!donuyorMu)
            {
                donmeCoroutine = StartCoroutine(DonmeIslemi());
            }
        }
        // Input.GetKeyDown(KeyCode.H)
        if (transform.rotation.eulerAngles.z > 357)
        {
            if (donuyorMu && donmeCoroutine != null)
            {
                StopCoroutine(donmeCoroutine); // Donme iþlemi coroutine'unu durdur
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

        // Dondurme iþlemi tamamlandýðýnda donme durumunu false yaparak durduruyoruz
        donuyorMu = false;
    }
}
