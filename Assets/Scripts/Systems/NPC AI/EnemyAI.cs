using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private int actionPoints;
    private float weaponRange;
    GameObject target;
    GameObject vendetta;
    [SerializeField]
    GridSystem grid;
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    BaseArketype enemyChar;

    float moveDistance;

    [SerializeField]
    LayerMask obstacleMask;

    public List<GameObject>Targets = new List<GameObject>();
    public GameObject Vendetta { get; set; }
    public int ActionPoints { get; set; }
    public float WeaponRange { get; set; }
    public float MoveDistance { get; set; }

    [SerializeField]
    TurnManager turnManager;

    public bool Disoriented;
    public bool Suppressed;

    private void Start()
    {
        grid = FindObjectOfType<GridSystem>();
        turnManager = FindObjectOfType<TurnManager>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void SetEnemyChar(BaseArketype ark)
    {
        enemyChar = ark;
    }

    public void AIChoice()
    {
        StartCoroutine(WaitABit());
    }

    void RunChoices()
    {
        if (Suppressed)
        {
            Debug.Log("Suppressed");
            Suppressed = false;
            turnManager.NextEnemy();
        }

        actionPoints = 1;
        while (actionPoints > 0)
        {
            if (target == null)
            {
                TargetChoice();

            }
            if (target == null)
            {
                MoveToPos();

            }
            else
            {
                AbilityChoice();
            }

        }
        Disoriented = false;
        target = null;
        turnManager.NextEnemy();
        //next enemy or end of turn here
    }

    public void TargetChoice()
    {
        if (vendetta != null)
        {
            target = vendetta;
        }
        else if (Disoriented)
        {
            List<GameObject> disTargets = new List<GameObject>();
            foreach (var item in turnManager.EnemyList)
            {
                disTargets.Add(item.Value);

            }
            int key = Random.Range(0, disTargets.Count - 1);
            target = disTargets[key];
        }
        else
        {
            if (Targets.Count == 0)
            {
                //Debug.Log("Targeting");
                foreach (var item in turnManager.PlayerList)
                {
                    if (!turnManager.DownPlayerList.ContainsKey(item.Key))
                    {
                        if (!Targets.Contains(item.Value))
                        {
                            Targets.Add(item.Value);
                        }
                    }
                    
                }
                
            }
            else
            {
                if(turnManager.DownPlayerList.Count > 0)
                {
                    foreach (var item in turnManager.DownPlayerList)
                    {
                        if (Targets.Contains(item.Value))
                        {
                            Targets.Remove(item.Value);
                        }
                        
                    }
                }
                foreach (var item in turnManager.EnemyList)
                {
                    if (Targets.Contains(item.Value))
                    {
                        Targets.Remove(item.Value);

                    }

                }
            }
            if (Targets.Count > 0)
            {
                foreach (var pc in Targets)
                {
                    if (!Physics.Linecast(transform.position, pc.transform.position))
                    {
                        Debug.Log("Target hidden");
                        continue;
                    }
                    //Debug.Log("Target found");
                    target = pc;
                    break;

                }
            }
            else
            {
                //Debug.Log("No targets");
                turnManager.NextEnemy();
            }
            
        }
    }

    private void MoveToPos()
    {
       // Debug.Log("Moving to target");
        List<float> distances = new List<float>();
        List<Vector3> targetPos = new List<Vector3>();
        foreach (var pc in Targets)
        {
            float dist = Vector3.Distance(transform.position, pc.transform.position);
            distances.Add(dist);
            targetPos.Add(pc.transform.position);

        }
        float min = distances.Min();
        int i = distances.IndexOf(min);

        Vector3 targetedPos = targetPos[i];
        Vector3 dir = (this.transform.position - targetedPos).normalized;

        Vector3 stopPos = this.transform.position + dir * moveDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(stopPos, out hit, moveDistance, NavMesh.AllAreas))
        {
            stopPos = hit.position;
            
        }

        agent.isStopped = false;
        agent.destination = stopPos;
       

        TargetChoice();
        actionPoints--;
    }

    private void AbilityChoice()
    {
        
        if (target != null)
        {
            Debug.Log("Enemy Use Ability");
            turnManager.UseAbility(enemyChar.AthleticsAbility5, target, (int)TargetType.Player);
            actionPoints--;
        }
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(3f);
        RunChoices();
        yield break;

    }
}
