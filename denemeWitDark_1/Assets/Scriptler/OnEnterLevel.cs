/*
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

    private Vector3 offset;
    private GameObject initialTarget; // Store initial entrance for later use
    private Rigidbody2D body;
    private bool hasUsedExit = false;

    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initialTarget = entrance; // Remember the initial entrance position
        target = sceneInfo.isNextScene ? gameEntrance : exit;
        body.position = target.transform.position + offset;
    }

    private void Update()
    {
        if (hasUsedExit == false)
        {
            if (sceneInfo.isNextScene) // Entering a new scene
            {
                offset = offsetEntrance; // Use entrance offset for new scenes
                target = entrance; // Set entrance as the target from now on
                hasUsedExit = false; // Reset exit flag
            }
            else if () // Using the exit
            {
                offset = offsetExit; // Use exit offset for exiting
                target = exit; // Set exit as the target for this time only
                hasUsedExit = true; // Set exit flag to prevent future changes
            }
        }
    }
}
*/