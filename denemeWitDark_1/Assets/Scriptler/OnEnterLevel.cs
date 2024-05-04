using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterLevel : MonoBehaviour
{
    public GameObject entrance;
    public GameObject exit;

    [SerializeField]
    public SceneInfo sceneInfo;

    public Vector3 offsetEntrance = new Vector3(1, 0.5f, 0);
    public Vector3 offsetExit = new Vector3(-1, 0.5f, 0);

    Vector3 offset;
    public GameObject target;

    private Rigidbody2D body;
    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {

        body.position = target.transform.position + offset;
    }
    private void Update()
    {
        offset = sceneInfo.isNextScene ? offsetEntrance : offsetExit;
        target = sceneInfo.isNextScene ? entrance : exit;
        
    }
}