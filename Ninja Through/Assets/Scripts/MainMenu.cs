using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip soundOnHover;
    public AudioClip soundOnClick;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayButtonPress()
    {
        audioSource.clip = soundOnClick;
        audioSource.Play();
        SceneManager.LoadScene("Level1");
    }

    void OnMouseEnter()
    {
        audioSource.PlayOneShot(soundOnHover);
    }
}
