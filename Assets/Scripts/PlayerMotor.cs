using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void MovetoPoint(Vector3 point) {
        agent.SetDestination(point);
    }
    public void FollowTarget(Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius*0.8f;
        agent.updateRotation = false;
        target = newTarget.transform;  
    }
    public void StopFollowingTarget() {
        agent.updateRotation = true;
        agent.stoppingDistance = 0f;
        target = null;
    }

}
