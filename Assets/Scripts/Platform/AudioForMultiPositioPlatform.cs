using UnityEngine;

public class AudioForMultiPositioPlatform : MonoBehaviour
{
    private AudioSource falldownToWater;        //Звуковой файл
  
    void Awake()
    {
        falldownToWater = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "WaterDeadZone")
        {
            falldownToWater.Play();
        }
    }
}