using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    public float rotate;            //переменная для указания скорости вращения

    void Update()
    {
        transform.Rotate(rotate, 0, rotate);  //вызов метода поворота объекта с указанием переменной скорости поворота 
    }
}
