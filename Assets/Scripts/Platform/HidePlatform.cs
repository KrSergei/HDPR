using UnityEngine;

public class HidePlatform : MonoBehaviour
{
    public GameObject Platform;

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
           Invoke("HideObject", 1f);
        }
    }

    void HideObject()
    {
        Destroy(Platform.gameObject);
    }
}
