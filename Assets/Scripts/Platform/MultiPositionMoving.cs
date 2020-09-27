using UnityEngine;

public class MultiPositionMoving : MonoBehaviour
{
    /// <summary>
    /// Класс, уоторый описывает движение платформы по указанным контрольным точкам. Контрольные точки передвижения указываются в масссиве Transform[] MoveSpot;
    /// Движение платформы начинается от стартовой позиции платформы и к текущей контрольной точке. Позиция текущей контрольной точки береться из масссива Transform[] MoveSpot
    /// по индексу массива. После достижения дистанции между контрольной точкой и текущем положением платфомы менее 0.2, начинается движение к другой контрольной точке 
    /// с индексом +1 от текущего
    /// </summary>

    public float speed;                     //Скорость передвижения платформы
    public Transform movingObj;             //Трансформ передвигаемой платформы
    public Transform[] MoveSpot;            //Массив для контрольных точек передвижения
    Vector3 newPosition;                    //Переменная новая позиция для указания точки движения
    int currentIndexPosition = 0;           //Переменная для указания индекса позиции 

    void Start()
    {
        //Определяем новыю позицию платформы, как контрольную точку с индеком 0
        newPosition = MoveSpot[0].position;       
        ChangePosition();
    }

 
    void Update()
    {
        //Указание новой позиции платформы
        movingObj.position = Vector3.Lerp(movingObj.position, newPosition, speed * Time.deltaTime);
    }

    /// <summary>
    /// Метод для смены позиции пплатформы между контрольными точками  массива Transform[] MoveSpot
    /// </summary>
    void ChangePosition()
    {
        //вычисляем расстояние между текущем положением платформы и положением контрольной точки, если < 0.2f
        if (Vector3.Distance(movingObj.position, MoveSpot[currentIndexPosition].position) < 0.2f)
        {
            //Проверяем текущий индекс, если он равен длинне элементов массива -1, то устанавливаем currentIndexPosition=0, для движения платформы к контрольной точке с индексом 0
            if (currentIndexPosition == MoveSpot.Length - 1)
            {
                //установка индекса позиции = 0
                currentIndexPosition = 0;
                //указанием новой позиции с индексом currentIndexPosition
                newPosition = MoveSpot[currentIndexPosition].position;
            }
            else 
            {
                //установка индекса позиции +1 от текущего
                currentIndexPosition++;
                //указанием новой позиции с индексом currentIndexPosition
                newPosition = MoveSpot[currentIndexPosition].position;
            }
        } 
        Invoke("ChangePosition", 1f);       
    }
}
