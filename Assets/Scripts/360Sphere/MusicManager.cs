using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public static MusicManager Instance;

    public AudioClip buttonClick;

    public AudioSource mainAudio;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayButtonClick()
    {
        mainAudio.clip = buttonClick;
        mainAudio.Play();
    }
}
