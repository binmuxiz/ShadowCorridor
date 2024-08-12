using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // 기존 변수들
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

    public float rotationSpeed = 1.0f;

    // 체력 관련 변수
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText;
    [SerializeField] private RawImage healthImage;

    // 체력 증가 관련 변수
    private float healthRegenTimer = 0f; // 체력 회복 타이머
    public float healthRegenInterval = 2f; // 2초마다 회복

    // 게임 오버 패널
    [SerializeField] private GameObject gameOverPanel;

    // 스테미너 바 UI 오브젝트
    public GameObject staminaBar;

    // 캐비닛 관련 변수
    private bool isInsideCabinet = false;
    private Vector3 originalCameraPosition;
    private Vector3 originalCameraRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        cameraTransform = Camera.main.transform;
        originalHeight = capsuleCollider.height;
        rb.freezeRotation = true;

        currentHealth = maxHealth;
        UpdateHealthUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        originalCameraPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        if (!isInsideCabinet)
        {
            // 마우스 입력 처리
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            transform.Rotate(Vector3.up * mouseX);

            verticalLookRotation -= mouseY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            cameraTransform.localEulerAngles = Vector3.right * verticalLookRotation;

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Crouch();
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                StandUp();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(10);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Heal(10);
            }

            // 체력 증가 로직
            healthRegenTimer += Time.deltaTime;
            if (healthRegenTimer >= healthRegenInterval)
            {
                if (currentHealth < maxHealth)
                {
                    Heal(1);
                }
                healthRegenTimer = 0f; // 타이머 초기화
            }
        }
        else
        {
            // 캐비닛 내부에 있을 때 E 키를 누르면 캐비닛에서 나옴
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitCabinet();
            }
        }

        if (Input.GetMouseButtonDown(0) && !isInsideCabinet)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 25.0f))
            {
                if (hit.collider.CompareTag("Cabinet"))
                {
                    EnterCabinet(hit.collider.gameObject);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!isInsideCabinet)
        {
            float speed = isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);

            float moveForward = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
            float moveSide = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

            Vector3 move = transform.right * moveSide + transform.forward * moveForward;
            rb.MovePosition(rb.position + move);
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

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI(); // UI 업데이트
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");

        if (healthText != null)
        {
            healthText.gameObject.SetActive(false);
        }

        if (healthImage != null)
        {
            healthImage.gameObject.SetActive(false);
        }

        if (staminaBar != null)
        {
            staminaBar.SetActive(false); // 스테미너 바 비활성화
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void EnterCabinet(GameObject cabinet)
    {
        isInsideCabinet = true;
        originalCameraPosition = cameraTransform.localPosition;
        originalCameraRotation = cameraTransform.localEulerAngles;

        // 캐비닛 안쪽으로 카메라 위치 이동
        cameraTransform.position = cabinet.transform.Find("CameraPosition").position;
        cameraTransform.rotation = Quaternion.LookRotation(cabinet.transform.forward);

        // 플레이어 움직임과 회전 비활성화
        rb.isKinematic = true;
    }

    private void ExitCabinet()
    {
        isInsideCabinet = false;

        // 플레이어 움직임과 회전 활성화
        rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Die();
        }
    }
}
