using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DialogueTree;

public class UIDialouge : MonoBehaviour
{

    [SerializeField]
    GameObject dialougeWindow;

    [SerializeField]
    GameObject nodeText;

    [SerializeField]
    Button prefabButton;

    Dialogue dia;

    [SerializeField]
    private GameObject option_1;
    [SerializeField]
    private GameObject option_2;
    [SerializeField]
    private GameObject option_3;
    [SerializeField]
    private GameObject option_4;
    [SerializeField]
    private GameObject option_5;
    [SerializeField]
    private GameObject option_6;


    public string DialogueDataFilePath;

    int selectedOption;

    [SerializeField]
    TurnManager turnManager;

    

    // Start is called before the first frame update
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        dialougeWindow.SetActive(false);
        SetSelectedOption(-2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunDialouge()
    {
        dialougeWindow.SetActive(true);
           
        StartCoroutine(Run());
    }

    public void SetSelectedOption(int x)
    {
        selectedOption = x;
    }

    public IEnumerator Run()
    {
        turnManager.ChangeGameState(GameState.Story);
        int nodeID = 0;

        while (nodeID != -1)
        {
            DisplayNode(dia.Nodes[nodeID]);
            SetSelectedOption(-2);

            while (selectedOption == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }

            nodeID = selectedOption;
        }

        dialougeWindow.SetActive(false);
        turnManager.ChangeGameState(GameState.OutofCombat);


    }

    private void DisplayNode(DialogueNode node)
    {
        nodeText.GetComponent<Text>().text = node.Text;

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);
        option_4.SetActive(false);
        option_5.SetActive(false);
        option_6.SetActive(false);

        for (int i = 0; i < node.Options.Count; i++)
        {
            switch (i)
            {
                case 0:
                    SetOptionButton(option_1, node.Options[i]);
                    break;
                case 1:
                    SetOptionButton(option_2, node.Options[i]);
                    break;
                case 2:
                    SetOptionButton(option_3, node.Options[i]);
                    break;
                case 4:
                    SetOptionButton(option_4, node.Options[i]);
                    break;
                case 5:
                    SetOptionButton(option_5, node.Options[i]);
                    break;
                case 6:
                    SetOptionButton(option_6, node.Options[i]);
                    break;
            }
        }
    }

    private void SetOptionButton(GameObject button, DialogueOption opt)
    {
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = opt.Text;
        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(opt.DestinationNodeID); });
    }

    public void LoadDialougeFile(string path)
    {
        DialogueDataFilePath = path;
        dia = Dialogue.LoadDialogue("Assets/" + DialogueDataFilePath + ".xml");
        RunDialouge();
    }
}
