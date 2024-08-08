using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 키보드 입력 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0f, v);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);

        // Transform으로 움직이는 걸 CharacterController로 움직이도록 변경 
        cc.Move(moveSpeed * Time.deltaTime * dir);
    }
}