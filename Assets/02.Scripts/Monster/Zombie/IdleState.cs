using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    private float timer;
    private Transform player;
    private PlayerController playerController;
    private float chaseRange = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 5f)
            animator.SetBool("isPatrolling", true);

        if (playerController != null && playerController.isHiding)
        {
            return;
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}