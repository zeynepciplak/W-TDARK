using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float rotationSpeed = 10.0f; // D�n�� h�z�
    // Update is called once per frame
    void Update()
    {
        // Kare objenizin tam tersi y�nde d�nmesi i�in
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);

        // Alternatif olarak, rotationSpeed de�erini negatif yapabilirsiniz
        //transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);

    }
}
