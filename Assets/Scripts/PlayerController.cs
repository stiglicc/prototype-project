using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    PlayerMotor motor;
    public LayerMask movementMask;
    public Interactable focus;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                motor.MovetoPoint(hit.point); // move player 

                RemoveFocus(); // stop focusing objects
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>(); //check if we hit an interactable
                if (interactable != null) {
                   // Debug.Log("INTERACT");
                    SetFocus(interactable);
                }
                // if yes, focus on it
            }
        }
    }
    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus) {
            if(focus!=null)
               focus.OnDeFocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
            newFocus.OnFocused(transform);
    }
    private void RemoveFocus() {
        if(focus!=null)
            focus.OnDeFocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}
