using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform movingPlatform;
    public Transform position1;             //Точка передвиженния 1
    public Transform position2;             //Точка передвиженния 2
    public Vector3 newPosition;             //Переменная новая позиция для указания точки движения
    public string currentState;             //Переменная текущее состояние
    public float smooth;                    //Переменная сглаживания движения
    public float resetTime;                 //Переменная для задани паузы

    void Start()
    {
        ChangeTarget();
    }

    void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
    }

    /// <summary>
    /// Рекурсивный метод меняет переменную currentState с текущего состояни на следующее
    /// </summary>
    void ChangeTarget()
    {
        if(currentState == "Moving to position 1")
        {
            currentState = "Moving to position 2";
            newPosition = position2.position;
        }
        else if(currentState == "Moving to position 2")
        {
            currentState = "Moving to position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving to position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);   //Вызов метода ChangeTarget() с указанием времени задержки
    }
}
