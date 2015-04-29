using UnityEngine;
using System.Collections;

public class HandCard : MonoBehaviour {

    BetterList<GameObject> handCard;
	// Use this for initialization
	void Start () {
        handCard = new BetterList<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddCard(Card card)
    {
        GameObject c = Instantiate( CardNameToPrefab.Instance.NameToPrefab(card.name))as GameObject;
        c.transform.parent = this.transform;
        c.transform.name = card.name;
        c.transform.localPosition = new Vector3();
        c.transform.parent.gameObject.GetComponent<UIGrid>().enabled = true;
        print("add a card " + card.name);
    }
}
