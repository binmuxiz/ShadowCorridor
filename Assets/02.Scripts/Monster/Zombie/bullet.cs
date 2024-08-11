using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damageAmount = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
       if (other.tag == "Zombie")
      {    transform.parent = other.transform;
         //   other.GetComponent<Zombie>().TakeDamage(damageAmount);
       }
    }
}
