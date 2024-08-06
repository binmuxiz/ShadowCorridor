using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   public float moveSpeed = 3f;

   private float gravity = -20f;
   private float yVelocity = 0;

   private CharacterController cc;

   Vector3 dir = new Vector3();

   private void Start()
   {
      cc = GetComponent<CharacterController>();
   }

   void Update()
   {
      dir = Camera.main.transform.TransformDirection(dir);

      yVelocity += gravity * Time.deltaTime;
      dir.y = yVelocity;

      cc.Move(dir * moveSpeed * Time.deltaTime);


      yVelocity += gravity * Time.deltaTime;
      dir.y = yVelocity;

      cc.Move(dir * moveSpeed * Time.deltaTime);
   }
}

    
