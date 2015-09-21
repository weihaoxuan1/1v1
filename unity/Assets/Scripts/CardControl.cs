using UnityEngine;
using System.Collections;

public class CardControl : MonoBehaviour {

    GameObject[] cards;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetDeck(GameObject[] g)
    {
        cards = g;
    }
}
