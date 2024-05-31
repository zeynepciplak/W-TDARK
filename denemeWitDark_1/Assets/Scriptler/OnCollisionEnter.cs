using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter(OnCollisionEnter obj){
        Destroy(obj.gameObject);
        Destroy(this.gameObject);
    }
}
