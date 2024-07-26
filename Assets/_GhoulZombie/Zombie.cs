using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float walkSpeed = 1f;
    public float runSpeed = 3f;
    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("isAttacking", true);
            // 여기서 좀비가 플레이어를 향해 공격하는 코드 추가 가능
        }
        else if (distanceToPlayer <= detectionRange)
        {
            animator.SetBool("isPlayerDetected", true);
            animator.SetFloat("speed", 2f);  // Run 상태
            MoveTowardsPlayer(runSpeed);
        }
        else
        {
            animator.SetBool("isPlayerDetected", false);
            animator.SetFloat("speed", 1f);  // Walk 상태
            MoveForward(walkSpeed);
        }
    }

    void MoveTowardsPlayer(float speed)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void MoveForward(float speed)
    {
        // 좀비가 정해진 방향으로 움직이는 코드
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        isDead = true;
        animator.SetBool("isDead", true);
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

