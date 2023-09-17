using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public LayerMask enemyLayer;
    public LayerMask obstaclesLayer;
    [Space]
    [Tooltip("Determines the distance for the player's footsteps (while running) to be heard by an enemy")]
    public float footStepSoundDistance = 10f;
    [Space]
    [Tooltip("Set this to true if you would like to visualize variables in the Editor")]
    public bool visualizeInEditor;


    [HideInInspector] public List<Transform> enemies = new List<Transform>();


    public void MakeFootstepSound()
    {
        enemies.Clear();
        Collider[] enemiesInRadius = Physics.OverlapSphere(transform.position, footStepSoundDistance, enemyLayer);

        for(int i = 0; i < enemiesInRadius.Length; i++)
        {
            Transform target = enemiesInRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            float distToTarget = Vector3.Distance(transform.position, target.position);

            if(Physics.Raycast(transform.position, dirToTarget, distToTarget, obstaclesLayer) == false)
            {
                enemies.Add(target);

                Transform[] enemiesArray = enemies.ToArray();
                for(int a = 0; a < enemiesArray.Length; a++)
                {
                    enemiesArray[i].GetComponent<Animator>().SetBool("PlayerHeard", true);
                }
            }
        }
    }
    public void ClearEnemyList()
    {
        enemies.Clear();
    }

    private void OnDrawGizmos()
    {
        if (visualizeInEditor)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, footStepSoundDistance);
        } 
    }
}
