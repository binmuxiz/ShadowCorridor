using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float deathDuration = 3f; // "죽은 척" 지속 시간
    private bool isDead = false;
    private float resurrectionTime;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isDead)
        {
            // 일정 시간이 지나면 다시 살아나기
            if (Time.time >= resurrectionTime)
            {
                Resurrect();
            }
            return;
        }

        // 플레이어와의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 조건에 따라 상태를 결정
        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("isAttacking", true);
            navMeshAgent.isStopped = true; // 공격 시 이동 멈춤
            // 여기서 좀비가 플레이어를 향해 공격하는 코드 추가 가능
        }
        else if (distanceToPlayer <= detectionRange)
        {
            animator.SetBool("isPlayerDetected", true);
            animator.SetBool("isAttacking", false);
            navMeshAgent.isStopped = false; // 이동 재개
            navMeshAgent.SetDestination(player.position); // 플레이어를 향해 이동
        }
        else
        {
            animator.SetBool("isPlayerDetected", false);
            animator.SetBool("isAttacking", false);
            // 정해진 방향으로 걷기
            MoveForward(1f);
        }
    }

    void MoveForward(float speed)
    {
        Vector3 forward = transform.forward;
        forward.y = 0; // y축을 0으로 설정하여 수평 이동만 하도록 함
        navMeshAgent.isStopped = false; // 이동 재개
        navMeshAgent.speed = speed; // NavMeshAgent 속도 설정
        navMeshAgent.SetDestination(transform.position + forward); // 앞으로 이동
    }

    public void TakeDamage()
    {
        isDead = true;
        resurrectionTime = Time.time + deathDuration; // 죽은 척 지속 시간 설정
        animator.SetBool("isDead", true);
        animator.SetBool("isPlayerDetected", false);
        animator.SetBool("isAttacking", false);
        navMeshAgent.isStopped = true; // 죽을 때 이동 멈춤
    }

    private void Resurrect()
    {
        isDead = false;
        animator.SetBool("isDead", false);
        animator.SetBool("isPlayerDetected", false);
        animator.SetBool("isAttacking", false);
        navMeshAgent.isStopped = false; // 다시 이동 시작
        // Idle 상태로 돌아가기 위해 필요한 추가 동작들
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("attackTrigger");
        }
        else if (other.CompareTag("Item"))
        {
            TakeDamage();
        }
    }
}
