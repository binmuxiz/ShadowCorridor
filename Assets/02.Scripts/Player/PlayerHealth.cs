using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요
using UnityEngine.SceneManagement; // 씬 관리를 위해 필요

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText; // TextMeshProUGUI 타입의 필드
    public GameObject gameOverCanvas; // GameOverCanvas 참조

    private float healthRegenTimer = 0f; // 체력 회복 타이머
    public float healthRegenInterval = 10f; // 10초마다 회복
    public AudioSource hurtAudio;
    private bool isGameOver = false; // 게임 오버 상태를 추적
    public float startTime = 0.4f; // 원하는 시작 시간 (초)

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
        if (isGameOver)
        {
            // 게임 오버 상태에서 스페이스바 입력을 감지
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 씬 0으로 이동
                SceneManager.LoadScene(0);
            }
            return; // 게임 오버 상태에서는 아래 로직을 실행하지 않음
        }

        // 체력 증가 로직
        healthRegenTimer += Time.deltaTime;
        if (healthRegenTimer >= healthRegenInterval)
        {
            if (currentHealth < maxHealth)
            {
                IncreaseHealth(1);  // 10초마다 체력 1 회복
            }
            healthRegenTimer = 0f; // 타이머 초기화
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HarmfulObject")) // Box Collider가 있는 오브젝트에 "HarmfulObject" 태그를 추가
        {
            TakeDamage(10);
            hurtAudio.Play();
            hurtAudio.time = startTime;  // 재생 시작 지점 설정
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
        healthText.text = "" + currentHealth;
    }

    void Die()
    {
        // 체력이 0이 되었을 때 GameOverCanvas 활성화
        Debug.Log("Player Died!");
        gameOverCanvas.SetActive(true);
        isGameOver = true; // 게임 오버 상태로 설정
        Time.timeScale = 0f; // 게임을 멈추기 위해 TimeScale을 0으로 설정
    }
}
 