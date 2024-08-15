
using System;
using UnityEngine;

public class GameEnding: MonoBehaviour
{
    public static GameEnding Instance;

    public GameObject gameCanvas;
    public GameObject exitCanvas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        exitCanvas.SetActive(false);
    }

    public void EndLevel()
    {
        gameCanvas.SetActive(false);
        exitCanvas.SetActive(true);
        GlobalAudioManager.Instance.Play(GlobalAudioName.GameClear);
    }   
}
