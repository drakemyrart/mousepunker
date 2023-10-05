using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    UIPlayer instance;

    
    [SerializeField]
    Image[] portraitList;

    [SerializeField]
    TurnManager turnManager;

    public Dictionary<Image, int> CharacterPortraits = new Dictionary<Image, int>();
    public Dictionary<int, Image> CharacterPortraitsKeys = new Dictionary<int, Image>();
    public Dictionary<Image, Button> ButtonList = new Dictionary<Image, Button>();
    public Dictionary<Image, Text> ButtonTextList = new Dictionary<Image, Text>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        turnManager = FindObjectOfType<TurnManager>();
        for (int i = 0; i < portraitList.Length; i++)
        {
            //portraitList[i].enabled = true;
            Image[] abi = portraitList[i].GetComponentsInChildren<Image>();
            foreach (var img in abi)
            {
                if (img != portraitList[i])
                {
                    img.GetComponentInChildren<Button>().enabled = false;
                    img.enabled = false;
                }
            }
            //portraitList[i].enabled = false;
        }
        
        SetSelectedCharacter((int)SelectionType.None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulateCharacterUI()
    {
        int portrait = 0;

        foreach (var item in turnManager.PlayerList)
        {
            if (!CharacterPortraitsKeys.ContainsKey(item.Key))
            {
                if (portrait < CharacterPortraitsKeys.Count)
                {
                    portrait = CharacterPortraitsKeys.Count;
                }
                CharacterPortraitsKeys.Add(item.Key, portraitList[portrait]);
                CharacterPortraits.Add(portraitList[portrait], item.Key);
                CharacterPortraitsKeys[item.Key].sprite = turnManager.PlayerPortraitList[item.Key];
                portraitList[portrait].enabled = true;
                Debug.Log(turnManager.PlayerCharacterList[item.Key].PlayerName);

                Image[] abi = CharacterPortraitsKeys[item.Key].GetComponentsInChildren<Image>();
                Debug.Log(abi.Length);
                foreach (var img in abi)
                {
                    if (img != CharacterPortraitsKeys[item.Key])
                    {
                        if(img.name != "Ability")
                        {
                            Button btn = img.GetComponentInChildren<Button>();
                            btn.enabled = true;

                            //Text txt = btn.GetComponentInChildren<Text>();
                            
                            /*
                            if (img.name == "Stealth1")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.StealthAbility1); });
                            }
                            if (img.name == "Stealth2")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.StealthAbility2); });
                            }
                            if (img.name == "Stealth3")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.StealthAbility3); });
                            }
                            if (img.name == "Stealth4")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.StealthAbility4); });
                            }
                            if (img.name == "Stealth5")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.StealthAbility5); });
                            }
                            if (img.name == "Stealth6")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.StealthAbility6); });
                            }

                            if (img.name == "Athletics1")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.AthleticsAbility1); });
                            }
                            if (img.name == "Athletics2")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.AthleticsAbility2); });
                            }
                            if (img.name == "Athletics3")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.AthleticsAbility3); });
                            }
                            if (img.name == "Athletics4")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.AthleticsAbility4); });
                            }
                            if (img.name == "Athletics5")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.AthleticsAbility5); });
                            }
                            if (img.name == "Athletics6")
                            {
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].PlayerClass.AthleticsAbility6); });
                            }
                            */
                            if (img.name == "Class1")
                            {

                                btn.name = turnManager.PlayerCharacterList[item.Key].ClassAbility1.AbilityName;
                                btn.onClick.RemoveAllListeners();
                                ButtonList.Add(img, btn);
                                ButtonList[img].onClick.AddListener(() => { Debug.Log("Button Clicked"); SetAbility(turnManager.PlayerCharacterList[item.Key].ClassAbility1); });
                                Debug.Log(turnManager.PlayerCharacterList[item.Key].ClassAbility1.AbilityName);
                                Debug.Log(btn.name);
                                //txt.text = turnManager.PlayerCharacterList[item.Key].ClassAbility1.AbilityName;
                                //ButtonTextList.Add(img, txt);
                                



                            }
                            if (img.name == "Class2")
                            {
                                btn.name = turnManager.PlayerCharacterList[item.Key].ClassAbility2.AbilityName;
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].ClassAbility2); });
                                Debug.Log(turnManager.PlayerCharacterList[item.Key].ClassAbility2.AbilityName);
                                Debug.Log(btn.name);
                                //txt.text = turnManager.PlayerCharacterList[item.Key].ClassAbility2.AbilityName;
                                //ButtonTextList.Add(img, txt);
                                ButtonList.Add(img, btn);

                            }
                            if (img.name == "Class3")
                            {

                                btn.name = turnManager.PlayerCharacterList[item.Key].ClassAbility3.AbilityName;
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].ClassAbility3); });
                                Debug.Log(turnManager.PlayerCharacterList[item.Key].ClassAbility3.AbilityName);
                                Debug.Log(btn.name);
                                //txt.text = turnManager.PlayerCharacterList[item.Key].ClassAbility3.AbilityName;
                                //ButtonTextList.Add(img, txt);
                                ButtonList.Add(img, btn);

                            }
                            if (img.name == "Class4")
                            {

                                btn.name = turnManager.PlayerCharacterList[item.Key].ClassAbility4.AbilityName;
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].ClassAbility4); });
                                Debug.Log(turnManager.PlayerCharacterList[item.Key].ClassAbility4.AbilityName);
                                Debug.Log(btn.name);
                                //txt.text = turnManager.PlayerCharacterList[item.Key].ClassAbility4.AbilityName;
                                //ButtonTextList.Add(img, txt);
                                ButtonList.Add(img, btn);

                            }
                            if (img.name == "Class5")
                            {

                                btn.name = turnManager.PlayerCharacterList[item.Key].ClassAbility5.AbilityName;
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].ClassAbility5); });
                                Debug.Log(turnManager.PlayerCharacterList[item.Key].ClassAbility5.AbilityName);
                                Debug.Log(btn.name);
                                //txt.text = turnManager.PlayerCharacterList[item.Key].ClassAbility5.AbilityName;
                                //ButtonTextList.Add(img, txt);
                                ButtonList.Add(img, btn);

                            }
                            if (img.name == "Class6")
                            {

                                btn.name = turnManager.PlayerCharacterList[item.Key].ClassAbility6.AbilityName;
                                btn.onClick.AddListener(delegate { SetAbility(turnManager.PlayerCharacterList[item.Key].ClassAbility6); });
                                Debug.Log(turnManager.PlayerCharacterList[item.Key].ClassAbility6.AbilityName);
                                Debug.Log(btn.name);
                                //txt.text = turnManager.PlayerCharacterList[item.Key].ClassAbility6.AbilityName;
                                //ButtonTextList.Add(img, txt);
                                ButtonList.Add(img, btn);


                            }
                            btn.enabled = false;
                            img.enabled = false;
                            if (ButtonTextList.ContainsKey(img))
                            {
                                ButtonTextList[img].enabled = false;
                            }

                        }



                    }
                    
                }
                CharacterPortraitsKeys[item.Key].enabled = true;
                portrait++;

            }
        }
        
    }

    void SetAbility(BaseAbility ability)
    {
        Debug.Log(ability.AbilityName);
        
        turnManager.PlayerAbilityChoice = ability;
        turnManager.abilitySelected = true;
    }

    public void SetSelectedCharacter(int key)
    {

       
        foreach (var item in CharacterPortraitsKeys)
        {
            Image[] abi = CharacterPortraitsKeys[item.Key].GetComponentsInChildren<Image>();
            foreach (var img in abi)
            {
                if (item.Key == key)
                {
                    CharacterPortraitsKeys[item.Key].color = Color.white;
                    img.enabled = true;
                    if (ButtonList.ContainsKey(img))
                    {
                        ButtonList[img].enabled = true;
                    }
                    if (ButtonTextList.ContainsKey(img))
                    {
                        ButtonTextList[img].enabled = true;
                    }

                }
                else
                {
                    if (img != CharacterPortraitsKeys[item.Key])
                    {
                        img.enabled = false;
                        if (ButtonList.ContainsKey(img))
                        {
                            ButtonList[img].enabled = false;
                        }
                        if (ButtonTextList.ContainsKey(img))
                        {
                            ButtonTextList[img].enabled = false;
                        }
                        CharacterPortraitsKeys[item.Key].color = Color.grey;
                    }
                }
            }
            if (key == (int)SelectionType.All)
            {
                CharacterPortraitsKeys[item.Key].color = Color.white;
            }

            if (key == (int)SelectionType.None)
            {
                CharacterPortraitsKeys[item.Key].color = Color.grey;
            }

        }
        
    }
}
