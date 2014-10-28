using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour {
    public static Deck Instance;

    Card[] cardPile;
    int pTop = 0;
    int restCardsNumber = 0;
    Card_Sha sha;
	// Use this for initialization
	void Start () {

        Instance = this;
        if (Instance == null) Debug.Log("Deck is null");
        else Debug.Log("Deck is not null");
	    cardPile = new Card[50];
        sha = new Card_Sha();
        for(int i=0;i<50;i++)
        {
            cardPile[i] = sha;
            Debug.Log("here add a sha");
        }
        pTop = 49;
        restCardsNumber = 49;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DrawCard()
    {
        MainProcess.Instance.self.holdCards[0] = cardPile[pTop];
        pTop--;
        MainProcess.Instance.self.holdCards[1] = cardPile[pTop];
        pTop--;
        restCardsNumber -= 2;
        Debug.Log("draw two sha");
    }
}
