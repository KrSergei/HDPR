using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject PlayerCamera;
    Vector3 direction;
    public float moveForce;                     //Переменная для указания силы ускорения
    public float jumpForce;                     //Переменная для указания силы прыжка
    public bool _isGrounded;                    //Переменная указания нахождения на поверхности
    public float raicastHit;

    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveLogic();
        JumpLogic();
    }

    /// <summary>
    /// Метод, реализующий логику управления персонажем
    /// </summary>
    private void MoveLogic()
    {
        var AD = Input.GetAxisRaw("Horizontal");         //Получение команды по горизонтали при нажатии клавиш A и D
        var WS = Input.GetAxisRaw("Vertical");           //Получение команды по вертикаои при нажатии клавиш W и S

        if (WS >0)
        {
            rb.AddForce(PlayerCamera.transform.forward * moveForce);    //Движение игрока в заданном направлении
        }
        if (WS < 0)
        {
            rb.AddForce(PlayerCamera.transform.forward * - moveForce);
        }
        if (AD < 0)
        {
            rb.AddForce(PlayerCamera.transform.right * - moveForce);    //Движение игрока в заданном направлении
        }
        if (AD > 0)
        {
            rb.AddForce(PlayerCamera.transform.right * moveForce);    //Движение игрока в заданном направлении
        }       
    }

    /// <summary>
    /// Метод реализации прыжка. Создаем луч, который направляем вниз для проверки столкновения с препятсвием на расстоянии радиуса сферы. Если он сталкивается с препятсием, 
    /// сфера находится на земле, если нет, то сфера находится в воздухе
    /// </summary>
    private void JumpLogic()
    {
        //Создаем луч, который направляем от центра позиции игрока вниз  
        Debug.DrawRay(gameObject.transform.position, Vector3.down * raicastHit, Color.red);
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rayHit;
        //Проверка на столкновение с препятствием, если есть столкновение, то isGrounded = true, иначе = false
        if (Physics.Raycast(ray, out rayHit, raicastHit))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        if ((Input.GetAxis("Jump") > 0) && _isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce);            //Реализация логики прыжка
        }
    }   
    #endregion
}