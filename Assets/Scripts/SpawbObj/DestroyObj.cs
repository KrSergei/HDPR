using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public new GameObject gameObject;

    /// <summary>
    /// Уничтожение обекта при выходе за границы коллайдера
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit(Collider col)
    {
        if(col.tag != "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
