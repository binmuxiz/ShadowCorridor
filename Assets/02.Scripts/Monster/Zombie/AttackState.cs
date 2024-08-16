using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    private Transform player;
    private PlayerController playerController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerController != null && playerController.isHiding)
        {
            animator.SetBool("isAttacking", false);
            return;
        }

        Vector3 direction = player.position - animator.transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            if (Quaternion.Angle(animator.transform.rotation, targetRotation) > 0.1f)
            {
                animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3.5f)
            animator.SetBool("isAttacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}