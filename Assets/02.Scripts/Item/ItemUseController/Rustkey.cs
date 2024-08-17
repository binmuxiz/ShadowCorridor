using UnityEngine;

public class Rustkey : IUsable
{
    private static Rustkey _instance;

    private Rustkey()
    {
    }
    
    public static Rustkey Instance()
    {
        if (_instance == null)
        {
            _instance = new Rustkey();
        }
        return _instance;
    }
    
    public bool Use() 
    {
        //  todo 여기서 Door에 dependency해야 하는거 아닌가?
        if (UseKeyOnLockedDoor())
        {
            GlobalAudioManager.Instance.Play(GlobalAudioName.Key);
            return true;
        }
        return false;
    }

    private bool UseKeyOnLockedDoor()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Door door = hit.transform.GetComponent<Door>();

            if (door!= null) // 열쇠를 문을 향해 사용한 경우 
            {
                if (door.Unlock()) return true;
            }
        }
        return false;
    }
}
