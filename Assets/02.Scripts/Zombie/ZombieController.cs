//NavMeshAgent써서 따라가는 거 해보고 싶어서..

using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform
    private Animator animator;
    private NavMeshAgent agent;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
     
    }

    void Update()
    {

        agent.SetDestination(target.position);

    }

   
}
