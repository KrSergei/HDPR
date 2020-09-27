using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private static AudioSource fonSoundMenu;

    private void Awake()
    {
        fonSoundMenu = GetComponent<AudioSource>();
    }

    void Start()
    {
        fonSoundMenu.Play();
    }
}