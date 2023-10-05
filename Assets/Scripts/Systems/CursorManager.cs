using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    [System.Serializable]
    public class TheCursors
    {
        public string tag;
        public Texture2D cursorTexture;
    }

    public List<TheCursors> cursorList = new List<TheCursors>();

	// Use this for initialization
	void Awake ()
    {

        SetCursorTexture(cursorList[0].cursorTexture);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, 1000))
        {
            for(int i = 0; i < cursorList.Count; i++)
            {
                if(raycastHit.collider.tag == cursorList[i].tag)
                {
                    SetCursorTexture(cursorList[i].cursorTexture);
                    return;
                }
            }
        }
        SetCursorTexture(cursorList[0].cursorTexture);
    }

    void SetCursorTexture(Texture2D tex)
    {
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
    }
}
