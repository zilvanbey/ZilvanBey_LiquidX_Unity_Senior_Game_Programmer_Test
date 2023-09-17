using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("PlayerDetected", false); //we put this here as a resetter
        animator.SetBool("PlayerHeard", false);

        AIFunctionsContainer ai = animator.GetComponent<AIFunctionsContainer>();
        ai.SetPatrolLocomotion();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AIFunctionsContainer ai = animator.GetComponent<AIFunctionsContainer>();

        if(ai.SeePlayer() == false)
        {
            ai.Patrolling();
            animator.SetBool("PlayerDetected", false);
        }

        else if (ai.SeePlayer())
        {
            
            animator.SetBool("PlayerDetected", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
