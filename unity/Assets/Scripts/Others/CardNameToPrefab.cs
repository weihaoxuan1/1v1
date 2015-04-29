using UnityEngine;
using System.Collections;

public class CardNameToPrefab : MonoBehaviour {

    public static CardNameToPrefab Instance;
    CardNameToPrefab()
    {
        Instance = this;
    }

    public GameObject[] prefabCard;

    enum CardName
    {
        sha = 0,
        shan = 1,
        tao = 2,
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject NameToPrefab(string name)
    {
        switch(name)
        {
            case "sha":
                return prefabCard[(int)CardName.sha];
            case "shan":
                return prefabCard[(int)CardName.shan];
            case "tao":
                return prefabCard[(int)CardName.tao];
            default:
                return prefabCard[(int)CardName.sha];
        }
    }
}
