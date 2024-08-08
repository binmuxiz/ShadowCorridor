
using System;
using UnityEngine;

public class GameEnding: MonoBehaviour
{
    public static GameEnding Instance;
    
    public float fadeDuration = 1f;
    public CanvasGroup exitCanvasGroup;
    public AudioSource exitAudio;

    private bool _isPlayerAtExit = false; // 탈출했는지
    private float _timer;
    private bool _hasAudioPlayed;


    public bool IsPlayerAtExit
    {
        get => _isPlayerAtExit;
        set => _isPlayerAtExit = value;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(exitCanvasGroup, false, exitAudio);
        }
    }

    private void EndLevel(CanvasGroup canvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!_hasAudioPlayed)
        {
            // audioSource.Play();
            _hasAudioPlayed = true;
        }

        _timer += Time.deltaTime;
        canvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration)
        {
            if (doRestart)
            {
                
            }
            else
            {
                // TODO 게임 인트로 씬으로 이동 
                Debug.Log("게임 끝!!");
                Application.Quit();
            }
        }
    }
    
}
