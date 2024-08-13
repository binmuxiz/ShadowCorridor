using UnityEngine;

public class Ghoul : MonoBehaviour
{
    public Animator animator;
    
    public void TakeDamage()
    {
        Debug.Log("Ghoul.TakeDamage()");
        //Play Get Hit Animation
        AudioManager.instance.Play("ZombieDamage");
        animator.SetTrigger("damage");
        
        //TODO 경민아 Animation 클립이 너무 짧음(좀비가 넘어져 있는 시간이 너무 짧음) 그리고 좀비 속도 너무 빨라
    }
}
