/*
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 180f; // D�nme h�z� (derece/saniye)

    void Update()
    {
        // Her saniye, transform.Rotate() fonksiyonu ile nesneyi Z ekseni etraf�nda d�nd�r�r�z.
        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
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

    public float sonGBasmaZamani = 0.0f;

    GameObject isikObjesi;

    void Start()
    {
        // I��k nesnesini etiketine g�re bul ve referans� kaydet
        isikObjesi = GameObject.FindWithTag("PlayerLight");

        // Ba�lang��ta ����� devre d��� b�rak
        isikObjesi.SetActive(false);

        sonGBasmaZamani = -2f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Time.time - sonGBasmaZamani < 2f)
            {
                return;
            }

            if (!donuyorMu)
            {
                d�nmeCoroutine = StartCoroutine(DonmeIslemi());
                donuyorMu = true;
            }
            sonGBasmaZamani = Time.time;
        }

        // Input.GetKeyDown(KeyCode.H)
        //if (transform.rotation.eulerAngles.z > 359)
        if (donuyorMu && d�nmeCoroutine != null)
        {
            d�nmeCoroutine = StartCoroutine(GeciktirmeliDurdurma(d�nmeCoroutine));
        }
    }
    IEnumerator DonmeIslemi()
    {

        donuyorMu = true;
        float initialRotation = transform.rotation.eulerAngles.z;
        float targetRotation = initialRotation + 360f;

        while (transform.rotation.eulerAngles.z < targetRotation)
        {
            isikObjesi.SetActive(true);
            transform.Rotate(Vector3.forward * -donusHizi * Time.deltaTime);
            yield return null;
        }

        //yield return new WaitForSeconds(1f);
        // D�nd�rme i�lemi tamamland���nda d�nme durumunu false yaparak durduruyoruz


        donuyorMu = false;
    }
    IEnumerator GeciktirmeliDurdurma(Coroutine coroutine)
    {
        if (donuyorMu && d�nmeCoroutine != null)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekle
            isikObjesi.SetActive(false);
            // D�nme i�lemi coroutine'unu durdur
            StopCoroutine(coroutine);

            donuyorMu = false;
            transform.rotation = Quaternion.identity;

        }
    }
}
