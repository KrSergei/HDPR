using UnityEngine;

public class HideObject : MonoBehaviour
{
    public GameObject Platform;


    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
        {
            Invoke("Hide", 0.5f);
        }
    }

    void Hide()
    {
        Platform.gameObject.SetActive(false);
    }
}
