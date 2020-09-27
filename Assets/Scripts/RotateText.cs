using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateText : MonoBehaviour
{
    public float rotate;                        //переменная для указания скорости вращения

    void Update()
    {
        transform.Rotate(0, rotate * Time.deltaTime, 0);  //вызов метода поворота объекта с указанием переменной скорости поворота 
    }
}
