using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class StoryManager : MonoBehaviour {

    private Queue<string> sentences;

    public Text titleText;
    public Text storyText;

    StoryElements thisStory;

    public GameObject activator;
    public bool storyEnd;

    GameObject player;
    ClickToMove clickToMove;

    // Use this for initialization
    void Awake () {

        player = GameObject.FindWithTag("Player");
        clickToMove = player.GetComponent<ClickToMove>();
        sentences = new Queue<string>();
        activator.SetActive(false);
    }

    public void StartStory(StoryElements story)
    {
        clickToMove.isWalkingAloved = false;

        thisStory = story;

        storyEnd = false;

        activator.SetActive(true);

        titleText.text = story.title;

        sentences.Clear();

        foreach (string sentence in story.sentences[0])
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void LoadNextStoryPart(int load)
    {
        sentences.Clear();
        foreach (string sentence in thisStory.sentences[load])
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndStory();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        var m = Regex.Match(sentence, @"\d+$");
        if (m.Success)
        {
            int choicenr;
            int.TryParse(m.Value, out choicenr);
            LoadChoices(choicenr);
        }

    }

    public void LoadChoices(int choice)
    {
        sentences.Clear();
        foreach (string sentence in thisStory.choices[choice])
        {
            //sentences.Enqueue(sentence);
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        storyText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            storyText.text += letter;
            yield return null;
        }
    }

    private void EndStory()
    {
        activator.SetActive(false);

        storyEnd = true;

        clickToMove.isWalkingAloved = true;

        clickToMove.CheckStoryAction();

        sentences.Clear();


    }
}
