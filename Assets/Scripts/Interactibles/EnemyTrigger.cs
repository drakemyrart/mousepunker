using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : Interactable
{
    [SerializeField]
    GameObject[] enemyGroup;

    


    [SerializeField]
    TurnManager turnManager;


    bool isInCombat;

    private void Start()
    {
        SetRadius();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, IntRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Player" && !isInCombat)
            {
                Interact();
                isInCombat = true;
            }
            
        }
    }

    public override void Interact()
    {
        for (int i = 0; i < enemyGroup.Length; i++)
        {
            
            CreateEnemyCharacter(i);
        }
        
        turnManager.ChangeGameState(GameState.BattleStart);
        Debug.Log("combat triggered");
        Destroy(this);
    }

    public override void SetRadius()
    {
        IntRadius = 30f;
    }

    public void CreateEnemyCharacter(int x)
    {
        BaseArketype newPlayer = new BaseArketype();
        newPlayer.PlayerClass = new BaseEnemyClass();
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
        newPlayer.AthleticsAbility5.AbilityExpertiseAmount = newPlayer.Athletics;
        newPlayer.AthleticsAbility5.AbilityMotivationAmount = newPlayer.Control;

        newPlayer.AthleticsAbility6 = new AthleticsCatchAbility();
        newPlayer.StealthAbility1 = new StealthTrapAbility();
        newPlayer.StealthAbility2 = new StealthFindAbility();
        newPlayer.StealthAbility3 = new StealthConcealAbility();
        newPlayer.StealthAbility4 = new StealthSneakAbility();
        newPlayer.StealthAbility5 = new StealthAmbushAbility();
        newPlayer.StealthAbility6 = new StealthStalkAbility();
        turnManager.EnemyCharacterList.Add(x, newPlayer);
        turnManager.EnemyList.Add(x, enemyGroup[x]);
        turnManager.EnemyKeyList.Add(turnManager.EnemyList[x], x);
        enemyGroup[x].GetComponentInChildren<UIBars>().SetArketypForBars(newPlayer);
        enemyGroup[x].GetComponent<EnemyAI>().SetEnemyChar(newPlayer);


    }

}
