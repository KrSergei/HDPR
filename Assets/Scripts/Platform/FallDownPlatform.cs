using UnityEngine;

public class FallDownPlatform : MonoBehaviour
{
    public Rigidbody rb;
    public float delayTimeFall = 1.5f;          //Время, через которое платформа начинает движение
    private Vector3 currentPosition;            //Текущая позиция платформы  
    private bool moveingBack;                   //Флаг о необходимости возврата платформы
    public float movingDistance;                //Расстояние перемещения платформы
    public float timeBack;                      //Время через которое начинается подъем платформы


    void Start()
    {
        rb = GetComponent<Rigidbody>();             //получение компонента Rigidbody
        currentPosition = transform.position;       //получение текущей позиции платформы
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && moveingBack == false)
        {            
            Invoke("FallPlatform", delayTimeFall);
        }
    }

    /// <summary>
    /// Метод, указывающий на разшение начала движения платформы
    /// </summary>
    private void FallPlatform()
    {
        rb.isKinematic = false;                     //Отключение кинематики для падения платформы
        Invoke("MovingBackPlatform", timeBack);         //Вызов метода для подъема платформы  через 1 секунду после падения
    }

    /// <summary>
    /// Метод для возвращения платформы в исходное состояние
    /// </summary>
    private void MovingBackPlatform()
    {
        rb.velocity = Vector3.zero;                 //Установка скорости передвижения в 0
        rb.isKinematic = true;                      
        moveingBack = true;                         //Установка moveingBack = true, для указания движения платформы обратно
        
    }

    private void FixedUpdate()
    {
        if (moveingBack == true)                    //Проверка флага возвращение платформы на true, если то возвращение платформы на стартовую позицию
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPosition, movingDistance * Time.deltaTime) ;
        }
        if (transform.position.y == currentPosition.y)               //Сравнение текущей позиции платформы, если текущее положение равно стартовому, 
        {                                                            //то флаг moveingBack = false;
            moveingBack = false;
        }
    }
}
