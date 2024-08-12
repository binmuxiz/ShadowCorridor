
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    
    //추가해야할 것 : zombie가 지나가면 flicker가동!!

    public Light lightOB;
  
    public float minTime;
    public float maxTime;
    public float timer;
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update() 
    {
        LightsFlickering();
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
