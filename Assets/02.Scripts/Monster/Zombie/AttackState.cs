using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    private Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get the direction to the player, but ignore the y axis
        Vector3 direction = player.position - animator.transform.position;
        direction.y = 0; // This makes sure the y-axis is not included in the rotation

        if (direction != Vector3.zero) 
        {
            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Check if the rotation is significant enough to apply
            if (Quaternion.Angle(animator.transform.rotation, targetRotation) > 0.1f)
            {
                animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3.5f)
            animator.SetBool("isAttacking", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
