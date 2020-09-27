using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckPoint : MonoBehaviour
{
    public GameManager levelManager;
    public GameObject text;
    void Start()
    {
        levelManager = FindObjectOfType<GameManager>();
    }
    
    /// <summary>
    /// Метод сохранения индекса чекпоинта при попадании в него игрока
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.currentCheckpoint = gameObject;        //Установка позиции чекпоинта на позиции объекта
            text.gameObject.SetActive(false);
        }
    }
}
