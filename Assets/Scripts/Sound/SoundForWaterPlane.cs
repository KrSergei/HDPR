using UnityEngine;

public class SoundForWaterPlane : MonoBehaviour
{
    private AudioSource waterPlanesound;  //Звук для воды

    void Awake()
    {
        waterPlanesound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Метод включает проигрывание звука при попадании в коллайде игрока
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            waterPlanesound.Play();
        }
    }

    /// <summary>
    /// Метод отключает проигрывание звука при выходе из коллайдера игрока
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
        {
            waterPlanesound.Stop();
        }
    }
}