/*
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 180f; // Donme hizi (derece/saniye)

    void Update()
    {
        // Her saniye, transform.Rotate() fonksiyonu ile nesneyi Z ekseni etrafinda dondururuz.
        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
    }
}
*/



using System.Collections;
using UnityEngine;
public class Rotator : MonoBehaviour
{
    private Coroutine donmeCoroutine; // Donme islemi coroutine'unun referansi
    private bool donuyorMu = false; // Donme durumu
    public float donusHizi = 360; // Donme hizi

    public float sonGBasmaZamani = 0.0f;

    GameObject isikObjesi;

    void Start()
    {
        // Isik nesnesini etiketine gore bul ve referansi kaydet
        isikObjesi = GameObject.FindWithTag("PlayerLight");

        // Baslangicta isigi devre disi birak
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
                donmeCoroutine = StartCoroutine(DonmeIslemi());
                donuyorMu = true;
            }
            sonGBasmaZamani = Time.time;
        }

        // Input.GetKeyDown(KeyCode.H)
        //if (transform.rotation.eulerAngles.z > 359)
        if (donuyorMu && donmeCoroutine != null)
        {
            donmeCoroutine = StartCoroutine(GeciktirmeliDurdurma(donmeCoroutine));
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
        // Dondurme islemi tamamlandiginda donme durumunu false yaparak durduruyoruz


        donuyorMu = false;
    }
    IEnumerator GeciktirmeliDurdurma(Coroutine coroutine)
    {
        if (donuyorMu && donmeCoroutine != null)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekle
            isikObjesi.SetActive(false);
            // Donme islemi coroutine'unu durdur
            StopCoroutine(coroutine);

            donuyorMu = false;
            transform.rotation = Quaternion.identity;

        }
    }
}
