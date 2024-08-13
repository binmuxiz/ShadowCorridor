using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public RectTransform staminaBar;  // 실제 스테미너 바의 RectTransform
    public float maxStamina = 100f;
    private float currentStamina;
    public float staminaUsageRate = 70f;  // 스태미너 소모율
    public float staminaRecoveryRate = 10f;  // 스태미너 회복율

    private float originalWidth;  // 스태미너 바의 원래 너비

    void Start()
    {
        currentStamina = maxStamina;
        originalWidth = staminaBar.sizeDelta.x;  // 초기 스태미너 바의 너비 저장

        // 중앙 고정을 위해 pivot을 중앙에 설정
        staminaBar.pivot = new Vector2(0.5f, 0.5f);
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
        // 스테미너 비율 계산
        float staminaRatio = currentStamina / maxStamina;

        // 스테미너 바의 너비 조정
        staminaBar.sizeDelta = new Vector2(originalWidth * staminaRatio, staminaBar.sizeDelta.y);
    }
}