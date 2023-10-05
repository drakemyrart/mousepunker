using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyBehavior : MonoBehaviour
{

    //nav mesh agent
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private bool walking;
    private bool isWalkingAlowed;
    private bool running;

    //radius
    public float lookRadius;
    public float returnRadius;
    public float huntRadius;
    public float attackRadius;

    //attack
    //private bool action;
    //private float nextAction;
    //private float actionRate = 1f;

    //target
    Transform targetPlayer;
    public bool alerted;
    Transform targetExit;
    GameObject exit;
    public bool distracted;
    GameObject player;
    ClickToMove clickToMove;
    private bool gameOver;
    Transform targetStart;
    GameObject start;

    //Sound Effects
    private AudioSource walkingSoundEffectsEnemy;
    GameObject audioManager;
    AudioManager audioManagerScript;



    // Use this for initialization
    void Start ()
    {

        anim = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetPlayer = PlayerManager.instance.ourPlayer.transform;
        exit = GameObject.FindWithTag("Exit");
        targetExit = exit.transform;
        start = GameObject.FindWithTag("Start");
        targetStart = start.transform;
        distracted = false;
        alerted = false;
        audioManager = GameObject.FindWithTag("AudioManager");
        audioManagerScript = audioManager.GetComponent<AudioManager>();
        player = GameObject.FindWithTag("Player");
        clickToMove = player.GetComponent<ClickToMove>();
        



    }
	
	// Update is called once per frame
	void Update ()
    {
        isWalkingAlowed = clickToMove.isWalkingAloved;
        gameOver = clickToMove.gameOver;

        if (walkingSoundEffectsEnemy == null)
        {
            walkingSoundEffectsEnemy = audioManagerScript.soundEffects[1];
        }
        


        float distance = Vector3.Distance(transform.position, targetPlayer.position);
        float startDistance = Vector3.Distance(transform.position, targetStart.position);

        if (distance <= lookRadius && isWalkingAlowed && !gameOver && !distracted)
        {
            MoveAndAttack();
        }
        else if (distance > lookRadius && startDistance > attackRadius && isWalkingAlowed && !gameOver && !distracted)
        {
            MoveBack();
        }
        else if (distracted)
        {
            DistractGuard();
            running = true;
        }
        else
        {
            walking = false;
            alerted = false;
            clickToMove.enemyAlerted = false;
            transform.LookAt(targetExit);
            navMeshAgent.ResetPath();
        }
       
        
        if (walking && !walkingSoundEffectsEnemy.isPlaying)
        {
            walkingSoundEffectsEnemy.Play();
            //print("Enemy walking");
        }
        else if (!walking && walkingSoundEffectsEnemy.isPlaying)
        {
            walkingSoundEffectsEnemy.Stop();
            //print("Enemy stopped");
        }

        if (!running)
        {
            navMeshAgent.speed = 8f;
            navMeshAgent.acceleration = 30f;
            anim.SetBool("IsWalking", walking);
            anim.SetBool("IsRunning", false);
        }
        

        anim.SetBool("IsIdling", !walking);

    }

    void MoveAndAttack()
    {
        navMeshAgent.destination = targetPlayer.position;

        if (isWalkingAlowed | !distracted)
        {

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > huntRadius)
            {
                navMeshAgent.ResetPath();

                if (!alerted)
                {
                    alerted = true;
                    clickToMove.enemyAlerted = true;
                    //print("Enemy is Alerted to you");
                }

                transform.LookAt(targetPlayer);
                navMeshAgent.isStopped = true;
                walking = false;
            }
            else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < huntRadius && navMeshAgent.remainingDistance > attackRadius)
            {
                navMeshAgent.isStopped = false;
                walking = true;
            }
            else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < attackRadius)
            {
                transform.LookAt(targetPlayer);
                Capture();
                navMeshAgent.isStopped = true;
                walking = false;
                
            }
        }
        else
        {
            navMeshAgent.isStopped = true;
            walking = false;
            alerted = false;
            clickToMove.enemyAlerted = false;
        }
        

        
    }

    void MoveBack()
    {
        navMeshAgent.destination = targetStart.position;
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > attackRadius)
        {
            
            navMeshAgent.isStopped = false;
            walking = true;

        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < attackRadius)
        {
            navMeshAgent.ResetPath();
            navMeshAgent.isStopped = true;
            walking = false;
            transform.LookAt(targetExit);

        }

    }


    void DistractGuard()
    {
        navMeshAgent.destination = targetExit.position;
        
        navMeshAgent.speed = 20f;
        navMeshAgent.acceleration = 60f;
        anim.SetBool("IsRunning", walking);
        anim.SetBool("IsWalking", false);
        


        if (walkingSoundEffectsEnemy.clip.name != audioManagerScript.soundEffects[5].clip.name)
        {
            walkingSoundEffectsEnemy = audioManagerScript.soundEffects[5];
            //print("Enemy sound changed");
        }


        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > attackRadius)
        {
            //print("guard walking");
            navMeshAgent.isStopped = false;
            walking = true;


        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < attackRadius)
        {
            targetExit.GetComponent<ChangeMusicTrigger>().TriggerMusicChange();
            //FindObjectOfType<FireAlarm>().StopFireAlarm();
            //print("guard destroyed");
            navMeshAgent.ResetPath();
            navMeshAgent.isStopped = true;
            walking = false;
            Destroy(this.gameObject);
            
        }


    }

    void Capture()
    {
        navMeshAgent.ResetPath();
        transform.LookAt(targetPlayer);
        player.GetComponent<NavMeshAgent>().ResetPath();
        player.GetComponent<NavMeshAgent>().isStopped = true;

        clickToMove.gameOver = true;
        Vector3 enemyPos = targetPlayer.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(enemyPos, Vector3.up);
        player.transform.rotation = rotation;
        
        GetComponent<StoryTrigger>().TriggerStory();
    }
    /*
    private void OnDrawGizmos()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireArc(transform.position + new Vector3(0, 0.2f, 0), transform.up, transform.right, 360, lookRadius);

        Handles.color = Color.red;
        Handles.DrawWireArc(transform.position + new Vector3(0, 0.2f, 0), transform.up, transform.right, 360, huntRadius);

        Handles.color = Color.black;
        Handles.DrawWireArc(transform.position + new Vector3(0, 0.2f, 0), transform.up, transform.right, 360, attackRadius);
    }
    */
}
