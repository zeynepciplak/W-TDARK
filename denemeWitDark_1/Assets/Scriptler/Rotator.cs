using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float rotationSpeed = 10.0f; // Dönüþ hýzý
    // Update is called once per frame
    void Update()
    {
        // Kare objenizin tam tersi yönde dönmesi için
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);

        // Alternatif olarak, rotationSpeed deðerini negatif yapabilirsiniz
        //transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);

    }
}
