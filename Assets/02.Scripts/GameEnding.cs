using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    private bool _isPlayerAtExit;
    public CanvasGroup exitCanvasGroup;
    public CanvasGroup caughtCanvasGroup;
    private float _timer;
    private bool _isPlayerCaught;

    public AudioSource caughtAudio;
    public AudioSource exitAudio;
    private bool _hasAudioPlayed;
    private void Update()
    {
        if (_isPlayerAtExit )
        {
            EndLevel(exitCanvasGroup, false, exitAudio);
        }
        else if (_isPlayerCaught)
        { EndLevel(caughtCanvasGroup, true, caughtAudio);}
    }

    private void EndLevel(CanvasGroup canvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!_hasAudioPlayed)
        {
            audioSource.Play();
            _hasAudioPlayed = true;
        }
        _timer += Time.deltaTime;
        canvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration)
        {
            if (doRestart)
            {
                Debug.Log("게임 다시 시작");
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("게임 끝");
                Application.Quit(); 
            }
         
        }
    }

private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }
}

