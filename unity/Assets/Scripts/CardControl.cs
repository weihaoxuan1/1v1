using UnityEngine;
using System.Collections;

public class CardControl : MonoBehaviour {

    public static CardControl Instance;
    CardControl()
    {
        Instance = this;
    }

    public enum Position
    {
        myHand,
        myJudge,
        myWeapon,
        myShield,
        myPlayed,
        myHero,
        enemyHand,
        enemyJudge,
        enemyWeapon,
        enemyShield,
        enemyPlayed,
        enemyHero,
        deck,
        discard
    }

    public Transform myHand;
    public Transform myJudge;
    public Transform myWeapon;
    public Transform myShield;
    public Transform myPlayed;
    public Transform myHero;
    public Transform enemyHand;
    public Transform enemyJudge;
    public Transform enemyWeapon;
    public Transform enemyShield;
    public Transform enemyPlayed;
    public Transform enemyHero;
    public Transform deck;
    public Transform discard;

    Transform EnumToPosition(Position p)
    {
        switch (p)
        {
            case Position.deck:
                return deck;
            case Position.discard:
                return discard;
            case Position.myHand:
                return myHand;
            case Position.myJudge:
                return myJudge;
            case Position.myWeapon:
                return myWeapon;
            case Position.myShield:
                return myShield;
            case Position.myPlayed:
                return myPlayed;
            case Position.myHero:
                return myHero;
            case Position.enemyHand:
                return enemyHand;
            case Position.enemyJudge:
                return enemyJudge;
            case Position.enemyWeapon:
                return enemyWeapon;
            case Position.enemyShield:
                return enemyShield;
            case Position.enemyPlayed:
                return enemyPlayed;
            case Position.enemyHero:
                return enemyHero;
            default:
                return null;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeCardPosition(GameObject card, GameObject target, bool isBack = false)
    {
        //warining 在这里添加移动动画
        card.transform.parent = target.transform;
        card.transform.localPosition = Vector3.zero;
        if (isBack)
            card.GetComponent<UISprite>().spriteName = "Back";
        else
            ;// card.GetComponent<UISprite>().spriteName = card.name;
    }

    public void ChangeCardPosition(GameObject card, Position target, bool isBack = false)
    {
        card.transform.parent = EnumToPosition(target);
        card.transform.localPosition = Vector3.zero;
        if (isBack)
            card.GetComponent<UISprite>().spriteName = "Back";
        else
            ;// card.GetComponent<UISprite>().spriteName = card.name;
    }
}
