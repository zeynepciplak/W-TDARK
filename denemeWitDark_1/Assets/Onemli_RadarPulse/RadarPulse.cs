using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPulse : MonoBehaviour
{
    [SerializeField] private Transform pfRadarPing;
    private Transform pulseTransform;
    private float range;
    private float rangeMax;
    private List<Collider2D> alreadyPingedColliderList;

    private void Awake()
    {
        pulseTransform = transform.Find("Pulse");
        rangeMax = 5f;
        alreadyPingedColliderList = new List<Collider2D>();
    }

    private void FixedUpdate()
    {
        float rangeSpeed = 2f;
        range += rangeSpeed * Time.deltaTime;
        if (range > rangeMax)
        {
            range = 0f;
            alreadyPingedColliderList.Clear();
        }
        pulseTransform.localScale = new Vector3(range, range);

        RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, range / 2f, Vector2.zero);
        foreach(RaycastHit2D raycastHit2D in raycastHit2DArray) 
        { 
            if(raycastHit2D.collider != null )
            {
                // Hit something
                if (alreadyPingedColliderList.Contains(raycastHit2D.collider))
                {
                    alreadyPingedColliderList.Add(raycastHit2D.collider);
                    Transform radarPingTransform = Instantiate(pfRadarPing, raycastHit2D.point, Quaternion.identity);
                    RadarPing radarPing = radarPingTransform.GetComponent<RadarPing>(); 
                    if(raycastHit2D.collider.gameObject.GetComponent<Trees>() != null)
                    {
                        radarPing.SetColor(new Color(0, 0, 1));
                    }
                    if (raycastHit2D.collider.gameObject.GetComponent<Medicine>() != null)
                    {
                        radarPing.SetColor(new Color(1, 0, 0));
                    }
                    
                }
            }
        }
    }
}
