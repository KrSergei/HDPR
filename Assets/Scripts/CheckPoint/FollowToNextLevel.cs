using UnityEngine;
using UnityEngine.SceneManagement;


public class FollowToNextLevel : MonoBehaviour
{
    public GameObject MenuNextLevel;                    //Объект - меню для перехода на следующий уровень
    private int indexCurrentScene;                      //Индекс текущей сцены
    public GameObject Panel;                            //Ссылка на панель на кторой находятся кнопки для их деактивации

    private void Start()
    {
        //Определяем индекс текущей сцены
        indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
    }


    /// <summary>
    /// При попадании игрока в триггер, игра становится на паузу и активируется объект - меню перехода на следующий уровень
    /// </summary>
    /// <param name="col">Коллайдер с именем "Player"</param>
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //Сцена становится на паузу
            Time.timeScale = 0F;
            /*Активация меню перехода на другой уровень, в зависимости от текущего индекса сцены:
             * если индекс равен 1, деактивируется кнопка "Prev_btn" для переходя на предыдущий уровень,
             * если индекс равен 4, деактивируется кнопка "Next_btn" для переходя на следующий уровень,
             * иначе активируются все кнопки
            */
            MenuNextLevel.SetActive(true);
            if (indexCurrentScene == 1)
            {
                //Деактивация кнопки "Prev_btn"
                Panel.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if(indexCurrentScene == 4)
            {
                //Деактивация кнопки "Next_btn"
                Panel.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Метод для перехода на следующий уровень
    /// </summary>
    public void CoToNextLvl()
    {
        //Загрузка следующей сцены - индекс текущей сцены + 1
        SceneManager.LoadScene(indexCurrentScene + 1);
        //Выключение паузы
        Time.timeScale = 1F;
    }

    /// <summary>
    /// Метод для рестарта текущей сцены
    /// </summary>
    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Выключение паузы
        Time.timeScale = 1F;
    }

    /// <summary>
    /// Метод для перехода на предыдущий уровень
    /// </summary>
    public void GoToPreviousLvl()
    {
        //Загрузка следующей сцены - индекс текущей сцены - 1
        SceneManager.LoadScene(indexCurrentScene - 1);
        //Выключение паузы
        Time.timeScale = 1F;
    }

    /// <summary>
    /// Метод для выхода из игры
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}