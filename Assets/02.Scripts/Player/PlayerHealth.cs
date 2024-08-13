using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText; // TextMeshProUGUI 타입의 필드
    public GameObject gameOverCanvas; // GameOverCanvas 참조

    private float healthRegenTimer = 0f; // 체력 회복 타이머
    public float healthRegenInterval = 10f; // 2초마다 회복

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        gameOverCanvas.SetActive(false); // 시작 시 GameOverCanvas 비활성화
    }

    void Update()
    {
        // 체력 증가 로직
        healthRegenTimer += Time.deltaTime;
        if (healthRegenTimer >= healthRegenInterval)
        {
            if (currentHealth < maxHealth)
            {
                IncreaseHealth(1);  // 2초마다 체력 1 회복
            }
            healthRegenTimer = 0f; // 타이머 초기화
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HarmfulObject")) // Box Collider가 있는 오브젝트에 "HarmfulObject" 태그를 추가
        {
            TakeDamage(10);
        }
        else if (other.gameObject.CompareTag("Zombie")) // 좀비와 충돌을 감지
        {
            TakeDamage(currentHealth); // 좀비와 닿았을 때 체력을 0으로 설정
        }
    }

    public void IncreaseHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthText();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthText();
        
        if (currentHealth <= 0) Die();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth;
    }

    void Die()
    {
        // 체력이 0이 되었을 때 GameOverCanvas 활성화
        Debug.Log("Player Died!");
        gameOverCanvas.SetActive(true);
        // 추가적인 죽음 처리 로직을 여기에 추가할 수 있습니다.
        Time.timeScale = 0f; // 게임을 멈추기 위해 TimeScale을 0으로 설정
    }
}
