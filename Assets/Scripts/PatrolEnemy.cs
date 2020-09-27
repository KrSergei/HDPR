using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] pointPatrol;                 //Массив точек патрулирования 
    public float speedEnemy;                        //Скорость движения     
    private int randomPointPatrol;                  //Случайная точка патрулирования
    public float startWaitTime;                     //Время начала движения
    private float waitTime;                         //Время ожидания начало движеиня после достижения точки патрулирования

    
    void Start()
    {
        //Установка времени ожидания
        waitTime = startWaitTime;
        //Определение случайной точки патрулирования из массива точек патрулирования
        randomPointPatrol = Random.Range(0, pointPatrol.Length);
    }

    
    void Update()
    {
        //Движение к выбранной точке патрулирования с указанной скоростью
        transform.position = Vector3.MoveTowards(transform.position, pointPatrol[randomPointPatrol].position, speedEnemy * Time.deltaTime);
        //Проверка на расстояние междуточкой патрулирования и текущем положением, и если оно меньше чем 0.2f, то возврат на стартовую позицию.
        if(Vector3.Distance(transform.position, pointPatrol[randomPointPatrol].position) < 0.2f)
        {
            //Проверка времени ожидания, если оно меньше либо равно 0, то начинается движения к новой точке,иначе идетуменьшение времени
            if (waitTime <=0f)
            {
                //Определение случайной точки патрулирования из массива точек патрулирования
                randomPointPatrol = Random.Range(0, pointPatrol.Length);
                //Установка времени ожидания
                waitTime = startWaitTime;
            }
            else
            {
                //Уменьшение времени ожидания
                waitTime -= Time.deltaTime;
            }
        }
    }
}
