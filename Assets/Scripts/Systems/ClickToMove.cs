using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

    [Header("Stats")]
    public float attackDistance;
    public float attackRate;
    private float nextAttack;

    //navmesh
    private NavMeshAgent playerAgent;
    private Animator anim;

    //enemy
    private Transform targetedEnemy;
    private bool enemyClicked;

    //walking and running
    private bool walking;
    public bool isWalkingAloved;


    //interactables
    private Transform targetedObject;
    private bool objectClicked;
    private bool distraction;
    public bool gameOver;
    public bool enemyAlerted;
    public bool finish;

    //Doubleclick
    private bool oneClick;
    private bool doubleClick;
    private float timerForDoubleClick;
    private float delay = 0.25f;

    //Sound Effects
    private AudioSource walkingSoundEffects;
    GameObject audioManager;
    AudioManager audioManagerScript;

    private Vector3 moveTarget;
    public Vector3 MoveTarget { get; set; }


    void Awake ()
    {
        anim = GetComponentInChildren<Animator>();
        playerAgent = GetComponent<NavMeshAgent>();
        isWalkingAloved = false;
        distraction = false;
        gameOver = false;
        enemyAlerted = false;
        //audioManager = GameObject.FindWithTag("AudioManager");
        //audioManagerScript = audioManager.GetComponent<AudioManager>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        //importing sound effects
        if(walkingSoundEffects == null && audioManagerScript != null)
        {
            walkingSoundEffects = audioManagerScript.soundEffects[0];
        }

        //raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        //If story is going
        if (!isWalkingAloved)
        {
            if (anim != null)
            {
                anim.SetBool("IsIdling", true);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
            }
            playerAgent.ResetPath();
            playerAgent.isStopped = true;
            walking = false;
            
        }

        if (!walking)
        {
            playerAgent.ResetPath();
            playerAgent.isStopped = true;
            walking = false;
            if (anim != null)
            {
                anim.SetBool("IsIdling", true);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
            }
        }


        // getting the mouse click position
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && isWalkingAloved)
        {
            playerAgent.ResetPath();

            if(audioManagerScript != null)
            {
                if (walkingSoundEffects.isPlaying)
                {
                    walkingSoundEffects.Stop();
                }
            }
            


            if(Physics.Raycast(ray, out raycastHit, 1000))
            {
                if(raycastHit.collider.tag == "Enemy")
                {
                    targetedEnemy = raycastHit.transform;
                    enemyClicked = true;
                    //print("Enemy hit");
                }
                else if (raycastHit.collider.tag == "Inspect")
                {
                    targetedObject = raycastHit.transform;
                    objectClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    objectClicked = false;
                    playerAgent.isStopped = false;
                    playerAgent.destination = moveTarget;
                    

                }
            }

            playerAgent.speed = 8f;
            playerAgent.acceleration = 30f;

            if (anim != null)
            {
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsWalking", walking);
            }
            if (audioManagerScript != null)
            {
                if (walkingSoundEffects.clip.name != audioManagerScript.soundEffects[0].clip.name)
                {
                    walkingSoundEffects = audioManagerScript.soundEffects[0];
                }
            }
            
        }

        if (Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(0) && isWalkingAloved)
        {
            playerAgent.ResetPath();

            if (audioManagerScript != null)
            {
                if (walkingSoundEffects.isPlaying)
                {
                    walkingSoundEffects.Stop();
                }
            }

            if (Physics.Raycast(ray, out raycastHit, 1000))
            {
                if (raycastHit.collider.tag == "Enemy")
                {
                    targetedEnemy = raycastHit.transform;
                    enemyClicked = true;
                    //print("Enemy hit");
                }
                else if (raycastHit.collider.tag == "Inspect")
                {
                    targetedObject = raycastHit.transform;
                    objectClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    objectClicked = false;
                    playerAgent.isStopped = false;
                    playerAgent.destination = moveTarget;


                }
            }

            playerAgent.speed = 20f;
            playerAgent.acceleration = 60f;

            if (anim != null)
            {
                anim.SetBool("IsRunning", walking);
                anim.SetBool("IsWalking", false);
            }
            
            if (walkingSoundEffects.clip.name != audioManagerScript.soundEffects[4].clip.name && audioManagerScript != null)
            {
                walkingSoundEffects = audioManagerScript.soundEffects[4];
            }
        }

    

        // triggering click reactions
        if (enemyClicked && isWalkingAloved)
        {
            MoveAndAttack();
        }
        else if (objectClicked && targetedObject.gameObject.tag == "Inspect")
        {
            ReadInspect(targetedObject);
        }
        else
        {
            if (!playerAgent.pathPending && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                walking = false;
                playerAgent.isStopped = true;
                playerAgent.ResetPath();
            }
            else if (!playerAgent.pathPending && playerAgent.remainingDistance >= playerAgent.stoppingDistance)
            {
                walking = true;
                playerAgent.isStopped = false;
                
            }
        }
        
        if (anim != null)
        {
            anim.SetBool("IsIdling", !walking);
        }

        if (audioManagerScript != null)
        {
            //playing sound effects
            if (walking && !walkingSoundEffects.isPlaying)
            {

                walkingSoundEffects.Play();
                //print("Player walking");
            }
            else if (!walking && walkingSoundEffects.isPlaying)
            {

                walkingSoundEffects.Stop();
                //print("Player stopped");
            }
        }
       
    }

    void MoveAndAttack()
    {
        if(targetedEnemy == null)
        {
            return;
        }

        enemyClicked = false;
        GetComponent<StoryTrigger>().TriggerStory();
        
        
        /*
        navMeshAgent.destination = targetedEnemy.position;

        if (navMeshAgent.remainingDistance >= attackDistance)
        {
            navMeshAgent.isStopped = false;
            walking = true;
        }
        else
        {
            transform.LookAt(targetedEnemy);
            Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;

            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
            }

            navMeshAgent.isStopped = true;
            walking = false;
        }
        */

        playerAgent.isStopped = true;
        walking = false;

        if (audioManagerScript != null)
        {
            if (walkingSoundEffects.isPlaying)
            {
                walkingSoundEffects.Stop();
            }
        }
        
    }

    void ReadInspect(Transform target)
    {
        //set target
        playerAgent.destination = target.position;

       
        if (enemyAlerted == false)
        {
            // story pathfinder
            foreach (Transform child in target)
            {
                /*
                if (child.CompareTag("Fire"))
                {
                    distraction = true;
                    FindObjectOfType<FireAlarm>().StartFireAlarm();
                }
                
                else*/
                if (child.CompareTag("GameOver"))
                {
                    gameOver = true;
                }
                else if (child.CompareTag("Finish"))
                {
                    finish = true;
                }
            }

            //go close 
            if (!playerAgent.pathPending && playerAgent.remainingDistance > attackDistance)
            {
                playerAgent.isStopped = false;
                walking = true;
                
            }
            //then read
            else if (!playerAgent.pathPending && playerAgent.remainingDistance < attackDistance)
            {
                playerAgent.isStopped = true;
                transform.LookAt(target);
                walking = false;
                

                //story place
                target.GetComponent<StoryTrigger>().TriggerStory();


                objectClicked = false;
                playerAgent.ResetPath();
            }
        }
        
        

    }


    public void CheckStoryAction()
    {
        if (FindObjectOfType<StoryManager>().storyEnd && distraction && FindObjectOfType<EnemyBehavior>() != null)
        {
            FindObjectOfType<EnemyBehavior>().distracted = true;
        }
        if (FindObjectOfType<StoryManager>().storyEnd && gameOver)
        {
            FindObjectOfType<SceneController>().GameOver();
            //print("Game Over, man");
        }
        if (FindObjectOfType<StoryManager>().storyEnd && finish)
        {
            FindObjectOfType<SceneController>().ExitGame();
            //print("Game Over, man");
        }
    }

      
}
