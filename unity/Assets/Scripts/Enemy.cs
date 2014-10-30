using UnityEngine;
using System.Collections;

public class Enemy : MonoSingleton<Enemy> {

    static int maxHealth;
    static int curHealth;
    public static Card[] judgementCards;
    public static Card[] holdCards;
    static int pHoldCards;
    static int holdCardsNumber;
    static bool isPlayingStage = false;
    static bool isDrawingStage = false;
    static bool isDiscardingStage = false;
	// Use this for initialization
	void Start () {
        maxHealth = 4;
        curHealth = 4;
        judgementCards = new Card[3];
        holdCards = new Card[20];
        pHoldCards = -1;
        holdCardsNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
