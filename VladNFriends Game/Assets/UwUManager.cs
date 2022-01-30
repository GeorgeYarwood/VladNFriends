using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UwUManager : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip click;
    
    public void LoadLevel1()
    {
        StartCoroutine(Load(1));
    }
    public void LoadLevel2()
    {
        StartCoroutine(Load(2));
    }
    public void LoadCredits()
    {
        StartCoroutine(Load(3));
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator Load(int choice)
    {
        sfx.clip = click;
        sfx.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(choice);
    }
}
