using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animations : MonoBehaviour
{
    Animator anima;
    NavMeshAgent agent;
    const float locomotionSmoothtimer = 0.1f;
    void Start()
    {
        anima = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        anima.SetFloat("speedPercent", speedPercent, locomotionSmoothtimer,Time.deltaTime);
    }
}
