using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    
    public void GotoPlayScene()
    {   Debug.Log("다음화면입니다.");
        SceneManager.LoadScene(1);
    }
}