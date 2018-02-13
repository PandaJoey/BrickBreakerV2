using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;
    // Use this for initialization
    private void Awake() {
        // Debug.Log("Music Player Awake" + GetInstanceID());
        /*
         * Debug.Log("Music Player Awake" + GetInstanceID());
        if (instance != null) {
            Destroy(gameObject);
            print("Dulpcate music player self destructing");
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        //GameObject.DontDestroyOnLoad(gameObject);
        */
    }

    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
