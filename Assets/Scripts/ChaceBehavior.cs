using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float attackRange = 2.0f; // Zasi�g ataku

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Gracz nie zosta� znaleziony.");
        }

        // Ustaw pr�dko�� biegu
        agent.speed = 6.0f; // Pr�dko�� biegu AI
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        // Poruszanie si� w stron� gracza
        agent.SetDestination(player.position);

        // Sprawd� dystans od gracza
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= attackRange) // Je�li gracz jest w zasi�gu ataku
        {
            animator.SetTrigger("AttackTrigger"); // Jednorazowy atak
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset NavMeshAgent po opuszczeniu stanu
        if (agent != null)
        {
            agent.ResetPath();
        }
    }
}
