using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour {

    
    public StoryElements story;

    public void TriggerStory()
    {
        FindObjectOfType<StoryManager>().StartStory(story);
    }
}
