using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFunctionsContainer : MonoBehaviour
{
    [Header("Patrol Variables")]
    public Transform[] patrolPoints;

    [Header("Senses Variables")]
    [Tooltip("Determines how far away this AI could see")]
    public float viewDistance = 10f;
    [Tooltip("Determines how wide or narrow the field of vision of this AI.")]
    [Range(0f, 360f)] public float viewAngle = 45f;
    public LayerMask obstacles;

    [Header("Locomotion Variables")]
    public float patrolSpeed = 1.5f;
    public float chaseSpeed = 3.5f;
    public float lookAtSpeed = 5f;

    [Header("VFX Variables")]
    public Light flashlight;
    [Tooltip("If true, the Flashlight's Spot Angle value will be overridden by the View Angle value. " +
        "Set this to true if you want the flashlight's light angle to reflect the AI's filed of view")]
    public bool useViewAngleValue;
    [Space]
    public ParticleSystem selfExplosionPFX;

    Transform player;
    NavMeshAgent agent;

    int p;
    float angularSpeedStore;
    float speedStore;

    Vector3 playerStorePosition;


    #region Initializers
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        angularSpeedStore = agent.angularSpeed;
        speedStore = agent.speed;

        if (useViewAngleValue)
        {
            flashlight.spotAngle = viewAngle / 2;
        }
    }

    private void Start()
    {
        player = PlayerFetcher.player.transform;
    }
    #endregion

    #region Setters and Overrides Functions
    public void SetPatrolLocomotion()
    {
        agent.speed = patrolSpeed;
        agent.angularSpeed = angularSpeedStore;
    }

    public void SetChaseLocomotion()
    {
        agent.speed = chaseSpeed;
        agent.angularSpeed = 0;
    }

    public void StopLocomotion()
    {
        agent.ResetPath();

        agent.speed = 0;
        agent.angularSpeed = 0;
    }

    public void ResetVariables()
    {
        agent.speed = speedStore;
        agent.angularSpeed = angularSpeedStore;
    }

    #endregion

    #region Senses Function
    public bool SeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, dirToPlayer);

            if (angle < viewAngle / 2)
            {
                if (Physics.Linecast(transform.position, player.position, obstacles) == false)
                {
                    return true;
                }

            }
        }

        return false;
    }

    public void LookAtPlayer()
    {
        Vector3 deltaPos = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);

        var targetRotation = Quaternion.LookRotation(deltaPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookAtSpeed * Time.deltaTime);
    }

    #endregion

    #region State Manager Functions
    public void Patrolling()
    {
        if (p <= patrolPoints.Length - 1)
        {
            if (Vector3.Distance(transform.position, patrolPoints[p].position) > 2)
            {
                agent.SetDestination(patrolPoints[p].position);
            }

            else if (Vector3.Distance(transform.position, patrolPoints[p].position) <= 2)
            {
                p++;
            }
        }

        else if (p > patrolPoints.Length - 1)
        {
            p = 0;
        }
    }
    public bool Chase()
    {

        if (Vector3.Distance(transform.position, player.position) <= viewDistance)
        {
            if (Vector3.Distance(transform.position, player.position) > agent.stoppingDistance)
            {
                GetComponent<Animator>().SetInteger("Attack", 0);

                if (SeePlayer())
                {
                    agent.SetDestination(player.position);
                    playerStorePosition = player.position;

                    LookAtPlayer();
                }

                else if (SeePlayer() == false)
                {
                    agent.SetDestination(playerStorePosition);

                    if (Vector3.Distance(transform.position, playerStorePosition) <= agent.stoppingDistance)
                    {
                        return false;
                    }
                }

                return true;
            }

            if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
            {
                //Rotate the AI To Face Player before attacking
                LookAtPlayer();
                GetComponent<Animator>().SetInteger("Attack", 1);
            }
        }

        else if (Vector3.Distance(transform.position, player.position) > viewDistance)
        {
            StopLocomotion();
            return false;
        }

        return true;
    }

    #endregion

    #region Action Functions
    public void OnAttack() //This function can be used to add attack system to the AI
    {
        //Simple Damage example:
        player.GetComponent<PlayerHealthManager>().Damage(1); //Damage value is currently hardcoded for showcase only
                                                              //Can be adjusted with custom variables later

        
        //Do Attack / Damage Functions

    }

    void OnFootstep() //we put this here so the foot steps animation will have a reciever
    {

    }

    #endregion

    #region Visual and Sound Effects Functions
    public void PlayParticleEffects()
    {
        selfExplosionPFX.Play();
    }

    public void FlashlightColorManager(Color flashlightColor)
    {
        flashlight.color = flashlightColor;
    }
    #endregion

}
