using UnityEngine;
using System.Collections;

public class HandCard : MonoBehaviour {

	public GameObject tempPlace;
    BetterList<GameObject> handCard;
	// Use this for initialization
	void Start () {
        handCard = new BetterList<GameObject>();
		tempPlace = GameObject.Find ("TempPlace").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject AddCard(Card card)
    {
        GameObject c = Instantiate( CardNameToPrefab.Instance.NameToPrefab(card.name))as GameObject;
        c.transform.parent = this.transform;
        c.transform.name = card.name;
        c.transform.localPosition = new Vector3();
        c.transform.parent.gameObject.GetComponent<UIGrid>().enabled = true;
        print("add a card " + card.name);
		return c;
    }

	public GameObject AddCard(GameObject c)
	{
		c.transform.parent = this.transform;
		//c.transform.name = card.name;
		c.transform.localPosition = new Vector3();
		c.transform.parent.gameObject.GetComponent<UIGrid>().enabled = true;
		print("add a card " + c.name);
		return c;
	}

	public GameObject OutCard(GameObject c)
	{
		c.transform.parent = tempPlace.transform;
		c.transform.localPosition = new Vector3();
		print("out a card " + c.name);
		return c;
	}
}
