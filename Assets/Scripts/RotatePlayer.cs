using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public Transform PositionTarget;  //Переменная для определения координат объект камеры
    public float turnSpeed;              //Скорость поворота персонажа

    void Update()
    {
        Vector3 direction = PositionTarget.position - transform.position;  //Вектор направления от цели поворота камеры объекта камеры до игрока
        direction.y = 0;                                                   //Задаем вектор направления по оси Y = 0 для того, что бы не наклонялась камера по оси Y
        //Вычисление поворота игрока за объектом
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);  //Создания луча от камеры по направлению вперед
        //Установка позиции объекта и направление его по оси луча
        PositionTarget.position = ray.GetPoint(15);
    }
}
