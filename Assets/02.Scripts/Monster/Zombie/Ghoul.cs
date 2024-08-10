using UnityEngine;

public class Ghoul : MonoBehaviour
{
    public int HP = 100; //이거 100필요 없는데 일단..뭐..
    public Animator animator;
    
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //PLAY DEATH ANIMATION
            //animator.SetTrigger("die");
        }
        else
        {
            //Play Get Hit Animation
            animator.SetTrigger("damage");
        }
        
        ///활이긴함 script
        /// 
        ///
        /// private void OnTriggerEnter(Collider other)
        /// {
        /// Destroy(transform.GetComponet<Rigidbody>());
        /// if(other.tag == "Zombie")
        /// { other.GetComponent<Zombie>().TakeDamage(20);
        
    }
}
