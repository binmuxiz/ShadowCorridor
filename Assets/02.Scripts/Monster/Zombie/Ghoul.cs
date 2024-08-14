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
        
        //그리고 좀비 속도 너무 빨라
    }
}
