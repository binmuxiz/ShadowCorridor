using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float rotationSpeed = 5f; //회전속도
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float deathDuration = 3f; // "죽은 척" 지속 시간
    private bool isDead = false;

    void Update()
    {
        if (isDead)
        {
            // 일정 시간이 지나면 다시 살아나기
            if (Time.time >= deathDuration)
            {
                Resurrect();
            }
            return;
        }
       
        // 애니메이션 상태 확인
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle"))
        {
            // Idle 상태일 때 이동하지 않음
            return;
        }
        //플레이어와의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //목표 회전 각도 
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        //천천히 목표 회전각도로 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        
        // 조건에 따라 상태를 결정
        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("isAttacking", true);
            // 여기서 좀비가 플레이어를 향해 공격하는 코드 추가 가능
        }
        else if (distanceToPlayer <= detectionRange)
        {
            animator.SetBool("isPlayerDetected", true);
            animator.SetBool("isAttacking", false);
            MoveTowardsPlayer(2f); // 플레이어를 향해 이동
        }
        else
        {
            animator.SetBool("isPlayerDetected", false);
            animator.SetBool("isAttacking", false);
            // 정해진 방향으로 걷기
            MoveForward(1f);
        }
    }

    void MoveTowardsPlayer(float speed)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // y축을 0으로 설정하여 수평 이동만 하도록 함
        transform.position += direction * speed * Time.deltaTime;
    }

    void MoveForward(float speed)
    {
        Vector3 forward = transform.forward;
        forward.y = 0; // y축을 0으로 설정하여 수평 이동만 하도록 함
        transform.position += forward * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        isDead = true;
        deathDuration = Time.time + deathDuration; // 죽은 척 지속 시간 설정
        animator.SetBool("isDead", true);
        animator.SetBool("isPlayerDetected", false);
        animator.SetBool("isAttacking", false);
        animator.SetTrigger("attackTrigger");
    }

    private void Resurrect()
    {
        isDead = false;
        animator.SetBool("isDead", false);
        animator.SetBool("isPlayerDetected", false);
        animator.SetBool("isAttacking", false);
        // Idle 상태로 돌아가기 위해 필요한 추가 동작들
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            TakeDamage();
        }
    }
}
