using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToObject : MonoBehaviour
{
    public Transform objToFollow;   //Переменаая для указания позиции вудущего объекта
    private Vector3 deltaPosition;  //Переменная расстояние между объектами


    void Start()
    {
        deltaPosition = transform.position - objToFollow.position;  //Расчет расстояния между объектами - текущая позиция объекта минус позиция ведущего объекта
    }

     void Update()
    {
        transform.position = objToFollow.position + deltaPosition;  //Изменение позиции объекта - текущая позиция объекта плюс расстояние между объектами
    }
}
