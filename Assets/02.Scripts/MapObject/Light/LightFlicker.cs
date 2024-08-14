
using UnityEngine;
using UnityEngine.Serialization;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    public float triggerDistance = 5f; // 좀비가 얼마나 가까워져야 전등이 깜빡이는지 설정하는 거리
    public float minTime;
    public float maxTime;
    public float timer;

    private float firstIntensity;
    
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
        firstIntensity = light.intensity;
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
    }


    void LightsFlickering()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            light.intensity = Random.Range(0.1f, 1f) * firstIntensity;
            timer = Random.Range(minTime, maxTime);
        }
    }
}
