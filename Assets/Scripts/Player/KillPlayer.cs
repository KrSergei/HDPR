using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameManager gameManager;   
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();                    //Поиск объекта LevelManager        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameManager.RespawnPlayer();                    //Вызов метода RespawnPlayer из класса GameManager при срабатывании триггера
            HealthSystem.CalcHealth();                      //Вызов метода CalcHealth из класса HealthSystem при срабатывании триггера
        }
    }
}
