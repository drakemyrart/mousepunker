using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryStart : MonoBehaviour {

    public StoryElements story;

    public void TriggerStory()
    {
        FindObjectOfType<ClickToMove>().isWalkingAloved = false;
        FindObjectOfType<StoryManager>().StartStory(story);
        
    }
}
