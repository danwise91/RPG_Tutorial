using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    const float locomoationAnimationSmoothTime = .1f; 
    Animator animator;
    NavMeshAgent agent; 

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomoationAnimationSmoothTime, Time.deltaTime);
	}
}
