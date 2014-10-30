using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour {
    public static Deck Instance;

    static Card[] cardPile;
    int pTop = 0;
    int restCardsNumber = 0;
    Card_Sha sha;
    Card_Shan shan;
    Card_Tao tao;
	// Use this for initialization
	void Start () {
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);

        Instance = this;
        if (Instance == null) Debug.Log("Deck is null");
        else Debug.Log("Deck is not null");
	    cardPile = new Card[50];
        sha = new Card_Sha();
        shan = new Card_Shan();
        tao = new Card_Tao();
        //Debug.Log("aaaa"+ shan.name);
        for(int i=0;i<50;i++)
        {
            int a = Random.Range(0, 100);
            if (a < 60)
            {
                cardPile[i] = sha;
                Debug.Log("here add a sha");
            }
            else if (a < 80)
            {
                cardPile[i] = shan;
                Debug.Log("here add a shan");
            }
            else
            {
                cardPile[i] = tao;
                Debug.Log("here add a tao");
            }
            
        }
        pTop = 49;
        restCardsNumber = 49;
        /*for (int i = 0; i < 50; i++)
        {
            Debug.Log(cardPile[i].name);
        }*/
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
        Debug.Log("draw a " + cardPile[pTop].name);
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
