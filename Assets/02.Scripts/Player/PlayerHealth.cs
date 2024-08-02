using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText; // TextMeshProUGUI 타입의 필드
    public GameObject gameOverCanvas; // GameOverCanvas 참조

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        gameOverCanvas.SetActive(false); // 시작 시 GameOverCanvas 비활성화
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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText();
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
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