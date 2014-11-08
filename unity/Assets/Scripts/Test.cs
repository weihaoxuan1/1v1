using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	
	public UIGrid grid;
	public UIGrid grid2;
	public GameObject sha;
	public GameObject shan;
	public GameObject back;
	public GameObject tao;
	
	bool isStart = false;
	float startDelay = 0;
	int i = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(200,0,200,100),"start"))
		{
			StartGame();
		}
		if(GUI.Button(new Rect(0,0,200,100),"draw"))
		{
			Draw();
		}
	}
	// Update is called once per frame
	void Update () {
		if(isStart)
		{
			
			startDelay += Time.deltaTime;
			if(startDelay >= 0.2f)
			{
				startDelay = 0;
				if(i<4)
					Draw();
				else if(i<8)
					Draw2 ();
				else 
					isStart = false;
				i++;
			}
		}
	}
	public void Draw()
    {
        //g.GetComponent<UISprite>().drawingDimensions.Set(100, 100, 100, 100);
        //g.transform.localScale = new Vector3(0.00185f, 0.00185f, 0.00185f);
        
        GameObject a = Instantiate(sha)as GameObject;
        //a.transform = new Vector3(1, 1, 1);
        //a.transform.localScale = new Vector3(1, 1, 1);
        a.transform.parent = grid.gameObject.transform;
        //a.transform.localPosition.Set(0, 0, 0);
        
        //a.transform.localScale.Set(1, 1, 1);
        //a.GetComponent<UISprite>().SetDimensions(100, 100);
        grid.AddChild(a.transform);
    }
	public void Draw2()
    {
       
        GameObject a = Instantiate(back)as GameObject;
        
        a.transform.parent = grid2.gameObject.transform;
        
        grid2.AddChild(a.transform);
    }
	public void StartGame()
	{
		isStart=true;
	}
}
