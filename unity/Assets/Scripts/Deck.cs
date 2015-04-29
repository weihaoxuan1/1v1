using UnityEngine;
using System.Collections;

/// <summary>
/// 牌堆类
/// </summary>
public class Deck : MonoBehaviour {
    public static Deck Instance;
	Deck()
	{
		Instance = this;
	}

    public BetterList<Card> cardPile;
    public BetterList<Card> discardPile;
    int pTop = 0;
    public int restCardsNumber = 0;
    Card_Sha sha;
    Card_Shan shan;
    Card_Tao tao;
	// Use this for initialization
    public void Reset()
    {
        InitDeck();
    }

	void Start () {
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);

        if (Instance == null) Debug.Log("Deck is null");
        else Debug.Log("Deck is not null");
	    cardPile = new BetterList<Card>();
        discardPile = new BetterList<Card>();
        sha = new Card_Sha();
        shan = new Card_Shan();
        tao = new Card_Tao();
        //Debug.Log("aaaa"+ shan.name);
        InitDeck();
        /*for (int i = 0; i < 50; i++)
        {
            Debug.Log(cardPile[i].name);
        }*/
        //Debug.Log(cardPile[1] == null ? "null" : "not null");
        //Debug.Log(cardPile[1].name);
	}


    void InitDeck()
    {
        for (int i = 0; i < 50; i++)
        {
            int a = Random.Range(0, 100);
            if (a < 60)
            {
                //cardPile[i] = sha;
                cardPile.Add(sha);
                Debug.Log("here add a sha");
            }
            else if (a < 80)
            {
                cardPile.Add(shan);
                //cardPile[i] = shan;
                Debug.Log("here add a shan");
            }
            else
            {
                cardPile.Add(tao);
                //cardPile[i] = tao;
                Debug.Log("here add a tao");
            }

        }
        pTop = 49;
        restCardsNumber = 49;
    }
	// Update is called once per frame
	void Update () {
	
	}

    public Card DrawCard()
    {
        //pTop--;
        restCardsNumber--;
        Debug.Log("draw a " + cardPile[pTop].name);
        Debug.Log("Deck rest " + restCardsNumber);
        return cardPile[pTop--];
        //MainProcess.Instance.NextStage();
    }

    public Card Judge()
    {
        Debug.Log("judged a ");
        return cardPile[pTop--];
    }

    public void WashDeck(){
        int rest = discardPile.size;

        for (int i = 0; i < rest; i++)
        {
            int r = Random.Range(0, rest);
            cardPile.Add(discardPile[r]);
            discardPile.RemoveAt(r);
            rest--;
        }
    }

    public void DiscardCard(Card c)
    {
        discardPile.Add(c);
    }

    /*void OnStageDel(MainProcess.StageEvent stageEvent)
    {
        if (stageEvent.curStage == MainProcess.Stage.drawing)
        {
            DrawCard();
            MainProcess.Instance.NextStage();
        }
        
    }*/
}
