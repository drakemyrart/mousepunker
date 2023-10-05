using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField]
    string[] quest;

    [SerializeField]
    GameObject[] questPath;

    [SerializeField]
    UIDialouge uiDia;

    string path;

    int convo;

    bool isInDialouge;

    private void Start()
    {
        SetRadius();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, IntRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Player" && !isInDialouge)
            {
                //path = AssetDatabase.GetAssetPath(questPath[0]);
                Interact();
                isInDialouge = true;
                Destroy(this);
            }

        }
    }


    public override void Interact()
    {
        
        uiDia.LoadDialougeFile(quest[0]);
        Debug.Log("interacting with NPC");
    }

    public override void SetRadius()
    {
        IntRadius = 3f;
    }

    public void SetConvoFile(int x)
    {
        convo = x;
    }
}
