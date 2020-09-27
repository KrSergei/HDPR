using UnityEngine;

public class StartAction : MonoBehaviour
{
    public LookAtToObjAndShoot lookAtSt;        //Ссылка на объет LookAtToObjAndShoot

    private void OnTriggerEnter(Collider Col)
    {
        if(Col.tag == "Player")
        {
            //Установка для объекта LookAtToObjAndShoot переменной startLookAt слежения за объектом true 
            lookAtSt.startLookAt = true;
            //вызов метода Shooting() у объекта LookAtToObjAndShoot
            StartCoroutine(lookAtSt.Shooting());
        }
    }

    private void OnTriggerExit(Collider Col)
    {
        if (Col.tag == "Player")
        {
            //Установка для объекта LookAtToObjAndShoot переменной startLookAt слежения за объектом true
            lookAtSt.startLookAt = false;
        }
    }
}
