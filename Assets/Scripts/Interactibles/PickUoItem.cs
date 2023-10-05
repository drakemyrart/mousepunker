using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUPItem : Interactable, ISerializationCallbackReceiver
{
    public ItemObject item;

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;
        //EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
    }

    public override void Interact()
    {
        Debug.Log("interacting with Item");
    }
}
