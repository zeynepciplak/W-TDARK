using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterLevel : MonoBehaviour
{
    public GameObject gameEntrance;
    public GameObject entrance;
    public GameObject exit;

    [SerializeField]
    public SceneInfo sceneInfo;

    public Vector3 offsetGameEntrance = new Vector3(0, 0.5f, 0);
    public Vector3 offsetEntrance = new Vector3(1, 0.5f, 0);
    public Vector3 offsetExit = new Vector3(-1, 0.5f, 0);

    Vector3 offset;
    bool hasSetOffset = false;
    public GameObject target;

    private Rigidbody2D body;
    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {

        target = sceneInfo.isNextScene ? gameEntrance : exit;
        body.position = target.transform.position + offset;
    }
    private void Update()
    {
        if (hasSetOffset == false)
        {
            offset = sceneInfo.isNextScene ? offsetEntrance : offsetExit;
            hasSetOffset = true; // Set the flag after setting offset
        }
        else if (hasSetOffset == true)
        {
            target = sceneInfo.isNextScene ? entrance : exit;
        }
    }
}