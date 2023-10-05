using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars : MonoBehaviour
{
    [SerializeField]
    GameObject lifeBar;
    [SerializeField]
    GameObject stressBar;
    [SerializeField]
    GameObject convictionBar;

    [SerializeField]
    TurnManager turnManager;

    BaseArketype arketype;

    int key;

    public Image WalkingImage;
    
    // Start is called before the first frame update
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        Image[] life = lifeBar.GetComponent<GridLayoutGroup>().GetComponentsInChildren<Image>();
        Image[] stress = stressBar.GetComponent<GridLayoutGroup>().GetComponentsInChildren<Image>();
        Image[] con = convictionBar.GetComponent<GridLayoutGroup>().GetComponentsInChildren<Image>();
        for (int i = 0; i < life.Length; i++)
        {
            //Debug.Log(turnManager.PlayerCharacterList[key].Life);
            life[i].enabled = false;
            
        }
        for (int i = 0; i < con.Length; i++)
        {
            //Debug.Log(turnManager.PlayerCharacterList[key].Conviction);
            con[i].enabled = false;
            
        }

        for (int i = 0; i < stress.Length; i++)
        {
            //SDebug.Log(turnManager.PlayerCharacterList[key].Stress);
            stress[i].enabled = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetArketypForBars(BaseArketype ark)
    {
        arketype = ark;
        UpdateBars();
    }

    public void UpdateBars()
    {
        
        if (turnManager != null)
        {
            //Debug.Log("Udating bars");
            Image[] life = lifeBar.GetComponent<GridLayoutGroup>().GetComponentsInChildren<Image>();
            Image[] stress = stressBar.GetComponent<GridLayoutGroup>().GetComponentsInChildren<Image>();
            Image[] con = convictionBar.GetComponent<GridLayoutGroup>().GetComponentsInChildren<Image>();

            for (int i = 0; i < life.Length; i++)
            {
                //Debug.Log(turnManager.PlayerCharacterList[key].Life);
                life[i].enabled = false;
                if (i < arketype.NowLife)
                {
                    //Debug.Log("Lifedot");
                    life[i].enabled = true;
                }
            }

            for (int i = 0; i < con.Length; i++)
            {
                //Debug.Log(turnManager.PlayerCharacterList[key].Conviction);
                con[i].enabled = false;
                if (i < arketype.NowConviction)
                {
                    //Debug.Log("Condot");
                    con[i].enabled = true;
                }
            }

            for (int i = 0; i < stress.Length; i++)
            {
                //SDebug.Log(turnManager.PlayerCharacterList[key].Stress);
                stress[i].enabled = false;
                if (i < arketype.NowStress)
                {
                    //Debug.Log("Stressdot");
                    stress[i].enabled = true;
                }
            }
        }
        else
        {
            Debug.Log("no turn");
        }
    }
}
