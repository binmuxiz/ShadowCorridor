using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class PatrolState : StateMachineBehaviour
{
    private float timer;
    private Transform player;
    private PlayerController playerController;
    private NavMeshAgent agent;
    List<Transform> wayPoints = new List<Transform>();
    private float chaseRange = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        timer = 0;

        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");

        foreach (Transform t in go.transform)
            wayPoints.Add(t);

        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        timer += Time.deltaTime;
        if (timer > 10f)
            animator.SetBool("isPatrolling", false);

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
        agent.SetDestination(agent.transform.position);
    }
}