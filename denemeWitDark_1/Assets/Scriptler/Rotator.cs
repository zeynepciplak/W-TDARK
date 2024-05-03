/*
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 180f; // Dönme hýzý (derece/saniye)

    void Update()
    {
        // Her saniye, transform.Rotate() fonksiyonu ile nesneyi Z ekseni etrafýnda döndürürüz.
        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
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

    public float sonGBasmaZamani = 0.0f;

    GameObject isikObjesi;

    void Start()
    {
        // Iþýk nesnesini etiketine göre bul ve referansý kaydet
        isikObjesi = GameObject.FindWithTag("PlayerLight");

        // Baþlangýçta ýþýðý devre dýþý býrak
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
                dönmeCoroutine = StartCoroutine(DonmeIslemi());
                donuyorMu = true;
            }
            sonGBasmaZamani = Time.time;
        }

        // Input.GetKeyDown(KeyCode.H)
        //if (transform.rotation.eulerAngles.z > 359)
        if (donuyorMu && dönmeCoroutine != null)
        {
            dönmeCoroutine = StartCoroutine(GeciktirmeliDurdurma(dönmeCoroutine));
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
        // Döndürme iþlemi tamamlandýðýnda dönme durumunu false yaparak durduruyoruz


        donuyorMu = false;
    }
    IEnumerator GeciktirmeliDurdurma(Coroutine coroutine)
    {
        if (donuyorMu && dönmeCoroutine != null)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekle
            isikObjesi.SetActive(false);
            // Dönme iþlemi coroutine'unu durdur
            StopCoroutine(coroutine);

            donuyorMu = false;
            transform.rotation = Quaternion.identity;

        }
    }
}
