using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachyMove : StateMachineBehaviour
{
    public float speed = 3.5f;

    Transform startPosition;
    Vector3 target;
    Rigidbody rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get it's transform
        startPosition = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(-2.5f, startPosition.position.y, startPosition.position.z);
        rb = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Vector3 newPos = Vector3.MoveTowards(startPosition.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
