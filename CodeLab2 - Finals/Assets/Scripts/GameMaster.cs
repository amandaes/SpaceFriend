using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    private static GameMaster instance;

    public Vector2 lastCheckPointPos;

    void Awake() //called before start
    {
        if(instance == null) //instance is equals to null
        {
            instance = this; //make this the instance
            DontDestroyOnLoad(instance); //objects dont destroy itslef between scenes and dont reset values
        }
        else //if there's already an instance, destroy game object. to make sure there are no multiple GM's in same scene
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
