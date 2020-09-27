using System.Collections;
using UnityEngine;

public class SpawnShpere : MonoBehaviour
{
    public Transform SpawnArea;
    public GameObject SpawnObj;
    /// <summary>
    /// Переменные для определения размеров зоны падения сфер
    /// </summary>
    float minX;                                     
    float maxX;
    float minZ;
    float maxZ;
    //Переменная, указывающая время, через которое появляеются новые сферы
    public float timeSpawn = 1.0f;                  


    /// <summary>
    /// В методе определz.ncz размеры зоны, где будут появляться сферы
    /// Размер зоны определяется следующим образом:
    /// От центра размещения SpawnArea по осям Х и Z добавляется и отнимается необходимые значения
    /// </summary>
    void Start()
    {
        minX = SpawnArea.position.x - SpawnArea.localScale.x * 3;       
        maxX = SpawnArea.position.x + SpawnArea.localScale.x * 3;      
        minZ = SpawnArea.position.z - SpawnArea.localScale.z * 7;
        maxZ = SpawnArea.position.z + SpawnArea.localScale.z * 7;       
    }

    /// <summary>
    /// Метод для активации падения сфер
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            StartCoroutine(Spawn());
        }
    }

    /// <summary>
    /// Метод генерирующий 10 падающих сфер в случайной позиции в заданной зоне через заданное время timeSpawn
    /// Для сферы генерится рандомная позиция с заданной высотой
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeSpawn);
        for (int i = 0; i < 10; i++)
        {
            //Задание нового вектора для сферы
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), SpawnArea.position.y, Random.Range(minZ, maxZ));
            //Создание объекта, указываем объект, с генерированной позицией и угловм вращения по умолчанию
            Instantiate(SpawnObj, spawnPos, Quaternion.identity);
        }   
       //Рекурсивный вызов метода 
       StartCoroutine(Spawn());
    }
}
