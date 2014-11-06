using UnityEngine;
using System.Collections;
/// <summary>
/// ÕÊº“¿‡
/// </summary>
public class Player_Man : Player
{
    public static Player_Man Instance;

    void Start()
    {
        Instance = this;
        //opposite = Player_Enemy.Instance;
        MainProcess.Instance.RegOnStageDelegate(OnStageDel);
		maxHealth = 4;
        curHealth = 4;
        //judgementCards = new Card[3];
        //holdCards = new Card[20];
        pHoldCards = -1;
        holdCardsNumber = 0;
        //holdCards[1] = new Card_Sha();
        //Debug.Log(holdCards[1] == null ? "null" : "not null");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(110, 10, 300, 200), "tao"))
        {
            //MainProcess.Instance.NextStage();
            if(MainProcess.Instance.isMyTurn)
            PlayTao();
        }
        if (GUI.Button(new Rect(110, 210, 300, 200), "sha"))
        {
            
                PlaySha();
                
        }
        if (GUI.Button(new Rect(110, 410, 300, 200), "draw"))
        {
            if (isDrawingStage)
            {
                Draw();
                isDrawingStage = false;
                MainProcess.Instance.NextStage();
            }
            
        }
        if (GUI.Button(new Rect(110, 610, 300, 200), "shan"))
        {
            PlayShan();
        }
        if (GUI.Button(new Rect(110, 810, 300, 200), "cancel"))
        {
            if(isCallingShan)
            {
                isCallingShan = false;
                DecreaseHp(1);
            }
            
            if (MainProcess.Instance.isMyTurn&&MainProcess.Instance.GetCurstage() == MainProcess.Stage.playing)
            {
                isHaveSha = false;
                isPlayingStage = false;
                MainProcess.Instance.NextStage();
            }
        }
    }

    public override void OnStageDel(MainProcess.StageEvent stageEvent)
    {
        //Debug.Log("this is my del");
        if (MainProcess.Instance.isMyTurn)
        {
            if (stageEvent.curStage == MainProcess.Stage.beginStart)
            {
                Debug.Log(MainProcess.Instance.isMyTurn ? "my turn" : "enemy turn");
                MainProcess.Instance.NextStage();
            }
            else if (stageEvent.curStage == MainProcess.Stage.drawing)
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
            else if (stageEvent.curStage == MainProcess.Stage.endOver)
            {
                //MainProcess.Instance.isMyTurn = !MainProcess.Instance.isMyTurn;
                this.Unreg();
                opposite.Reg();
                MainProcess.Instance.NextStage();
            }
            else
                MainProcess.Instance.NextStage();
        }
    }

    public override void CallingShan()
    {
        isCallingShan = true;
    }

    public void PlayShan()
    {
        if (isCallingShan)
        {
            Card temp = null;
            foreach (Card c in holdCards)
            {
                if (c.name.Equals("shan") && isCallingShan)
                {
                    temp = c;
                    c.Effect(this);
                }
            }
            if (!isCallingShan)
            {
                holdCards.Remove(temp);
                Debug.Log("opposite played shan");
                CheckHoldCards();
            }
        }
    }
}