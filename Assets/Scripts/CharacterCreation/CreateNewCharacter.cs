using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCharacter : MonoBehaviour
{
    static CreateNewCharacter instance;

    

    [SerializeField]
    GameObject[] prefabPlayer;

    [SerializeField]
    Sprite[] portraits;

    [SerializeField]
    Sprite[] mercSprites;
    [SerializeField]
    Sprite[] connectorSprites;
    [SerializeField]
    Sprite[] krimSprites;

    int playerCount;

    [SerializeField]
    TurnManager turnManager;
    [SerializeField]
    UIPlayer uiPlayer;

    bool isMercClass;
    bool isConnectorClass;
    bool isNetrunnercClass;
    bool isKrimClass;
    bool isTecherClass;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        uiPlayer = FindObjectOfType<UIPlayer>();
        for (int i = 0; i < prefabPlayer.Length; i++)
        {
            if (i == 0)
            {
                isMercClass = true;
                CreateCharacter();

            }
            if (i == 1)
            {
                isConnectorClass = true;
                CreateCharacter();
            }
            if (i == 2)
            {
                isKrimClass = true;
                CreateCharacter();
            }
        }
        uiPlayer.PopulateCharacterUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCharacter()
    {
        if (turnManager.PlayerCharacterList.Count < 1)
        {
            playerCount = 1;
        }
        else
        {
            playerCount++;
        }

        if (isMercClass)
        {
            BaseArketype newPlayer = new BaseArketype();
            newPlayer.PlayerClass = new BaseMercClass();
           
            newPlayer.PlayerName = newPlayer.PlayerClass.PlayerName;
            newPlayer.MoveLength = newPlayer.PlayerClass.MoveLength;
            newPlayer.PlayerActionPoint = newPlayer.PlayerClass.PlayerActionPoint;
            newPlayer.Unity = newPlayer.PlayerClass.Unity;
            newPlayer.Understanding = newPlayer.PlayerClass.Understanding;
            newPlayer.Care = newPlayer.PlayerClass.Care;
            newPlayer.Autonomy = newPlayer.PlayerClass.Autonomy;
            newPlayer.Control = newPlayer.PlayerClass.Control;
            newPlayer.Justice = newPlayer.PlayerClass.Justice;
            newPlayer.Stress = newPlayer.PlayerClass.Stress;
            newPlayer.NowStress = newPlayer.PlayerClass.NowStress;
            newPlayer.Conviction = newPlayer.PlayerClass.Conviction;
            newPlayer.NowConviction = newPlayer.PlayerClass.NowConviction;
            newPlayer.Pontential = newPlayer.PlayerClass.Pontential;
            newPlayer.NowLevel = newPlayer.PlayerClass.NowLevel;
            newPlayer.Life = newPlayer.PlayerClass.Life;
            newPlayer.NowLife = newPlayer.PlayerClass.NowLife;
            newPlayer.Athletics = newPlayer.PlayerClass.Athletics;
            newPlayer.Stealth = newPlayer.PlayerClass.Stealth;
            newPlayer.Social = newPlayer.PlayerClass.Social;
            newPlayer.Perception = newPlayer.PlayerClass.Perception;
            newPlayer.ClassExp = newPlayer.PlayerClass.ClassExp;
            newPlayer.ClassAbility1 = new CombatCeasefireAbility();
            newPlayer.ClassAbility1.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility1.AbilityMotivationAmount = newPlayer.Unity;
            newPlayer.ClassAbility2 = new CombatCooperationAbility();
            newPlayer.ClassAbility2.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility2.AbilityMotivationAmount = newPlayer.Understanding;
            newPlayer.ClassAbility3 = new CombatProtectAbility();
            newPlayer.ClassAbility3.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility3.AbilityMotivationAmount = newPlayer.Care;
            newPlayer.ClassAbility4 = new CombatIDTargetAbility();
            newPlayer.ClassAbility4.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility4.AbilityMotivationAmount = newPlayer.Autonomy;
            newPlayer.ClassAbility5 = new CombatAttackAbility();
            newPlayer.ClassAbility5.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility5.AbilityMotivationAmount = newPlayer.Control;
            newPlayer.ClassAbility6 = new CombatDisorientAbility();
            newPlayer.ClassAbility6.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility6.AbilityMotivationAmount = newPlayer.Justice;
            
            
            newPlayer.PlayerPortrait = portraits[0];
            turnManager.PlayerCharacterList.Add(playerCount, newPlayer);
            turnManager.PlayerList.Add(playerCount, prefabPlayer[0]);
            turnManager.PlayerKeyList.Add(turnManager.PlayerList[playerCount], playerCount);
            turnManager.PlayerPortraitList.Add(playerCount, newPlayer.PlayerPortrait);
            turnManager.PlayerActionPointList.Add(turnManager.PlayerList[playerCount], newPlayer.PlayerActionPoint);
            prefabPlayer[0].GetComponentInChildren<UIBars>().SetArketypForBars(newPlayer);
            //uiPlayer.PopulateCharacterUI();

            isMercClass = false;
            Debug.Log(newPlayer.ClassAbility1.AbilityName);


        }
        else if (isConnectorClass)
        {
            BaseArketype newPlayer = new BaseArketype();
            newPlayer.PlayerClass = new BaseConnectorClass();
            newPlayer.PlayerName = newPlayer.PlayerClass.PlayerName;
            newPlayer.MoveLength = newPlayer.PlayerClass.MoveLength;
            newPlayer.PlayerActionPoint = newPlayer.PlayerClass.PlayerActionPoint;
            newPlayer.Unity = newPlayer.PlayerClass.Unity;
            newPlayer.Understanding = newPlayer.PlayerClass.Understanding;
            newPlayer.Care = newPlayer.PlayerClass.Care;
            newPlayer.Autonomy = newPlayer.PlayerClass.Autonomy;
            newPlayer.Control = newPlayer.PlayerClass.Control;
            newPlayer.Justice = newPlayer.PlayerClass.Justice;
            newPlayer.Stress = newPlayer.PlayerClass.Stress;
            newPlayer.NowStress = newPlayer.PlayerClass.NowStress;
            newPlayer.Conviction = newPlayer.PlayerClass.Conviction;
            newPlayer.NowConviction = newPlayer.PlayerClass.NowConviction;
            newPlayer.Pontential = newPlayer.PlayerClass.Pontential;
            newPlayer.NowLevel = newPlayer.PlayerClass.NowLevel;
            newPlayer.Life = newPlayer.PlayerClass.Life;
            newPlayer.NowLife = newPlayer.PlayerClass.NowLife;
            newPlayer.Athletics = newPlayer.PlayerClass.Athletics;
            newPlayer.Stealth = newPlayer.PlayerClass.Stealth;
            newPlayer.Social = newPlayer.PlayerClass.Social;
            newPlayer.Perception = newPlayer.PlayerClass.Perception;
            newPlayer.ClassExp = newPlayer.PlayerClass.ClassExp;
            
            newPlayer.ClassAbility1 = new ShrewdnessRapportAbility();
            newPlayer.ClassAbility1.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility1.AbilityMotivationAmount = newPlayer.Unity;
            newPlayer.ClassAbility2 = new ShrewdnessUnifyAbility();
            newPlayer.ClassAbility2.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility2.AbilityMotivationAmount = newPlayer.Understanding;
            newPlayer.ClassAbility3 = new ShrewdnessComfortAbility();
            newPlayer.ClassAbility3.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility3.AbilityMotivationAmount = newPlayer.Care;
            newPlayer.ClassAbility4 = new ShrewdnessConfidenseAbility();
            newPlayer.ClassAbility4.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility4.AbilityMotivationAmount = newPlayer.Autonomy;
            newPlayer.ClassAbility5 = new ShrewdnessIndoctrinateAbility();
            newPlayer.ClassAbility5.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility5.AbilityMotivationAmount = newPlayer.Control;
            newPlayer.ClassAbility6 = new ShrewdnessConvertAbility();
            newPlayer.ClassAbility6.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility6.AbilityMotivationAmount = newPlayer.Justice;

            newPlayer.PlayerPortrait = portraits[1];
            turnManager.PlayerCharacterList.Add(playerCount, newPlayer);
            turnManager.PlayerList.Add(playerCount, prefabPlayer[1]);
            turnManager.PlayerKeyList.Add(turnManager.PlayerList[playerCount], playerCount);
            turnManager.PlayerPortraitList.Add(playerCount, newPlayer.PlayerPortrait);
            turnManager.PlayerActionPointList.Add(turnManager.PlayerList[playerCount], newPlayer.PlayerActionPoint);
            prefabPlayer[1].GetComponentInChildren<UIBars>().SetArketypForBars(newPlayer);
            //uiPlayer.PopulateCharacterUI();

            isConnectorClass = false;

        }
        else if (isNetrunnercClass)
        {
            BaseArketype newPlayer = new BaseArketype();
            newPlayer.PlayerClass = new BaseNetrunnerClass();
            newPlayer.ClassAbility1 = new NetrunningUplinkAbility();
            newPlayer.ClassAbility2 = new NetrunningIdentifyAbility();
            newPlayer.ClassAbility3 = new NetrunningProtectAbility();
            newPlayer.ClassAbility4 = new NetrunningBypassAbility();
            newPlayer.ClassAbility5 = new NetrunningDestroyAbility();
            newPlayer.ClassAbility6 = new NetrunningTakeOverAbility();
            newPlayer.PlayerName = newPlayer.PlayerClass.PlayerName;
            newPlayer.MoveLength = newPlayer.PlayerClass.MoveLength;
            newPlayer.PlayerActionPoint = newPlayer.PlayerClass.PlayerActionPoint;
            newPlayer.Unity = newPlayer.PlayerClass.Unity;
            newPlayer.Understanding = newPlayer.PlayerClass.Understanding;
            newPlayer.Care = newPlayer.PlayerClass.Care;
            newPlayer.Autonomy = newPlayer.PlayerClass.Autonomy;
            newPlayer.Control = newPlayer.PlayerClass.Control;
            newPlayer.Justice = newPlayer.PlayerClass.Justice;
            newPlayer.Stress = newPlayer.PlayerClass.Stress;
            newPlayer.NowStress = newPlayer.PlayerClass.NowStress;
            newPlayer.Conviction = newPlayer.PlayerClass.Conviction;
            newPlayer.NowConviction = newPlayer.PlayerClass.NowConviction;
            newPlayer.Pontential = newPlayer.PlayerClass.Pontential;
            newPlayer.NowLevel = newPlayer.PlayerClass.NowLevel;
            newPlayer.Life = newPlayer.PlayerClass.Life;
            newPlayer.NowLife = newPlayer.PlayerClass.NowLife;
            newPlayer.Athletics = newPlayer.PlayerClass.Athletics;
            newPlayer.Stealth = newPlayer.PlayerClass.Stealth;
            newPlayer.Social = newPlayer.PlayerClass.Social;
            newPlayer.Perception = newPlayer.PlayerClass.Perception;
            newPlayer.ClassExp = newPlayer.PlayerClass.ClassExp;
            newPlayer.AthleticsAbility1 = new AthleticsLinkUpAbility();
            newPlayer.AthleticsAbility2 = new AthleticsUnifiedActionAbility();
            newPlayer.AthleticsAbility3 = new AthleticsRescueAbility();
            newPlayer.AthleticsAbility4 = new AthleticsCoverAbility();
            newPlayer.AthleticsAbility5 = new AthleticsAttackAbility();
            newPlayer.AthleticsAbility6 = new AthleticsCatchAbility();
            newPlayer.StealthAbility1 = new StealthTrapAbility();
            newPlayer.StealthAbility2 = new StealthFindAbility();
            newPlayer.StealthAbility3 = new StealthConcealAbility();
            newPlayer.StealthAbility4 = new StealthSneakAbility();
            newPlayer.StealthAbility5 = new StealthAmbushAbility();
            newPlayer.StealthAbility6 = new StealthStalkAbility();
            newPlayer.PlayerPortrait = portraits[2];
            turnManager.PlayerCharacterList.Add(playerCount, newPlayer);
            turnManager.PlayerList.Add(playerCount, prefabPlayer[1]);
            turnManager.PlayerKeyList.Add(turnManager.PlayerList[playerCount], playerCount);
            turnManager.PlayerPortraitList.Add(playerCount, newPlayer.PlayerPortrait);
            turnManager.PlayerActionPointList.Add(turnManager.PlayerList[playerCount], newPlayer.PlayerActionPoint);
            prefabPlayer[1].GetComponentInChildren<UIBars>().SetArketypForBars(newPlayer);
            uiPlayer.PopulateCharacterUI();

            isNetrunnercClass = false;

        }
        else if (isKrimClass)
        {
            BaseArketype newPlayer = new BaseArketype();
            newPlayer.PlayerClass = new BaseKrimClass();
            newPlayer.ClassAbility1 = new IllicitnessPrimeAbility();
            newPlayer.ClassAbility2 = new IllicitnessBribeAbility();
            newPlayer.ClassAbility3 = new IllicitnessTauntAbility();
            newPlayer.ClassAbility4 = new IllicitnessStealAbility();
            newPlayer.ClassAbility5 = new IllicitnessEnrageAbility();
            newPlayer.ClassAbility6 = new IllicitnessExtortAbility();
            newPlayer.PlayerName = newPlayer.PlayerClass.PlayerName;
            newPlayer.MoveLength = newPlayer.PlayerClass.MoveLength;
            newPlayer.PlayerActionPoint = newPlayer.PlayerClass.PlayerActionPoint;
            newPlayer.Unity = newPlayer.PlayerClass.Unity;
            newPlayer.Understanding = newPlayer.PlayerClass.Understanding;
            newPlayer.Care = newPlayer.PlayerClass.Care;
            newPlayer.Autonomy = newPlayer.PlayerClass.Autonomy;
            newPlayer.Control = newPlayer.PlayerClass.Control;
            newPlayer.Justice = newPlayer.PlayerClass.Justice;
            newPlayer.Stress = newPlayer.PlayerClass.Stress;
            newPlayer.NowStress = newPlayer.PlayerClass.NowStress;
            newPlayer.Conviction = newPlayer.PlayerClass.Conviction;
            newPlayer.NowConviction = newPlayer.PlayerClass.NowConviction;
            newPlayer.Pontential = newPlayer.PlayerClass.Pontential;
            newPlayer.NowLevel = newPlayer.PlayerClass.NowLevel;
            newPlayer.Life = newPlayer.PlayerClass.Life;
            newPlayer.NowLife = newPlayer.PlayerClass.NowLife;
            newPlayer.Athletics = newPlayer.PlayerClass.Athletics;
            newPlayer.Stealth = newPlayer.PlayerClass.Stealth;
            newPlayer.Social = newPlayer.PlayerClass.Social;
            newPlayer.Perception = newPlayer.PlayerClass.Perception;
            newPlayer.ClassExp = newPlayer.PlayerClass.ClassExp;

            newPlayer.ClassAbility1 = new IllicitnessPrimeAbility();
            newPlayer.ClassAbility1.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility1.AbilityMotivationAmount = newPlayer.Unity;
            newPlayer.ClassAbility2 = new IllicitnessBribeAbility();
            newPlayer.ClassAbility2.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility2.AbilityMotivationAmount = newPlayer.Understanding;
            newPlayer.ClassAbility3 = new IllicitnessTauntAbility();
            newPlayer.ClassAbility3.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility3.AbilityMotivationAmount = newPlayer.Care;
            newPlayer.ClassAbility4 = new IllicitnessEnrageAbility();
            newPlayer.ClassAbility4.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility4.AbilityMotivationAmount = newPlayer.Autonomy;
            newPlayer.ClassAbility5 = new IllicitnessStealAbility();
            newPlayer.ClassAbility5.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility5.AbilityMotivationAmount = newPlayer.Control;
            newPlayer.ClassAbility6 = new IllicitnessExtortAbility();
            newPlayer.ClassAbility6.AbilityExpertiseAmount = newPlayer.ClassExp;
            newPlayer.ClassAbility6.AbilityMotivationAmount = newPlayer.Justice;

            newPlayer.PlayerPortrait = portraits[2];
            turnManager.PlayerCharacterList.Add(playerCount, newPlayer);
            turnManager.PlayerList.Add(playerCount, prefabPlayer[2]);
            turnManager.PlayerKeyList.Add(turnManager.PlayerList[playerCount], playerCount);
            turnManager.PlayerPortraitList.Add(playerCount, newPlayer.PlayerPortrait);
            turnManager.PlayerActionPointList.Add(turnManager.PlayerList[playerCount], newPlayer.PlayerActionPoint);
            prefabPlayer[2].GetComponentInChildren<UIBars>().SetArketypForBars(newPlayer);
            //uiPlayer.PopulateCharacterUI();

            isKrimClass = false;

        }
        else if (isTecherClass)
        {
            BaseArketype newPlayer = new BaseArketype();
            newPlayer.PlayerClass = new BaseTecherClass();
            newPlayer.ClassAbility1 = new TechTargetLockAbility();
            newPlayer.ClassAbility2 = new TechJointTargetingAbility();
            newPlayer.ClassAbility3 = new TechRepairAbility();
            newPlayer.ClassAbility4 = new TechFieldBotAbility();
            newPlayer.ClassAbility5 = new TechManipulateTechAbility();
            newPlayer.ClassAbility6 = new TechOverrideAbility();
            newPlayer.PlayerName = newPlayer.PlayerClass.PlayerName;
            newPlayer.MoveLength = newPlayer.PlayerClass.MoveLength;
            newPlayer.PlayerActionPoint = newPlayer.PlayerClass.PlayerActionPoint;
            newPlayer.Unity = newPlayer.PlayerClass.Unity;
            newPlayer.Understanding = newPlayer.PlayerClass.Understanding;
            newPlayer.Care = newPlayer.PlayerClass.Care;
            newPlayer.Autonomy = newPlayer.PlayerClass.Autonomy;
            newPlayer.Control = newPlayer.PlayerClass.Control;
            newPlayer.Justice = newPlayer.PlayerClass.Justice;
            newPlayer.Stress = newPlayer.PlayerClass.Stress;
            newPlayer.NowStress = newPlayer.PlayerClass.NowStress;
            newPlayer.Conviction = newPlayer.PlayerClass.Conviction;
            newPlayer.NowConviction = newPlayer.PlayerClass.NowConviction;
            newPlayer.Pontential = newPlayer.PlayerClass.Pontential;
            newPlayer.NowLevel = newPlayer.PlayerClass.NowLevel;
            newPlayer.Life = newPlayer.PlayerClass.Life;
            newPlayer.NowLife = newPlayer.PlayerClass.NowLife;
            newPlayer.Athletics = newPlayer.PlayerClass.Athletics;
            newPlayer.Stealth = newPlayer.PlayerClass.Stealth;
            newPlayer.Social = newPlayer.PlayerClass.Social;
            newPlayer.Perception = newPlayer.PlayerClass.Perception;
            newPlayer.ClassExp = newPlayer.PlayerClass.ClassExp;
            newPlayer.AthleticsAbility1 = new AthleticsLinkUpAbility();
            newPlayer.AthleticsAbility2 = new AthleticsUnifiedActionAbility();
            newPlayer.AthleticsAbility3 = new AthleticsRescueAbility();
            newPlayer.AthleticsAbility4 = new AthleticsCoverAbility();
            newPlayer.AthleticsAbility5 = new AthleticsAttackAbility();
            newPlayer.AthleticsAbility6 = new AthleticsCatchAbility();
            newPlayer.StealthAbility1 = new StealthTrapAbility();
            newPlayer.StealthAbility2 = new StealthFindAbility();
            newPlayer.StealthAbility3 = new StealthConcealAbility();
            newPlayer.StealthAbility4 = new StealthSneakAbility();
            newPlayer.StealthAbility5 = new StealthAmbushAbility();
            newPlayer.StealthAbility6 = new StealthStalkAbility();
            newPlayer.PlayerPortrait = portraits[2];
            turnManager.PlayerCharacterList.Add(playerCount, newPlayer);
            turnManager.PlayerList.Add(playerCount, prefabPlayer[1]);
            turnManager.PlayerKeyList.Add(turnManager.PlayerList[playerCount], playerCount);
            turnManager.PlayerPortraitList.Add(playerCount, newPlayer.PlayerPortrait);
            turnManager.PlayerActionPointList.Add(turnManager.PlayerList[playerCount], newPlayer.PlayerActionPoint);
            prefabPlayer[1].GetComponentInChildren<UIBars>().SetArketypForBars(newPlayer);
            //uiPlayer.PopulateCharacterUI();

            isTecherClass = false;

        }
    }
}
