using UnityEngine;

public class HideShowPlatform : MonoBehaviour
{
    public GameObject Platform;
    public float deltaTime;

    private void OnTriggerExit(Collider col)
    {
        if(col.name == "Player")
        {
            Invoke("HidePlatform", deltaTime);
        }
    }

    void HidePlatform()
    {
        Platform.gameObject.SetActive(false);
        Invoke("ShowPlatform", deltaTime);

    }

    void ShowPlatform()
    {
        Platform.gameObject.SetActive(true);
    }
}
