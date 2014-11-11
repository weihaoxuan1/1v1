using UnityEngine;
using System.Collections;

public class DoubleClick : MonoBehaviour {


    public bool oneClick = false;
    public float time = 1;
    public GameObject g;
    public UIGrid grid;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(oneClick)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                time = 1;
                oneClick = false;
            }
        }
	}

    public void OnaClick()
    {
        if (!oneClick)
        {
            oneClick = true;
        }
        else
        {
            oneClick = false;
            time = 1;
            
            //grid.RemoveChild(this.transform);
            this.gameObject.SetActive(false);
        }
    }
   
    public void Draw()
    {
        //g.GetComponent<UISprite>().drawingDimensions.Set(100, 100, 100, 100);
        //g.transform.localScale = new Vector3(0.00185f, 0.00185f, 0.00185f);
        
        GameObject a = Instantiate(g)as GameObject;
        //a.transform = new Vector3(1, 1, 1);
        //a.transform.localScale = new Vector3(1, 1, 1);
        a.transform.parent = grid.gameObject.transform;
        //a.transform.localPosition.Set(0, 0, 0);
        
        //a.transform.localScale.Set(1, 1, 1);
        //a.GetComponent<UISprite>().SetDimensions(100, 100);
        //grid.AddChild(a.transform);
    }
}
