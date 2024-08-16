using UnityEngine;
using TMPro; // TextMeshPro를 사용할 경우 필요

public class PlayTimeManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeText; // 플레이타임을 표시할 TextMeshPro UI
    public TextMeshProUGUI completionTimeText; // 총 플레이타임 UI 

    private float _startTime;
    private float _completionTime;

    void Start()
    {
        _startTime = Time.time; // 게임이 시작된 시간
    }

    void Update()
    {
        float elapsedTime = Time.time - _startTime; // 경과 시간 계산
        // UI 텍스트에 경과 시간 표시
        playTimeText.text =  ConvertToString(elapsedTime);

        _completionTime = elapsedTime;
    }
    
    public void ShowCompletionTime()
    {
        completionTimeText.text = ConvertToString(_completionTime);
    }
    
    private string ConvertToString(float time)
    {
        // 경과 시간을 분, 초, 밀리초로 변환
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);

        // 경과 시간을 "MM:SS:FFF" 형식의 문자열로 변환
        string timeText = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds / 10);

        return timeText;
    }
}