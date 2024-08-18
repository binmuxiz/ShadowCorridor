using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    
    public void GotoPlayScene() {
        SceneManager.LoadScene("Beta");
    }
}