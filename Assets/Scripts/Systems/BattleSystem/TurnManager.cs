using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Turn break down


public class TurnManager : MonoBehaviour
{
    static TurnManager instance;

    private bool walking;

    
    //GameObject[] enemyObjects;
    StoryManager storyManager;

    [SerializeField]
    GridSystem grid;

    [SerializeField]
    GameObject gameEfects;

    public LayerMask walkableMask;


    EnemyAI enemyAI;
    Queue<GameObject> enemyOrder = new Queue<GameObject>();
    Queue<EnemyAI> enemyAIOrder = new Queue<EnemyAI>();

    NavMeshAgent playerAgent;
    int playerMoveLength;

    BaseAbility playerAbilityChoice;
    BaseAbility enemyAbility;

    bool enemyTurnStart;
    bool playerTurnStart;

    bool allSelected;
    public bool abilitySelected;

    bool playerWon;

    GameObject targetedEnemy;
    GameObject targetedPlayer;
    GameObject currentPlayer;
    GameObject currentEnemy;
    int currentEnemyKey;
    int currentPlayerKey;

    //Battle Lists
    public Dictionary<int, GameObject> PlayerList = new Dictionary<int, GameObject>();
    public Dictionary<int, BaseArketype> PlayerCharacterList = new Dictionary<int, BaseArketype>();
    public Dictionary<GameObject, int> PlayerKeyList = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, int> EnemyKeyList = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, int> PlayerActionPointList = new Dictionary<GameObject, int>();
    public Dictionary<int, GameObject> EnemyList = new Dictionary<int, GameObject>();
    public Dictionary<int, BaseArketype> EnemyCharacterList = new Dictionary<int, BaseArketype>();
    public Dictionary<int, Sprite> PlayerPortraitList = new Dictionary<int, Sprite>();

    Dictionary<int, GameObject> ReadyPlayerList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> TempPlayerList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> DonePlayerList = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> DownPlayerList = new Dictionary<int, GameObject>();

    Dictionary<int, GameObject> ReadyEnemyList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> DoneEnemyList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> DownEnemyList = new Dictionary<int, GameObject>();

    public BaseAbility PlayerAbilityChoice { get; set; }
    public static GameState currentGameState;

    [SerializeField]
    DiceRoller dice;
    [SerializeField]
    UIPlayer uiPlayer;
    [SerializeField]
    UIGrid uiGrid;
    [SerializeField]
    CameraFollow camFollow;

    int[] result = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        uiGrid = FindObjectOfType<UIGrid>();
        uiPlayer = FindObjectOfType<UIPlayer>();
        dice = FindObjectOfType<DiceRoller>();

