using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public static PlayerStatus Instance;
    PlayerStatus()
    {
        Instance = this;
    }
    enum Status
    {
        normal = 0,
        juedou = 1,
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
