using UnityEngine;
using System.Collections;
/// <summary>
/// ��������
/// </summary>
public class MainProcess : MonoSingleton<MainProcess> {

    //�׶�����
	public enum Stage{
        begin = 0,
		beginStart = 1,
		begining = 2,
		beginOver = 3,
		judgeStart = 4,
		judgeing = 5,
		judgeOver = 6,
		drawStart = 7,
		drawing = 8,
		drawOver = 9,
		playStart = 10,
		playing = 11,
		playOver = 12,
		discardStart = 13,
		discarding = 14,
		discardOver = 15,
		endStart = 16,
		ending = 17,
		endOver = 18
	};
    //���͸�ί�еĽṹ
    public struct StageEvent
    {
        public int turn;
        public float time;
        public Stage curStage;
        //public Player opposite;
        //public Player self;
    };
    //ί�����
    public delegate void OnStageDelegate(StageEvent stageEvent);
    private OnStageDelegate onStageDels;

    public void RegOnStageDelegate(OnStageDelegate onStageDel)
    {
        onStageDels += onStageDel;
    }

    public void UnregOnStageDelegate(OnStageDelegate onStageDel)
    {
        if (onStageDels != null)
            onStageDels -= onStageDel;
    }

	int turn;
	float time;
    public float stageDelay = 1;
    float delay = 0;
    Stage lastStage;
	Stage curStage;
	public Player opposite;
    public Player self;
    StageEvent stageEvent;
    public UILabel info;
    public UILabel whoseTurn;
    public bool isMyTurn = true;
    //��Ϸ����ʱ
    public void Reset()
    {
        turn = 1;
        time = 0;
        lastStage = Stage.begin;
        curStage = Stage.begin;
        if (info) info.text = "?";
        isMyTurn = true;
    }
	// Use this for initialization
	void Start () {
        stageEvent = new StageEvent();
        lastStage = (Stage)0;
        curStage = (Stage)0;
        turn = 1;
        time = 0;
        //opposite = Player.Instance;// _Enemy.Instance;
        //self = Player.Instance;
        Debug.Log("Started the game");
        Invoke("NextStage",2);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        //�����ù�NextStage()ʱ�����
        if(lastStage != curStage )
        {
            delay += Time.deltaTime;
            //�׶�֮�����ʱ,�޸�stageDelay�ɿ���
            if (delay >= stageDelay || (int)curStage%3!=2)
            {
                lastStage = curStage;
                delay = 0;
                if (onStageDels != null)
                    onStageDels(GetStageEvent());
            }
        }
	}
    //������һ���׶�ʱ����
	public void NextStage()
	{
        curStage++;
        if (curStage >= (Stage)19)
        {
            curStage = (Stage)0;
            turn++;
            Debug.Log("next turn " + turn);
            isMyTurn = !isMyTurn;
            if (whoseTurn) whoseTurn.text = isMyTurn ? "your turn" : "enemy turn";
        }
        if(info)
			info.text = "curStage is " + curStage;
        Debug.Log("curStage is " + curStage +" "+(int)curStage);
        
        
        /*if (curStage != (Stage)8 && curStage != (Stage)14 && curStage != (Stage)11)
        {
            //Debug.Log("xuan");
            Invoke("NextStage",1);
        }
        */
	}

    public void GameOver()
    {
        if (info) info.text = isMyTurn ? "enemy dead" : "you dead";
        Reset();
        Player_Enemy.Instance.Reset();
        Player_Man.Instance.Reset();
        Deck.Instance.Reset();
        Player_Man.Instance.Reg();
        Invoke("NextStage", 5);
    }
    //ί�к���
    StageEvent GetStageEvent()
    {
        //Debug.Log("xxxxx" + curStage);
        stageEvent.curStage = curStage;
        stageEvent.turn = turn;
        stageEvent.time = time;
        //stageEvent.self = self;
        //stageEvent.opposite = opposite;
        return stageEvent;
    }

    public Stage GetCurstage()
    {
        return curStage;
    }
}
