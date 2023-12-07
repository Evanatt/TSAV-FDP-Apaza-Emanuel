using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMenu : MonoBehaviour {
    public AudioSource sound;
    public AudioClip soundMenu;
    public AudioClip soundMenuselect;

    public void SoundButton()
    {
        sound.clip = soundMenu;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void SoundButtonSelect()
    {

        sound.clip = soundMenuselect;

        sound.enabled = false;
        sound.enabled = true;
    }

}
