using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float attackRange = 2.0f; // Zasiêg ataku

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Gracz nie zosta³ znaleziony.");
        }

        // Ustaw prêdkoœæ biegu
        agent.speed = 6.0f; // Prêdkoœæ biegu AI
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        // Poruszanie siê w stronê gracza
        agent.SetDestination(player.position);

        // SprawdŸ dystans od gracza
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= attackRange) // Jeœli gracz jest w zasiêgu ataku
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
