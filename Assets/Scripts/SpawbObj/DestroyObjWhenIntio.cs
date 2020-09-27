using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjWhenIntio : MonoBehaviour
{
    public new GameObject gameObject;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
