using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private static int health;                  //Текущее количество жизней от максимального
    private int numberOfLives;                  //Текущее количество жизней от текущего значения жизней

    public Image[] lives;                       //Максимальное количество жизней

    public Sprite fullLife;                     //Переменная для указания полной жизни
    public Sprite emptyLife;                    //Переменная для указания потраченной жизни      
    //private bool isDead = false;

    /// <summary>
    /// Метод, который уменьшает количество жизней
    /// </summary>
    public static int CalcHealth()
    {
        health --;
        return health;
    }

    /// <summary>
    /// Метод возвращает истину 
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return (health == 0) ? true : false;
    }

    private void Start()
    {
        health = 5;   //Инициализация переменной healfh
        numberOfLives = 5; //Инициализация переменной numberOfLives
    }

    void  FixedUpdate()
    {
       
        if (health > numberOfLives)  //Ограничение максимального количества жизней
        {
            health = numberOfLives;
        }
        if(health == 0)
        {
            IsDead();
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLife;
            }
            else
            {
                lives[i].sprite = emptyLife;
            }
            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }
}
