using UnityEngine;
using System.Collections;

public class HeroCoverHealth : MonoBehaviour {

    public GameObject heroCard;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(GUI.Button(new Rect(110, 210, 300, 200), "a"))
        {
            DecreaseHealth(1);
        }
	}

    public void DecreaseHealth(int totalHealth)
    {
        
        if(totalHealth == 4)
        {
            float y = heroCard.transform.localPosition.y - 100;
            heroCard.transform.localPosition = new Vector3(heroCard.transform.localPosition.x, y, heroCard.transform.localPosition.z);
        }
        if(totalHealth == 3)
        {

        }
    }
}
