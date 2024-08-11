using UnityEngine;

public class Ghoul : MonoBehaviour
{
    public int HP = 10000; //이거 100필요 없는데 일단..뭐..
    public Animator animator;
    
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //PLAY DEATH ANIMATION
            //AudioManager.instance.Play("")
            //animator.SetTrigger("die");
            //GetComponent<Collider>().enabled = false;
        }
        else
        {
            //Play Get Hit Animation
            AudioManager.instance.Play("ZombieDamage");
            animator.SetTrigger("damage");
        }
        

        
    }
}
