using TMPro; // TextMeshPro를 사용하기 위한 네임스페이스 추가
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 10.0f;
    public float crouchSpeed = 2.5f;
    public float mouseSensitivity = 1.3f;
    public float crouchHeight = 1.0f;
    private float originalHeight;
    private float verticalLookRotation;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private Transform cameraTransform;
    private bool isCrouching = false;

    public float rotationSpeed = 1.0f; // 회전 속도 변수 추가

    // 체력 관련 변수
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText; // UI에 표시될 체력 텍스트

    // 좀비의 위치 (예제)
    public Transform zombieTransform;

    private float yaw = 0f; // 수평 회전을 추적하기 위한 변수
    private float pitch = 0f; // 수직 회전을 추적하기 위한 변수

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        cameraTransform = Camera.main.transform;
        originalHeight = capsuleCollider.height;
        rb.freezeRotation = true;

        // 초기 방향을 설정 (좀비를 바라보도록)
        if (zombieTransform != null)
        {
            Vector3 directionToZombie = (zombieTransform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToZombie);

            // 플레이어의 초기 회전 설정
            transform.rotation = lookRotation;

            // yaw와 pitch 값을 설정
            yaw = transform.eulerAngles.y;
            pitch = cameraTransform.localEulerAngles.x;
        }

        // 체력 초기화
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        // 마우스 입력에 따른 회전 값 업데이트
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;

        // 수평 회전 제한
        yaw = Mathf.Clamp(yaw, -90, 90);
        // 수직 회전 제한
        pitch = Mathf.Clamp(pitch, -45, 45);

        // 회전 적용
        transform.localEulerAngles = new Vector3(0, yaw, 0);
        cameraTransform.localEulerAngles = new Vector3(pitch, 0, 0);

        // 앉기 상태 전환
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StandUp();
        }

        // 체력 감소 테스트
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10); // H 키를 눌러 10만큼 체력 감소
        }

        // 체력 증가 테스트
        if (Input.GetKeyDown(KeyCode.J))
        {
            Heal(10); // J 키를 눌러 10만큼 체력 증가
        }
    }

    void FixedUpdate()
    {
        // 이동 속도 설정
        float speed = isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);

        // 플레이어 이동
        float moveForward = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        float moveSide = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        Vector3 move = transform.right * moveSide + transform.forward * moveForward;
        rb.MovePosition(rb.position + move);

        // 이동 방향으로 플레이어 회전
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed));
        }
    }

    void Crouch()
    {
        isCrouching = true;
        capsuleCollider.height = crouchHeight;
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, crouchHeight / 2, cameraTransform.localPosition.z);
    }

    void StandUp()
    {
        isCrouching = false;
        capsuleCollider.height = originalHeight;
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, originalHeight / 2, cameraTransform.localPosition.z);
    }

    // 체력 감소 메서드
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력 증가 메서드
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }

    // 체력 UI 업데이트
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    // 플레이어 사망 처리
    private void Die()
    {
        // 게임 오버 상태 처리
        Debug.Log("Player has died!");
        // 필요한 경우 게임 오버 화면 표시 등 추가
    }
}
