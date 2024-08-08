using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public Image staminaBar; // 실제 스테미너를 나타내는 UI 이미지
    public float maxStamina = 100f;
    private float currentStamina;
    public float staminaUsageRate = 10f; // 스테미너 소모율
    public float staminaRecoveryRate = 5f; // 스테미너 회복율

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            UseStamina(staminaUsageRate * Time.deltaTime);
        }
        else
        {
            RecoverStamina(staminaRecoveryRate * Time.deltaTime);
        }
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateStaminaBar();
    }

    public void RecoverStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateStaminaBar();
    }

    private void UpdateStaminaBar()
    {
        staminaBar.fillAmount = currentStamina / maxStamina;
    }
}