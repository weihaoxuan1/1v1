using UnityEngine;
using System.Collections;

public class HeroCoverHealth : MonoBehaviour {

    public GameObject heroCard;
    public int weightOfFour = 120;
    public int weightOfThree = 150;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
	
    public void DecreaseHealth(int totalHealth)
    {
        
        if(totalHealth == 4)
        {
            float y = heroCard.transform.localPosition.y - weightOfFour;
            heroCard.transform.localPosition = new Vector3(heroCard.transform.localPosition.x, y, heroCard.transform.localPosition.z);
        }
        if(totalHealth == 3)
        {
        	float y = heroCard.transform.localPosition.y - weightOfThree;
            heroCard.transform.localPosition = new Vector3(heroCard.transform.localPosition.x, y, heroCard.transform.localPosition.z);
        }
    }

	public void IncreaseHealth(int totalHealth)
	{
		
		if(totalHealth == 4)
		{
			float y = heroCard.transform.localPosition.y + weightOfFour;
			heroCard.transform.localPosition = new Vector3(heroCard.transform.localPosition.x, y, heroCard.transform.localPosition.z);
		}
		if(totalHealth == 3)
		{
			float y = heroCard.transform.localPosition.y + weightOfThree;
			heroCard.transform.localPosition = new Vector3(heroCard.transform.localPosition.x, y, heroCard.transform.localPosition.z);
		}
	}
}
