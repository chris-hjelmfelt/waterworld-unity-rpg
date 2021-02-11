using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;

    Camera cam;
    PlayerMotor motor;
  
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left click to move to a position
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) 
            {
                //Debug.Log("We hit " + hit.collider.name + " at " + hit.point);
                motor.MoveToPoint(hit.point);

                // Stop focusing any object
                RemoveFocus();
            }
        }

        // Right click to interact with an object
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) 
            {
                // check if we hit an interactable, if we did set it as our focus
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    Debug.Log("Interacting with " + hit.collider.name);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;        
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        focus = null;
        motor.StopFollowingTarget();
    }
}
