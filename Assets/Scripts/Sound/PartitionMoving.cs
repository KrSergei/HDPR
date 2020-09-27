using UnityEngine;

public class PartitionMoving : MonoBehaviour
{
    private AudioSource movingSound;

    void Awake()
    {
        movingSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            movingSound.Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            movingSound.Stop();
        }
    }
}
