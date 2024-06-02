/*using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Footsteps : MonoBehaviour {

     [EventRef] 
     public string inputFootsteps;
  /*   EventInstance footstepsEvent;
     ParameterInstance dirtParameter;
     ParameterInstance sandParameter;
     ParameterInstance waterParameter;
     ParameterInstance woodParameter;
     ParameterInstance grassParameter;

     bool playerIsMoving;
     public float walkingSpeed;
     private float dirtValue;
     private float sandValue;
     private float waterValue;
     private float woodValue;
     private float grassValue;
     private bool playerIsGrounded;

     void Start ()
     {
         footstepsEvent = RuntimeManager.CreateInstance(inputFootsteps);
         footstepsEvent.getParameter ("Dirt", out dirtParameter);
         footstepsEvent.getParameter ("Sand", out sandParameter);
         footstepsEvent.getParameter ("Water", out waterParameter);
         footstepsEvent.getParameter ("Wood", out woodParameter);
         footstepsEvent.getParameter ("Grass", out grassParameter);

         InvokeRepeating ("CallFootsteps", 0, walkingSpeed);
     }

     void Update () 
     {
         dirtParameter.setValue(dirtValue);
         sandParameter.setValue(sandValue);
         waterParameter.setValue(waterValue);
         woodParameter.setValue(woodValue);
         grassParameter.setValue(grassValue);

         if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
         {
             if (playerIsGrounded == true) 
             {
                 playerIsMoving = true;
             } 
             else if (playerIsGrounded == false) 
             {
                 playerIsMoving = false;
             }
         } 
         else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0) 
         {
             playerIsMoving = false;
         }
     }

     void CallFootsteps ()
     {
         if (playerIsMoving == true) 
         {
             footstepsEvent.start();
         } 
         else if (playerIsMoving == false) 
         {
             //Debug.Log ("player is moving = false");
         }
     }

     void OnDisable ()
     {
         playerIsMoving = false;
     }

     void OnTriggerStay(Collider materialCheck)
     {
         playerIsGrounded = true;

         if (materialCheck.CompareTag("Dirt"))
         {
             dirtValue = 1f;
             sandValue = 0f;
             waterValue = 0f;
             woodValue = 0f;
             grassValue = 0f;
         }
         if (materialCheck.CompareTag("Sand"))
         {
             dirtValue = 0f;
             sandValue = 1f;
             waterValue = 0f;
             woodValue = 0f;
             grassValue = 0f;
         }
         if (materialCheck.CompareTag("Water"))
         {
             dirtValue = 0f;
             sandValue = 0f;
             waterValue = 1f;
             woodValue = 0f;
             grassValue = 0f;
         }
         if (materialCheck.CompareTag("Wood"))
         {
             dirtValue = 0f;
             sandValue = 0f;
             waterValue = 0f;
             woodValue = 1f;
             grassValue = 0f;
         }
         if (materialCheck.CompareTag("Grass"))
         {
             dirtValue = 0f;
             sandValue = 0f;
             waterValue = 0f;
             woodValue = 0f;
             grassValue = 1f;
         }
     }

     void OnTriggerExit(Collider materialCheck)
     {
         playerIsGrounded = false;
     }
}
*/