using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText; // TextMeshProUGUI 타입의 필드

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HarmfulObject")) // Box Collider가 있는 오브젝트에 "HarmfulObject" 태그를 추가
        {
            TakeDamage(5);
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
        // 플레이어가 죽었을 때 처리
        Debug.Log("Player Died!");
        // 여기서 원하는 죽음 처리 로직을 추가
    }
}