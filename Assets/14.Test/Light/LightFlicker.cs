
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    
    public Light lightOB;
    public float triggerDistance = 5f; // 좀비가 얼마나 가까워져야 전등이 깜빡이는지 설정하는 거리
    public float minTime;
    public float maxTime;
    public float timer;
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
        lightOB.enabled = false; //시작할때 꺼져있어야 하는 거 다시 설정해야함!!
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

        foreach (GameObject zombie in zombies)
        {
            float distanceToZombie = Vector3.Distance(zombie.transform.position, transform.position);

            if (distanceToZombie <= triggerDistance)
            {
                LightsFlickering();
                return;
            }
        }

        lightOB.enabled = true;
    }


    void LightsFlickering()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            lightOB.enabled = !lightOB.enabled;
            timer = Random.Range(minTime, maxTime);
           
        }
    }
    
    
}
