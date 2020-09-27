using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource playerHit;      //Звук удара игрока об препятствие или при касании поверхности 

    void Awake()
    {
        playerHit = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerHit.Play();
    }
}