using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    HealthSystem healthSystem;
    private bool isDead;
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    private PlayerController player;

    void Start()
    {
        healthSystem = new HealthSystem();
        player = FindObjectOfType<PlayerController>();
        isDead = false;         //Установка булевой переменной на isDead на значение true или false из класса HealthSystem
    }

    private void Update()
    {
        isDead = healthSystem.IsDead();
        if (isDead)                            
        {
            Invoke("Pause", 0.2f);                  //Если isDead равно true, вызов метода Pause для выхода в меню
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)                      //Проверка значения  GameIsPause
            {
                Resume();                       //Вызов метода  Resume, если GameIsPause == false
            }
            else
            {
                Pause();                        //Вызов метода Pause,  если GameIsPause == true
            }
        }
    }

    public void RespawnPlayer()
    {
       player.transform.position = currentCheckpoint.transform.position;    //Установка позиции игрока  равной текущей позиции чекпоинта
    }


    /// <summary>
    /// Метод для перезагрузки сцены
    /// </summary>
    public void ReloadScene()
    {
        Resume();                                                      //Вызов метода Resume() для выхода из меню
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    //Загрузка сцены заново
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1F;             //Восстановление движения в игре
        GameIsPause = false;
    }

    /// <summary>
    /// Метоод пауза в игре
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0F;             //Остановка движения в игре
        GameIsPause = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
