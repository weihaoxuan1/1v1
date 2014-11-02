using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //public static Player Instance;

    public static int maxHealth;
    public static int curHealth;
    public static Card[] judgementCards;
    public static Card[] holdCards;
    public static int pHoldCards;
    public static int holdCardsNumber;
    public static bool isPlayingStage = false;
    public static bool isDrawingStage = false;
    public static bool isDiscardingStage = false;
    public static bool isCallingShan = false;
    public Player opposite;

    public UILabel enemyHealth;
    public UILabel holdCardsLabel;

    void Start()
    {
        Debug.Log("Player Start()");
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);
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

    void Update()
    {
        //CheckHoldCards();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(110, 10, 300, 200), "next"))
            MainProcess.Instance.NextStage();
        if (GUI.Button(new Rect(110, 210, 300, 200), "sha"))
        {
            if (isPlayingStage)
            {
                PlaySha();
                isPlayingStage = false;
            }
        }
        if (GUI.Button(new Rect(110, 410, 300, 200), "draw"))
        {
            if (isDrawingStage)
            {
                Draw();
                isDrawingStage = false;
            }
        }
    }
	/*public void SufferSha()
	{
		curHealth--;
        enemyHealth.text = curHealth.ToString() + "/4"; 
        Debug.Log("being sha , injure 1 point , curHealth = "+curHealth);
        CheckDead();
	}*/

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
            holdCards[pHoldCards].Effect(this);
            Debug.Log("self played sha");
            pHoldCards--;
            holdCardsNumber--;
            Debug.Log("handcard = " + holdCardsNumber);
            //MainProcess.Instance.NextStage();
            CheckHoldCards();
        }
    }

    public void Draw()
    {
        holdCards[++pHoldCards] = Deck.Instance.DrawCard();
        Debug.Log("handcard = "+pHoldCards.ToString() + holdCards[pHoldCards].name);
        holdCards[++pHoldCards] = Deck.Instance.DrawCard();
        
        holdCardsNumber += 2;
        Debug.Log("handcardNO = " );
        for (int i = 0; i < holdCardsNumber; i++)
        {
			//holdCards[i] = new Card();
            if (holdCards[i] == null)
                Debug.Log(i.ToString() + " is verynull");
            //Debug.Log("checkholdcards" + i);
            else
                holdCardsLabel.text = holdCards[i].name + " ";
        }
        CheckHoldCards();
        //pHoldCards = holdCardsNumber;
    }

    public void OnStageDel(MainProcess.StageEvent stageEvent)
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

    public int IncreaseHp(int point)
    {
        curHealth += point;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        return curHealth;
    }

    public int DecreaseHp(int point)
    {
        curHealth -= point;
        if(enemyHealth)enemyHealth.text = curHealth.ToString() + "/4";
        CheckDead();
        return curHealth;
    }

    public void CallingShan()
    {
        isCallingShan = true;
        for (int i = 0; i < holdCardsNumber; i++)
        {
            if (holdCards[i].name.Equals("shan"))
            {
                holdCards[i] = null;
                isCallingShan = false;
                return;
            }
        }
        DecreaseHp(1);
    }

    void CheckHoldCards()
    {
        for (int i = 0; i < holdCardsNumber; i++)
        {
            if (holdCards[i] == null)
                Debug.Log(i.ToString() + " is null");
            //Debug.Log("checkholdcards" + i);
            else
            holdCardsLabel.text = holdCards[i].name + " ";
        }
    }
}