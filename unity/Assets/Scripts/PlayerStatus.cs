using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public static PlayerStatus Instance;
    PlayerStatus()
    {
        Instance = this;
    }
    public enum Status
    {
        normal = 0,
        juedou,
        callShan,
        callSha,
        callWuxie,

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
