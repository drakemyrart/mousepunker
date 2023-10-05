using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueTree;

public class NpcDialouge : MonoBehaviour
{

    private Dialogue dia;

    private GameObject dialogue_window;

    private GameObject node_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;
    private GameObject exit;

    private int selected_option = -2;

    public string DialogueDataFilePath;

    public GameObject DialogueWindowPrefab;

    // Start is called before the first frame update
    void Start()
    {

        dia = Dialogue.LoadDialogue("Assets/" + DialogueDataFilePath);

        var canvas = GameObject.Find("Canvas");

        dialogue_window = Instantiate<GameObject>(DialogueWindowPrefab);
        dialogue_window.transform.parent = canvas.transform;
        RectTransform dia_window_transform = (RectTransform)dialogue_window.transform;
        dia_window_transform.localPosition = new Vector3(0, 0, 0);

        node_text = GameObject.Find("Text_DiaNodeText");
        option_1 = GameObject.Find("Button_Option1");
        option_2 = GameObject.Find("Button_Option2");
        option_3 = GameObject.Find("Button_Option3");
        exit = GameObject.Find("Button_End");

        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOptions(-1); });

        dialogue_window.SetActive(false);

        RunDialogue();
    }

    public void RunDialogue()
    {
        StartCoroutine(run());
    }

    public void SetSelectedOptions(int x)
    {
        selected_option = x;
    }

    public IEnumerator run()
    {
        dialogue_window.SetActive(true);

        // create a indexer, set it to 0, the start node
        int node_id = 0;

        //while next node not exit node, traverse tree based on user input
        while (node_id != -1)
        {
            display_node(dia.Nodes[node_id]);

            selected_option = -2;
            while (selected_option == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }
            node_id = selected_option;
        }

        dialogue_window.SetActive(false);
    }

    private void display_node(DialogueNode node)
    {
        node_text.GetComponent<Text>().text = node.Text;

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        for (int i = 0; i < node.Options.Count; i++)
        {
            switch (i)
            {
                case 0:
                    set_option_button(option_1, node.Options[i]);
                    break;
                case 1:
                    set_option_button(option_2, node.Options[i]);
                    break;
                case 2:
                    set_option_button(option_3, node.Options[i]);
                    break;
            }
        }
    }

    private void set_option_button(GameObject button, DialogueOption opt)
    {
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = opt.Text;
        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOptions(opt.DestinationNodeID); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
