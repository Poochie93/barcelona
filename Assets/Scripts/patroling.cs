using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float ChaseRange = 5;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer = 0;
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform t in wayPointsObject)
            wayPoints.Add(t);

            agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Jeœli agent osi¹gn¹³ obecny punkt docelowy, ustaw nowy punkt docelowy
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        // SprawdŸ odleg³oœæ do gracza
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= ChaseRange)
        {
            animator.SetBool("isrunning", true); // Przejœcie do stanu biegu
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
