using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 2.0f;
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

    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText;
    [SerializeField] private RawImage healthImage;

    private float healthRegenTimer = 0f;
    public float healthRegenInterval = 2f;

    [SerializeField] private GameObject gameOverPanel;

    public float maxStamina = 100f;
    private float currentStamina;
    public float staminaRegenRate = 5f;
    public float staminaDrainRate = 10f;
    public float staminaThreshold = 40f;
    public float lowStaminaSpeed = 1.5f;
    public Slider staminaSlider;

    public static bool isInsideCabinet = false;
    public bool isHiding = false; // 캐비닛에 숨었는지 여부를 나타내는 변수 추가
    private Vector3 originalCameraPosition;
    private Vector3 originalCameraRotation;

    private Vector3 originalPlayerPosition;
    private Quaternion originalPlayerRotation;

    private int _layerMask;

    public AudioSource audioSource;
    public AudioClip enterCabinetSound;
    public AudioClip exitCabinetSound;

    // 추가된 변수들
    public AudioClip walkSound; // 걷는 소리
    public AudioClip runSound; // 뛰는 소리
    private float stepTimer = 0.0f; // 발자국 소리 간격을 위한 타이머
    public float walkStepInterval = 0.5f; // 걷기 시 발자국 소리 간격
    public float runStepInterval = 0.3f; // 뛰기 시 발자국 소리 간격

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

        _layerMask = 1 << LayerMask.NameToLayer("Cabinet");

        currentStamina = maxStamina;
        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = currentStamina;
        }

        // 오디오 소스 초기화
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (!isInsideCabinet)
        {
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

            if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
            {
                currentStamina -= staminaDrainRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }
            else
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }

            if (staminaSlider != null)
            {
                staminaSlider.value = currentStamina;
            }

            healthRegenTimer += Time.deltaTime;
            if (healthRegenTimer >= healthRegenInterval)
            {
                if (currentHealth < maxHealth)
                {
                    Heal(1);
                }
                healthRegenTimer = 0f;
            }

            // 발자국 소리 처리
            HandleFootsteps();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitCabinet();
            }
        }

        if (Input.GetMouseButtonDown(0) && !isInsideCabinet)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 25.0f, _layerMask))
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
            float speed;

            if (currentStamina <= staminaThreshold)
            {
                speed = lowStaminaSpeed;
            }
            else
            {
                speed = isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
            }

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
        UpdateHealthUI();
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

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void EnterCabinet(GameObject cabinet)
    {
        isInsideCabinet = true;
        isHiding = true; // 플레이어가 캐비닛에 숨었음을 표시

        // 플레이어의 위치와 회전을 저장
        originalPlayerPosition = transform.position;
        originalPlayerRotation = transform.rotation;

        // 플레이어의 위치를 캐비닛 안으로 이동
        Transform playerPosition = cabinet.transform.Find("PlayerPosition");
        Transform cameraPosition = cabinet.transform.Find("CameraPosition");

        if (playerPosition == null || cameraPosition == null)
        {
            Debug.LogError("PlayerPosition or CameraPosition not found in the cabinet!");
            return;
        }

        transform.position = playerPosition.position;
        transform.rotation = playerPosition.rotation;

        // 카메라의 위치와 회전 저장
        originalCameraPosition = cameraTransform.localPosition;
        originalCameraRotation = cameraTransform.localEulerAngles;

        // 카메라의 위치와 회전을 캐비닛 내부에 맞춤
        cameraTransform.position = cameraPosition.position;
        cameraTransform.rotation = cameraPosition.rotation;

        rb.isKinematic = true;

        if (audioSource != null && enterCabinetSound != null)
        {
            audioSource.PlayOneShot(enterCabinetSound);
        }
    }

    private void ExitCabinet()
    {
        isInsideCabinet = false;
        isHiding = false; // 플레이어가 캐비닛에서 나왔음을 표시

        // 플레이어의 위치와 회전을 원래대로 복원
        transform.position = originalPlayerPosition;
        transform.rotation = originalPlayerRotation;

        rb.isKinematic = false;

        if (audioSource != null && exitCabinetSound != null)
        {
            audioSource.PlayOneShot(exitCabinetSound);
        }

        cameraTransform.localPosition = originalCameraPosition;
        cameraTransform.localEulerAngles = originalCameraRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie") && !isInsideCabinet)
        {
            Die();
        }
    }

    // 발자국 소리 처리 메서드
    void HandleFootsteps()
    {
        // 플레이어가 움직이고 있는지 확인
        bool isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;
        
        if (isMoving)
        {
            // 걷고 있는지, 달리고 있는지에 따라 다른 소리를 재생
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // 달리기
                    audioSource.PlayOneShot(runSound);
                    stepTimer = runStepInterval;
                }
                else
                {
                    // 걷기
                    audioSource.PlayOneShot(walkSound);
                    stepTimer = walkStepInterval;
                }
            }
        }
        else
        {
            // 플레이어가 움직이지 않을 때 타이머 초기화
            stepTimer = 0.0f;
        }
    }
}
