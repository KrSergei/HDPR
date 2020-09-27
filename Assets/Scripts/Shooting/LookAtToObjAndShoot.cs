using UnityEngine;
using System.Collections;

public class LookAtToObjAndShoot : MonoBehaviour
{
    public Transform target;                        //цель для слежения
    public bool startLookAt = false;                //начало слежения за целью
    public Transform spawnPoint;                    //Точка старта полета пули
    public Transform bullet;                        //объект "пуля"
    public GameObject ShootLight;                   //свет при выстреле
    public int speedBullet;                         //скорость полета пули
    public float delayTimeShooting;                 //задержка перед началом стрельбы
    public AudioSource shootGun;


    void Update()
    {
        if (startLookAt)
        {
            transform.LookAt(target);
        }
    }


    /// <summary>
    /// Метод, реализующий логику стрельбы 
    /// </summary>
    public IEnumerator Shooting()
    {
        if (startLookAt)
        {
            yield return new WaitForSeconds(delayTimeShooting);
            //создание объекта пули в точке появления пули
            Transform BulletInst = (Transform)Instantiate(bullet, spawnPoint.position, transform.rotation);
            //придание ускорения пули
            BulletInst.GetComponent<Rigidbody>().AddForce(transform.forward * speedBullet);
            //включения ичточника света, имитируя свет от выстрела
            ShootLight.GetComponent<Light>().enabled = true;
            //выключение ичточника света, имитируя свет от выстрела
            ShootLight.GetComponent<Light>().enabled = false;
            //проигрывание звука выстрела
            shootGun.Play();
            //уничтожение созданного объекта
            Destroy(BulletInst.gameObject, 1.0f);

            //Вызов метода Shooting() еще раз, пока startLookAt true
            StartCoroutine(Shooting());
        }
    }
}
