using UnityEngine;
using System.Collections;

public class Player : MonoSingleton<Player> {

    //public static Player Instance;

    static int maxHealth;
    static int curHealth;
    public static Card[] judgementCards;
    public static Card[] holdCards;
    static int pHoldCards;
    static int holdCardsNumber;
    static bool isPlayingStage = false;
    static bool isDrawingStage = false;
    static bool isDiscardingStage = false;

    public UILabel enemyHealth;
    public UILabel info;

    void Start()
    {
        Debug.Log("Player Start()");
        MainProcess.Instance.RegOnStageDelegate(OnStageDel);
        //Instance = this;
        
        maxHealth = 4;
        curHealth = 4;
        judgementCards = new Card[3];
        holdCards = new Card[20];
        pHoldCards = -1;
        holdCardsNumber = 0;
    }

    void OnEnable()
    {
        Debug.Log("Player OnEnable()");
    }

    void Updata()
    {
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(110, 10, 300, 200), "next"))
            MainProcess.Instance.NextStage();
        if (GUI.Button(new Rect(410, 10, 300, 200), "sha"))
        {
            if (isPlayingStage)
            {
                PlaySha();
                isPlayingStage = false;
            }
        }
        if (GUI.Button(new Rect(710, 10, 300, 200), "draw"))
        {
            if (isDrawingStage)
            {
                Draw();
                isDrawingStage = false;
            }
        }
    }
	public void SufferSha()
	{
		curHealth--;
        enemyHealth.text = curHealth.ToString() + "/4"; 
        Debug.Log("being sha , injure 1 point , curHealth = "+curHealth);
        CheckDead();
	}

    public void EnterDrawingStage()
    {
        isDrawingStage = true;
        Debug.Log("isDrawingStage " + isDrawingStage);
    }

	public void EnterPlayingStage()
    {
        isPlayingStage = true;
        Debug.Log("EnterPlayingStage " + isPlayingStage);
        //PlaySha();
    }

    public void EnterDiscardingStage()
    {
        Debug.Log("Discarding cards");
        MainProcess.Instance.NextStage();
    }



    void CheckDead()
    {
        if (curHealth <= 0)
        {
            Debug.Log("somebody dead");
            MainProcess.Instance.GameOver();
        }
    }

    public void PlaySha()
    {
        Debug.Log("PlaySha()" + isPlayingStage);
        if (isPlayingStage)
        {
            holdCards[pHoldCards].Effect();
            Debug.Log("self played sha");
            pHoldCards--;
            holdCardsNumber--;
            Debug.Log("handcard = " + holdCardsNumber);
            //MainProcess.Instance.NextStage();
        }
    }

    public void Draw()
    {
        holdCards[++pHoldCards] = Deck.Instance.DrawCard();
        //Debug.Log("handcard = " + holdCardsNumber);
        holdCards[++pHoldCards] = Deck.Instance.DrawCard();
        
        holdCardsNumber += 2;
        Debug.Log("handcard = " + holdCardsNumber);
        //pHoldCards = holdCardsNumber;
    }

    void OnStageDel(MainProcess.StageEvent stageEvent)
    {
        if (stageEvent.curStage == MainProcess.Stage.drawing)
        {
            EnterDrawingStage();
        }
        else if (stageEvent.curStage == MainProcess.Stage.playing)
        {
            EnterPlayingStage();
        }
        else if (stageEvent.curStage == MainProcess.Stage.discarding)
        {
            EnterDiscardingStage();
        }
        else
            MainProcess.Instance.NextStage();
    }
}