        storyManager = FindObjectOfType<StoryManager>();
        currentGameState = GameState.OutofCombat;
        enemyTurnStart = false;
        playerTurnStart = false;
        allSelected = false;
        playerWon = false;
        gameEfects.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetSelection();
            Debug.Log("Reset Selection");
        }

        switch (currentGameState)
        {
            case GameState.OutofCombat:
                //Debug.Log("Out of Combat");

                if (Input.GetKeyDown(KeyCode.A))
                {
                    //Debug.Log("A Pressed");
                    allSelected = true;
                    uiPlayer.SetSelectedCharacter((int)SelectionType.All);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("mouse btn 0");
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                            SelectPlayerChar(hit.collider.gameObject);
                            
                        }
                    }

                }

                if (Input.GetMouseButtonDown(1) && allSelected)
                {
                    //Debug.Log("mouse btn 1 and all");
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Vector3 currentHitPoint = hit.point;
                        Vector3 oldHitPoint = PlayerList[1].transform.position;
                        foreach (var item in PlayerList)
                        {
                            
                            playerAgent = item.Value.GetComponent<NavMeshAgent>();
                                                       
                            if (playerAgent != null)
                            {
               
                                if(currentHitPoint != oldHitPoint)
                                {
                                    walking = true;
                                    playerAgent.isStopped = false;
                                    playerAgent.destination = currentHitPoint;
                                    oldHitPoint = currentHitPoint;
                                }
                                else
                                {
                                    currentHitPoint = currentHitPoint + new Vector3(1.5f, 0, 1.5f);
                                    walking = true;
                                    playerAgent.isStopped = false;
                                    playerAgent.destination = currentHitPoint;
                                    oldHitPoint = currentHitPoint;
                                }
                                
                            }
                            playerAgent = null;
                        }
                        
                    }

                }

                

                if (Input.GetMouseButtonDown(1) && playerAgent != null)
                {
                    //Debug.Log("mouse btn 1");
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        walking = true;
                        playerAgent.isStopped = false;
                        playerAgent.destination = hit.point;
                    }
                    
                }
                break;

            case GameState.Story:
                foreach (var item in PlayerList)
                {
                    item.Value.GetComponent<NavMeshAgent>().isStopped = true;
                }

                break;

            //Battle Start --------------------------------------------------------------------------------------------------------------------------------------------
            case GameState.BattleStart:
                Debug.Log("Combat Start");
                foreach (var item in PlayerList)
                {
                    if (!ReadyPlayerList.ContainsKey(item.Key))
                    {
                        ReadyPlayerList.Add(item.Key, item.Value);
                        PlayerActionPointList[item.Value] = PlayerCharacterList[item.Key].PlayerActionPoint;
                    }
                    

                }
                foreach (var item in EnemyList)
                {
                    if (!ReadyEnemyList.ContainsKey(item.Key))
                    {
                        ReadyEnemyList.Add(item.Key, item.Value);
                    }
                    

                }

                foreach (var item in PlayerList)
                {
                    PlayerList[item.Key].GetComponent<NavMeshAgent>().isStopped = true;
                }
                DoGameEffects("Battle Start");
                playerWon = false;
                playerTurnStart = true;
                currentGameState = GameState.PlayerTurn;
                break;

            case GameState.PlayerAmbush:
                foreach (var item in PlayerList)
                {
                    ReadyPlayerList.Add(item.Key, item.Value);

                }
                foreach (var item in EnemyList)
                {
                    ReadyEnemyList.Add(item.Key, item.Value);

                }
                playerWon = false;
                playerTurnStart = true;
                currentGameState = GameState.PlayerTurn;
                break;

            case GameState.EnemyAmbush:
                foreach (var item in PlayerList)
                {
                    ReadyPlayerList.Add(item.Key, item.Value);

                }
                foreach (var item in EnemyList)
                {
                    ReadyEnemyList.Add(item.Key, item.Value);

                }
                playerWon = false;
                enemyTurnStart = true;
                currentGameState = GameState.EnemyTurn;
                break;

                //Player turn ---------------------------------------------------------------------------------------------------------------------------------
            case GameState.PlayerTurn:
                Debug.Log("Player Turn");
                if (playerTurnStart)
                {
                    DoGameEffects("Player Turn");
                    ResetSelection();
                    if (TempPlayerList.Count > 0)
                    {
                        foreach (var item in TempPlayerList)
                        {
                            if (!PlayerList.ContainsKey(item.Key))
                            {
                                PlayerList.Add(item.Key, item.Value);
                                PlayerKeyList.Add(item.Value, item.Key);
                                PlayerCharacterList.Add(item.Key, EnemyCharacterList[EnemyKeyList[item.Value]]);
                                PlayerActionPointList.Add(item.Value, 0);
                                DonePlayerList.Add(item.Key, item.Value);
                                ReadyEnemyList.Remove(EnemyKeyList[item.Value]);
                            }
                        }
                    }

                    if (DonePlayerList.Count > 0)
                    {
                        foreach (var item in PlayerList)
                        { 


                            if (!ReadyPlayerList.ContainsKey(item.Key) && !DownPlayerList.ContainsKey(item.Key))
                            {
                                ReadyPlayerList.Add(item.Key, item.Value);
                                if (DonePlayerList.ContainsKey(item.Key))
                                {
                                    DonePlayerList.Remove(item.Key);
                                }
                                
                            }
                        
                        }
                    }

                    foreach (var item in PlayerList)
                    {
                        PlayerActionPointList[item.Value] = PlayerCharacterList[item.Key].PlayerActionPoint;
                    }



                    playerTurnStart = false;
                }


                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                           
                            if (!abilitySelected && ReadyPlayerList.ContainsKey(PlayerKeyList[hit.collider.gameObject]))
                            {
                                
                                SelectPlayerChar(hit.collider.gameObject);
                            }
                                            
                            
                        }

                    }

                }

                if (abilitySelected && currentPlayer != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "Player")
                            {

                                if (PlayerAbilityChoice.AbilityID == (int)AbilityIDnr.Support)
                                {
                                    targetedPlayer = hit.collider.gameObject;
                                    if (targetedPlayer != null)
                                    {
                                        PlayerActionPointList[currentPlayer]--;
                                        UseAbility(PlayerAbilityChoice, targetedPlayer, (int)TargetType.Player);
                                        
                                    }
                                }


                            }

                            if (hit.collider.gameObject.tag == "Enemy")
                            {
                                targetedEnemy = hit.collider.gameObject;
                                PlayerActionPointList[currentPlayer]--;
                                UseAbility(PlayerAbilityChoice, targetedEnemy, (int)TargetType.Enemy);
                                
                                Debug.Log("Target selected");
                            }
                        }

                    }
                    
                    
                    
                }

                //Move
                if (Input.GetMouseButtonDown(1) && playerAgent != null)
                {
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, walkableMask))
                    {
                        float dist = Vector3.Distance(currentPlayer.transform.position, hit.point);
                        Debug.Log(dist);
                        if (dist < playerMoveLength)
                        {
                            
                            walking = true;
                            playerAgent.isStopped = false;
                            playerAgent.destination = hit.point;
                            PlayerActionPointList[currentPlayer]--;
                            
                        }
                    }
                    
                }

                if (EnemyList.Count < 1)
                {
                    playerWon = true;
                    currentGameState = GameState.GameOver;
                }

                if (ReadyPlayerList.Count < 1 && !playerTurnStart)
                {
                    if (ReadyPlayerList.Count < 1 && DonePlayerList.Count < 1)
                    {
                        playerWon = false;
                        currentGameState = GameState.GameOver;
                    }
                    else
                    {
                        enemyTurnStart = true;
                        currentGameState = GameState.EnemyTurn;
                        
                    }

                }

                if(currentPlayer != null)
                {
                    if (PlayerActionPointList[currentPlayer] < 1)
                    {
                        DonePlayerList.Add(currentPlayerKey, currentPlayer);
                        ReadyPlayerList.Remove(currentPlayerKey);
                        ResetSelection();
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    foreach (var item in PlayerList)
                    {
                        if (!DonePlayerList.ContainsKey(item.Key))
                        {
                            DonePlayerList.Add(item.Key, item.Value);
                            if (ReadyPlayerList.ContainsKey(item.Key))
                            {
                                ReadyPlayerList.Remove(item.Key);
                            }
                            
                            ResetSelection();
                        }
                    }
                }

                break;

                //Enemy turn ---------------------------------------------------------------------------------------------------------------------------
            case GameState.EnemyTurn:
                Debug.Log("Enemy Turn");
                if (enemyTurnStart)
                {

                    enemyTurnStart = false;
                    ResetSelection();
                    DoGameEffects("Enemy Turn");
                    

                    if (DoneEnemyList.Count > 0)
                    {
                        foreach (var item in EnemyList)
                        {
                            if (!ReadyEnemyList.ContainsKey(item.Key))
                            {
                                ReadyEnemyList.Add(item.Key, item.Value);
                                DoneEnemyList.Remove(item.Key);
                            }
                            
                        }
                    }

                    if (ReadyEnemyList.Count > 0)
                    {
                        
                        foreach (var item in ReadyEnemyList)
                        {
                            enemyOrder.Enqueue(item.Value);
                            enemyAIOrder.Enqueue(item.Value.GetComponent<EnemyAI>());
                        }
                        if (enemyOrder.Count > 0)
                        {
                            currentEnemy = enemyOrder.Dequeue();
                            enemyAI = enemyAIOrder.Dequeue();
                            currentEnemyKey = EnemyKeyList[currentEnemy];
                        }
                        
                        
                    }

                    if(enemyAI != null)
                    {
                        enemyAI.AIChoice();
                    }
                }

                if (ReadyEnemyList.Count < 1 && !enemyTurnStart)
                {
                    playerTurnStart = true;
                    currentGameState = GameState.PlayerTurn;
                }

                if (ReadyEnemyList.Count < 1 && !enemyTurnStart)
                {
                    if (ReadyEnemyList.Count < 1 && DoneEnemyList.Count < 1)
                    {
                        playerWon = true;
                        currentGameState = GameState.GameOver;
                    }
                    else
                    {
                        currentGameState = GameState.PlayerTurn;
                    }
                    
                }

                if (EnemyList.Count < 1)
                {
                    playerWon = true;
                    currentGameState = GameState.GameOver;
                }

                break;

            case GameState.GameOver:
                ReadyPlayerList.Clear();
                DonePlayerList.Clear();
                DownPlayerList.Clear();
                ReadyEnemyList.Clear();
                DoneEnemyList.Clear();
                DownEnemyList.Clear();
                EnemyList.Clear();

                foreach (var item in TempPlayerList)
                {
                    PlayerList.Remove(item.Key);
                    PlayerKeyList.Remove(item.Value);
                    PlayerCharacterList.Remove(item.Key);
                    PlayerActionPointList.Remove(item.Value);
                }

                TempPlayerList.Clear();

                if (playerWon)
                {
                    currentGameState = GameState.OutofCombat;
                }
                else
                {
                    //End of Game, Reload combat
                }
                
                break;
        }
    }


    public void ResetSelection()
    {
        if(currentPlayer != null)
        {
            currentPlayer.GetComponentInChildren<UIBars>().WalkingImage.enabled = false;
        }
        playerAgent = null;
        allSelected = false;
        uiPlayer.SetSelectedCharacter((int)SelectionType.None);
        targetedEnemy = null;
        currentPlayer = null;
        playerAbilityChoice = null;
        abilitySelected = false;

        //uiGrid.ResetVisability();

    }

    public void SelectPlayerChar(GameObject obj)
    {
        ResetSelection();
        if (currentGameState == GameState.PlayerTurn && !ReadyPlayerList.ContainsKey(PlayerKeyList[obj]))
        {
            return;
        }
        if (PlayerActionPointList[obj] < 1)
        {
            return;
        }

        allSelected = false;
        currentPlayer = obj;
        currentPlayerKey = PlayerKeyList[currentPlayer];
        uiPlayer.SetSelectedCharacter(currentPlayerKey);
        playerAgent = currentPlayer.GetComponent<NavMeshAgent>();
        playerMoveLength = PlayerCharacterList[currentPlayerKey].MoveLength;
        camFollow.target = currentPlayer.transform;
        if (currentGameState == GameState.PlayerTurn)
        {
            obj.GetComponentInChildren<UIBars>().WalkingImage.enabled = true;
            //uiGrid.SetVisability(currentPlayer.transform.position, playerMoveLength);

        }
        
    }

    public void SelectAbility(BaseAbility ability)
    {
        Debug.Log("Ability Selected");
        playerAbilityChoice = ability;
       
        abilitySelected = true;
    }

    public void UseAbility(BaseAbility ability, GameObject target, int type)
    {
        Debug.Log("Using ability");
        dice.Roll(ability.AbilityExpertiseAmount, ability.AbilityMotivationAmount);
        result[0] = dice.RollResult[0];
        result[1] = dice.RollResult[1];
        if (currentGameState == GameState.PlayerTurn)
        {
            if (result[0] > (5 - PlayerCharacterList[currentPlayerKey].Bonus) || result[1] > (5 - PlayerCharacterList[currentPlayerKey].Bonus))
            {
                AbilityCalculation(ability, target, type);
            }
            else
            {
                DoGameEffects("Failure");
            }
        }
        else
        {
            if (result[0] > 6 || result[1] > 6)
            {
                AbilityCalculation(ability, target, type);
            }
            else
            {
                DoGameEffects("Failure");
            }
        }
       
    }

    public void NextEnemy()
    {
        StartCoroutine(WaitABit());
        if (currentEnemy != null)
        {
            
            if (ReadyEnemyList.ContainsValue(currentEnemy))
            {
                DoneEnemyList.Add(currentEnemyKey, currentEnemy);
                ReadyEnemyList.Remove(currentEnemyKey);
                enemyAI = null;
            }

            if (ReadyEnemyList.Count > 0)
            {
                if (enemyOrder.Count > 0)
                {
                    currentEnemy = enemyOrder.Dequeue();
                    enemyAI = enemyAIOrder.Dequeue();
                    currentEnemyKey = EnemyKeyList[currentEnemy];
                }


                if (enemyAI != null)
                {
                    enemyAI.AIChoice();
                }
            }
            else
            {
                currentEnemy = null;
                enemyAI = null;

            }
        }

       
    }

    public void CalculateStats(BaseArketype character, GameObject obj, int type, int targetStat)
    {
        if (targetStat == (int)AbilityTargetnr.Life)
        {
            if (character.NowLife < 1)
            {
                if (type == (int)TargetType.Enemy)
                {
                    //DownEnemyList.Add(EnemyKeyList[obj], obj);
                    ReadyEnemyList.Remove(EnemyKeyList[obj]);
                    EnemyList.Remove(EnemyKeyList[obj]);
                    EnemyKeyList.Remove(obj);
                    Destroy(obj);
                    DoGameEffects("Enemy Died");

                }
                else if (type == (int)TargetType.Player)
                {
                    DownPlayerList.Add(PlayerKeyList[obj], obj);
                    ReadyPlayerList.Remove(PlayerKeyList[obj]);
                    DoGameEffects("Player Down");

                }
            }
            else
            {
                if (type == (int)TargetType.Player)
                {
                    if (DownPlayerList.ContainsKey(PlayerKeyList[obj]))
                    {
                        ReadyPlayerList.Add(PlayerKeyList[obj], obj);
                        DownPlayerList.Remove(PlayerKeyList[obj]);
                    }
                }
                
            }
        }

        if (targetStat == (int)AbilityTargetnr.Conviction)
        {
            if (character.NowConviction < 1)
            {
                if (type == (int)TargetType.Enemy)
                {

                    //DownEnemyList.Add(EnemyKeyList[obj], obj);
                    ReadyEnemyList.Remove(EnemyKeyList[obj]);
                    EnemyList.Remove(EnemyKeyList[obj]);
                    EnemyKeyList.Remove(obj);
                    Destroy(obj);
                    DoGameEffects("Enemy joined your gang!");
                }

            }
        }
        if (targetStat == (int)AbilityTargetnr.Stress)
        {
            if (character.NowStress < 1)
            {
                if (type == (int)TargetType.Enemy)
                {
                    //DownEnemyList.Add(EnemyKeyList[obj], obj);
                    ReadyEnemyList.Remove(EnemyKeyList[obj]);
                    EnemyList.Remove(EnemyKeyList[obj]);
                    EnemyKeyList.Remove(obj);
                    Destroy(obj);
                    DoGameEffects("Enemy ran away!");

                }

            }
        }
        if (targetStat == (int)AbilityTargetnr.All)
        {
            if (character.NowStress < 1)
            {
                if (type == (int)TargetType.Enemy)
                {
                    //DownEnemyList.Add(EnemyKeyList[obj], obj);
                    ReadyEnemyList.Remove(EnemyKeyList[obj]);
                    EnemyList.Remove(EnemyKeyList[obj]);
                    EnemyKeyList.Remove(obj);
                    Destroy(obj);
                    DoGameEffects("Enemy ran away!");
                }

            }
            if (character.NowConviction < 1)
            {
                if (type == (int)TargetType.Enemy)
                {

                    //DownEnemyList.Add(EnemyKeyList[obj], obj);
                    ReadyEnemyList.Remove(EnemyKeyList[obj]);
                    EnemyList.Remove(EnemyKeyList[obj]);
                    EnemyKeyList.Remove(obj);
                    Destroy(obj);
                    DoGameEffects("Enemy joined your gang!");
                }

            }
        }
    }

    public void AbilityCalculation(BaseAbility ability, GameObject target, int type)
    {
        if (ability.AbilityID == (int)AbilityIDnr.Attack)
        {
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Life)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowLife = EnemyCharacterList[EnemyKeyList[target]].NowLife - ability.AbilityPower;
                    CalculateStats(EnemyCharacterList[EnemyKeyList[target]], target, type, ability.AbilityTargetStat);
                }
                else if (type == (int)TargetType.Player)
                {
                    PlayerCharacterList[PlayerKeyList[target]].NowLife = PlayerCharacterList[PlayerKeyList[target]].NowLife - ability.AbilityPower;
                    CalculateStats(PlayerCharacterList[PlayerKeyList[target]], target, type, ability.AbilityTargetStat);
                }
                DoGameEffects("PEW PEW");
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Stress)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowStress = EnemyCharacterList[EnemyKeyList[target]].NowStress - ability.AbilityPower;
                }
                DoGameEffects("Chicken Shits");
            }

            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Conviction)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowConviction = EnemyCharacterList[EnemyKeyList[target]].NowConviction - ability.AbilityPower;
                }
                DoGameEffects("Come on, Stop it!");
            }
        }
        if (ability.AbilityID == (int)AbilityIDnr.Support)
        {
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Life)
            {
                if (type == (int)TargetType.Player)
                {
                    PlayerCharacterList[PlayerKeyList[target]].NowLife = PlayerCharacterList[PlayerKeyList[target]].NowLife + ability.AbilityPower;
                    if (PlayerCharacterList[PlayerKeyList[target]].NowLife > PlayerCharacterList[PlayerKeyList[target]].Life)
                    {
                        PlayerCharacterList[PlayerKeyList[target]].NowLife = PlayerCharacterList[PlayerKeyList[target]].Life;
                    }
                    DoGameEffects("Heals");
                }
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Stress)
            {
                if (type == (int)TargetType.Player)
                {
                    PlayerCharacterList[PlayerKeyList[target]].NowStress = PlayerCharacterList[PlayerKeyList[target]].NowStress + ability.AbilityPower;
                    if (PlayerCharacterList[PlayerKeyList[target]].NowStress > PlayerCharacterList[PlayerKeyList[target]].Stress)
                    {
                        PlayerCharacterList[PlayerKeyList[target]].NowStress = PlayerCharacterList[PlayerKeyList[target]].Stress;
                    }
                    DoGameEffects("Calm Down, friend!");
                }
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Conviction)
            {
                if (type == (int)TargetType.Player)
                {
                    PlayerCharacterList[PlayerKeyList[target]].NowConviction = PlayerCharacterList[PlayerKeyList[target]].NowConviction + ability.AbilityPower;
                    if (PlayerCharacterList[PlayerKeyList[target]].NowConviction > PlayerCharacterList[PlayerKeyList[target]].Conviction)
                    {
                        PlayerCharacterList[PlayerKeyList[target]].NowConviction = PlayerCharacterList[PlayerKeyList[target]].Conviction;
                    }
                    DoGameEffects("You got this, friend");
                }
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Bonus)
            {
                if (type == (int)TargetType.Player)
                {
                    PlayerCharacterList[PlayerKeyList[target]].Bonus = ability.AbilityPower;
                }
                DoGameEffects("Time for a bonus!");
            }
        }
        if (ability.AbilityID == (int)AbilityIDnr.Voice)
        {
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Life)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowLife = EnemyCharacterList[EnemyKeyList[target]].NowLife - ability.AbilityPower;
                    CalculateStats(EnemyCharacterList[EnemyKeyList[target]], target, type, ability.AbilityTargetStat);
                }
                
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Stress)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowStress = EnemyCharacterList[EnemyKeyList[target]].NowStress - ability.AbilityPower;
                    CalculateStats(EnemyCharacterList[EnemyKeyList[target]], target, type, ability.AbilityTargetStat);
                }
                //DoGameEffects("RUN AWAY!");
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Conviction)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowConviction = EnemyCharacterList[EnemyKeyList[target]].NowConviction - ability.AbilityPower;
                    CalculateStats(EnemyCharacterList[EnemyKeyList[target]], target, type, ability.AbilityTargetStat);
                }
                //DoGameEffects("Join the winning side!");
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.All)
            {
                if (type == (int)TargetType.Enemy)
                {
                    EnemyCharacterList[EnemyKeyList[target]].NowConviction = EnemyCharacterList[EnemyKeyList[target]].NowConviction - ability.AbilityPower;
                    EnemyCharacterList[EnemyKeyList[target]].NowStress = EnemyCharacterList[EnemyKeyList[target]].NowStress - ability.AbilityPower;
                    CalculateStats(EnemyCharacterList[EnemyKeyList[target]], target, type, ability.AbilityTargetStat);
                }
                //DoGameEffects("You will loose!");
            }
            
        }
        if (ability.AbilityID == (int)AbilityIDnr.Aggitation)
        {
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Life)
            {
                if (type == (int)TargetType.Enemy)
                {
                    target.GetComponent<EnemyAI>().Vendetta = currentPlayer;
                }
                DoGameEffects("You can't hit me!");
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Stress)
            {
                if (type == (int)TargetType.Enemy)
                {
                    target.GetComponent<EnemyAI>().Disoriented = true;
                }
                DoGameEffects("Disoriented");
            }
            if (ability.AbilityTargetStat == (int)AbilityTargetnr.Conviction)
            {
                if (type == (int)TargetType.Enemy)
                {
                    target.GetComponent<EnemyAI>().Suppressed = true;
                }
                DoGameEffects("PEW PEW PEW PEW PEW PEW");
            }
        }
        

        target.GetComponentInChildren<UIBars>().UpdateBars();
    }

    public void ChangeGameState(GameState state)
    {
        currentGameState = state;
    }

    public void DoGameEffects(string effect)
    {
        
        gameEfects.SetActive(true);
        gameEfects.GetComponentInChildren<Text>().text = effect;
        StartCoroutine(WaitABit());
        
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(1f);
        gameEfects.SetActive(false);
        yield break;
        
    }

    // State choosing
    public static void SwitchTurn(GameState switchState) => currentGameState = switchState;
}


