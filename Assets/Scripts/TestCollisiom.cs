using UnityEngine;

public class TestCollisiom : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterDeadZone")
        {
            Debug.Log("Worked");
        }
    }
}
