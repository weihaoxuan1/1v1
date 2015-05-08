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

    public GameObject deck;
    public BetterList<GameObject> cardPile;
    public GameObject[] arrayCardPile;
    public BetterList<GameObject> discardPile;
    public int pTop = 0;
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
	    cardPile = new BetterList<GameObject>();
        discardPile = new BetterList<GameObject>();
        sha = new Card_Sha();
        shan = new Card_Shan();
        tao = new Card_Tao();
        arrayCardPile = new GameObject[52];
        //Debug.Log("aaaa"+ shan.name);
        InitDeck();
        /*for (int i = 0; i < 50; i++)
        {
            Debug.Log(cardPile[i].name);
        }*/
        //Debug.Log(cardPile[1] == null ? "null" : "not null");
        //Debug.Log(cardPile[1].name);
	}

    //初始化牌堆，包括第一次洗牌
    void InitDeck()
    {
        int totalCardNum = gameObject.transform.childCount;
        //获取deck对象下的全部卡牌并存入cardpile
        for(int i = 0;i<totalCardNum;i++)
        {
            GameObject temp = gameObject.transform.GetChild(i).gameObject;
            cardPile.Add(temp);
        }
        BetterList<GameObject> tempList = new BetterList<GameObject>();
        //第一次洗牌
        for(int i=0;i<totalCardNum;i++)
        {
            int index = Random.Range(0,cardPile.size);
            tempList.Add(cardPile[index]);
            cardPile.RemoveAt(index);
        }
        cardPile = tempList;
        arrayCardPile = cardPile.ToArray();
        print("finish init");
    }
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject DrawCard()
    {
        //pTop--;
        restCardsNumber--;
        Debug.Log("draw a " + cardPile[pTop].name);
        Debug.Log("Deck rest " + restCardsNumber);
        return cardPile[pTop--];
        //MainProcess.Instance.NextStage();
    }

    public GameObject Judge()
    {
        Debug.Log("judged a ");
        return cardPile[pTop--];
    }

    public void WashDeck(){
        int rest = discardPile.size;
        for (int i = 0; i < rest; i++)
        {
            int index = Random.Range(0, rest-i);
            cardPile.Add(discardPile[index]);
            discardPile.RemoveAt(index);
        }
        print("finish wash deck");
    }

    public void DiscardCard(GameObject c)
    {
        discardPile.Add(c);
		Player_Man.Instance.CheckHoldCards ();
		Player_Enemy.Instance.CheckHoldCards ();
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
