using UnityEngine;
using System.Collections;

public class Player_Man : Player
{
    public static Player_Man Instance;

    void Start()
    {
        Instance = this;
        opposite = Player_Enemy.Instance;
		MainProcess.Instance.RegOnStageDelegate(OnStageDel);
		maxHealth = 4;
        curHealth = 4;
        judgementCards = new Card[3];
        holdCards = new Card[20];
        pHoldCards = -1;
        holdCardsNumber = 0;

    }
}