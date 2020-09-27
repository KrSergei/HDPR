using UnityEngine;

public class FalldownConcreteBlock : MonoBehaviour
{
    private AudioSource falldownConblock;   //Звук падения камня
    
    void Awake()
    {
        falldownConblock = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Если в столкновении попадается объект с тэгом "Concrete", то проиграть трек столкновения
        if (collision.collider.tag == "Concrete")
        {
            falldownConblock.Play();
        }
    }
}