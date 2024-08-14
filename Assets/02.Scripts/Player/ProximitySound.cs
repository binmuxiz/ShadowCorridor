using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public Transform playerTransform;  // 플레이어의 Transform
    public Transform zombieTransform;  // 좀비의 Transform
    public AudioSource audioSource;    // 오디오 소스
    public AudioClip proximitySound;   // 재생할 소리
    public float detectionDistance = 5f; // 소리를 재생할 거리

    private bool hasPlayedSound = false; // 소리가 재생되었는지 여부

    private void Update()
    {
        // 플레이어와 좀비 사이의 거리 계산
        float distance = Vector3.Distance(playerTransform.position, zombieTransform.position);

        // 거리 조건을 충족하면 소리 재생
        if (distance < detectionDistance)
        {
            PlayProximitySound();
        }
        else
        {
            hasPlayedSound = false; // 너무 멀어지면 소리가 다시 재생될 수 있도록 설정
        }
    }

    private void PlayProximitySound()
    {
        if (!hasPlayedSound && audioSource != null && proximitySound != null)
        {
            audioSource.clip = proximitySound;
            audioSource.Play();
            hasPlayedSound = true; // 소리가 재생되었음을 기록
        }
    }
}