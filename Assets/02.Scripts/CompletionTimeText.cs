using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요
public class CompletionTimeText : MonoBehaviour
{
    
    public TextMeshProUGUI completionTimeText; // 게임 완료 시간을 표시할 TextMeshPro UI
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 게임 완료 시간 계산
        float completionTime = Time.timeSinceLevelLoad;

        int minutes = Mathf.FloorToInt(completionTime / 60F);
        int seconds = Mathf.FloorToInt(completionTime % 60F);
        int milliseconds = Mathf.FloorToInt((completionTime * 1000F) % 1000F);

        // 게임 완료 시간을 "MM:SS:FFF" 형식으로 변환
        string timeText = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds / 10);

        // UI 텍스트에 게임 완료 시간 표시
        completionTimeText.text = timeText; 
    }

  
}