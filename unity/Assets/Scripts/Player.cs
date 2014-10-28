using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player Instance;

	int maxHealth;
	int curHealth;
	public Card[] judgementCards;
	public Card[] holdCards;
    int pHoldCards;
    int holdCardsNumber;

    void Start()
    {
        Instance = this;
        maxHealth = 4;
        curHealth = 4;
        judgementCards = new Card[3];
        holdCards = new Card[20];
        pHoldCards = 0;
        holdCardsNumber = 0;
    }

	public void SufferSha()
	{
		curHealth--;
        Debug.Log("being sha , injure 1 point , curHealth = "+curHealth);
        CheckDead();
	}

	public void EnterPlayingStage()
    {
        holdCards[1].Effect();
        Debug.Log("self played sha");
    }

    public void EnterDiscardingStage()
    {
    }

    void CheckDead()
    {
        if (curHealth <= 0)
            Debug.Log("somebody dead");
    }
}