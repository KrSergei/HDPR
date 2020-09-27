using UnityEngine;

public class JumpFromObj : MonoBehaviour
{
    public float force;                      //Переменная для указания величины отскока от столкновения

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRb;
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            playerRb.AddForce(transform.up * force);
        }            
    }
}
