using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour{
   
    public void Load(int Level)
    {
        //Загрузка  сцены по порядковому номеру сцены
        SceneManager.LoadScene(Level);
    }
}