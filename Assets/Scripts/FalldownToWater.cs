using UnityEngine;

public class FalldownToWater : MonoBehaviour
{
    private AudioSource falldownObject;      //Звук падения в воду

    void Awake()
    {
        falldownObject = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            falldownObject.Play();
        }
    }
}