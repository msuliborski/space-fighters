using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeb : MonoBehaviour {

    public AudioClip jeb;
    private AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
        source.clip = jeb;
        source.PlayOneShot(jeb, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
