using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Transform target; // Takip edilecek objenin transform bileþeni
    // Update is called once per frame
    void Update()
    {
        // Kare objenizin pozisyonunu her karede takip edilecek objenin pozisyonuna göre güncelleyin
        transform.position = target.position;
    }
}
