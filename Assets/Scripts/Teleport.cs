using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleport;
    private AudioSource teleportSound;

    private void Awake()
    {
        teleportSound = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.transform.position = teleport.transform.position;
            teleportSound.Play();
        }
    }
}