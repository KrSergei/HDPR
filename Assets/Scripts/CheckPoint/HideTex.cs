using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTex : MonoBehaviour
{
    public GameObject text;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            text.gameObject.SetActive(true);
        }
    }
}
