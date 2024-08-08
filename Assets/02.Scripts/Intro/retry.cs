using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    
    public void GotoPlayScene()
    {   Debug.Log("다음화면입니다.");
        SceneManager.LoadScene(0);
    }
}