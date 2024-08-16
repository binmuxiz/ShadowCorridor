using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private PlayerController playerController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        agent.speed = 3.5f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerController != null && playerController.isHiding)
        {
            animator.SetBool("isChasing", false);
            return;
        }

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 15f)
            animator.SetBool("isChasing", false);
        if (distance < 2.5f)
            animator.SetBool("isAttacking", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }
}