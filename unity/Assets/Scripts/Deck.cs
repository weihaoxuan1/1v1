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
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);

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

    public Card DrawCard()
    {
        /*Player.holdCards[1] = cardPile[pTop];
        pTop--;
        Player.holdCards[1] = cardPile[pTop];*/
        //MainProcess.Instance.self.holdCards[1] = cardPile[pTop];
        //pTop--;
        restCardsNumber--;
        Debug.Log("draw a sha");
        return cardPile[pTop--];
        //MainProcess.Instance.NextStage();
    }

    void OnStageDel(MainProcess.StageEvent stageEvent)
    {
        /*if (stageEvent.curStage == MainProcess.Stage.drawing)
        {
            DrawCard();
            MainProcess.Instance.NextStage();
        }
        */
    }
}
