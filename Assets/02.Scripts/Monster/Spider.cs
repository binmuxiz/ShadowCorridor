using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed = 2f; // 이동 속도
    public float lifeTime = 1f; // 거미가 나타난 후 사라지기까지의 시간
    public int damage = 20; // 플레이어에게 줄 데미지
    public float rotationSpeed = 360f; // 회전 속도 (도/초)

    private Vector3 moveDirection;

    void Start()
    {
        // 랜덤 방향 설정
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        
        // 일정 시간 후 오브젝트 삭제
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 현재 방향에서 목표 방향으로의 회전 각도 계산
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        
        // 설정된 방향으로 이동
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}