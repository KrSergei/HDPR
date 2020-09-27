using UnityEngine;

public class CameraMove : MonoBehaviour
{
    #region My
    public Camera playerCamera;                         
    public Transform target;
    public float xSpeed = 150.0f;                       //Скорость вращения по оси X
    public float ySpeed = 75.0f;                        //Скорость вращения по оси Y
    public float yMinLimit = 30f;                       //Минимальное значение отклонения камеры по оси Y
    public float minDistance = 0.5f;                    //Минимальная дистанция, на которой расположена камера 
    private float _maxDistance;                         //Максимальная дистанция, на которой расположена камера
    public float hideDistance = 2f;                     //Расстояние скрытия персонажа при приближении камеры
    public LayerMask obstacles;                         //Маска для скрытия объекта
    public LayerMask noPlayer;                          //Маска для скрытия персонажа

    private Vector3 _localPosition;                     //Позиция камеры в локальных координатам цели
    private float _currentYRotation;                    //Текущий поворот камеры по оси Y
    private LayerMask _camOrigin;                       //Оригинальная маска слоев камеры    

    private Vector3 _position                           //Переменная, для получения текущей позиции камеры
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);               //Получение текущей позиции камеры
        _maxDistance = Vector3.Distance(_position, target.position);            //Получение значения максимальной дистанции от позиции цели до позиции камеры
        _camOrigin = playerCamera.cullingMask;                                  //Получение оригинальной маски слоев камеры

    }
    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);                      //Размещение камеры 
        CameraRotation();
        ObjectReact();
        PlayerReact();
        _localPosition = target.InverseTransformPoint(_position);                //Получение новой позиции камеры после вызова всех методов
    }

    /// <summary>
    /// Метод для поворота камеры
    /// </summary>
    void CameraRotation()
    {
        var mouseX = Input.GetAxis("Mouse X");                  //Получение значения перемещения мышки по оси X
        var mouseY = Input.GetAxis("Mouse Y");                  //Получение значения перемещения мышки по оси Y


        if (mouseY != 0)                                         //Поворот камеры по оси Y
        {
            //Получение занчения поворота мышки оп оси Y с указанием текущего поворота камеры и указанием лимита повора камеры по оcи Y
            var tmp = Mathf.Clamp(_currentYRotation + mouseY * ySpeed * Time.deltaTime, -yMinLimit, yMinLimit);

            if (tmp != _currentYRotation)                        //Проверка на значение новго поворота, если он не равен предыдущему, то вычисляется новый поворот
            {                                                   //путем вычитания из _currentYRotation из переменной tmp
                var rotation = tmp - _currentYRotation;
                transform.RotateAround(target.position, transform.right, rotation);  //Поворот камеры вокруг цели по оси  X на полученное значение поворота
                _currentYRotation = tmp;                //Сохранение новой позиции камеры к переменную _currentYRotation
            }
        }

        if (mouseX != 0)        //Поворот камеры по оси X
        {
            transform.RotateAround(target.position, Vector3.up, mouseX * xSpeed * Time.deltaTime);  //Поворот камеры по оси Y
        }
        transform.LookAt(target);
    }
    /// <summary>
    /// Метод для реакции камеры при столкновении с объектом
    /// </summary>
    void ObjectReact()
    {
        var distance = Vector3.Distance(_position, target.position);        //Запоминаем дистанциб между игроком и камерой
        RaycastHit hit;                                                     //Запуск луча от игрока к камере
        //Проверка на наличие препятсвия между игроком и камерой, если есть препятсвие, то перемещаем камеру на точку, где встречаем препятсвие
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, _maxDistance, obstacles))
        {
            _position = hit.point;                      //задание позиции камерыточке, где произошло столкновение с объектом
        }
        //Проверка на расстояние между камерой и игроком, если расстояние меньше чем _maxDistance и если между камерой и препятсвием есть расстояние, равное .1f, 
        //то камера увеличивает дистанцию на расстояние .05f, до значения _maxDistance
        else if (distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, -.1f, obstacles))
        {
            _position -= transform.forward * .05f;      //увеличение дистанции между камерой и игроком
        }
    }

    /// <summary>
    /// Метод для реакции камеры при столкновении с игроком
    /// </summary>
    void PlayerReact()
    {
        var distance = Vector3.Distance(_position, target.position);        //Запоминаем дистанцию между игроком и камерой
        if (distance < hideDistance)                                        //Проверка на расстояние между камерой и игроком, если оно меньше, то перемещеине камеры
        {                                                                   //перед игроком                
            playerCamera.cullingMask = noPlayer;
        }
        else
        {
            playerCamera.cullingMask = _camOrigin;
        }
    }
    #endregion
}
