using UnityEngine;
using UnityEngine.AI;

public class BasicAttack : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float attackRange = 2.0f; // Dystans do wykonania ataku
    private bool hasAttacked = false; // Flaga, aby kontrolowa� jedno uderzenie na wej�cie do stanu

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (agent != null)
        {
            // Zatrzymaj agenta, aby posta� nie porusza�a si� podczas ataku
            agent.isStopped = true;
        }

        // Flaga umo�liwia jednorazowy atak na wej�cie do stanu
        hasAttacked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        // Sprawd� dystans do gracza
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= attackRange && !hasAttacked)
        {
            hasAttacked = true;

            // Dodaj tutaj logik� zadawania obra�e� (Tw�j zaimplementowany skrypt)
            Debug.Log("AI atakuje gracza!");

            // Po zako�czeniu ataku mo�esz wr�ci� do innego stanu lub pozostawi� w stanie ataku
            animator.SetBool("isAttacking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            // W��cz agenta, aby m�g� znowu si� porusza�
            agent.isStopped = false;
        }

        hasAttacked = false; // Reset flagi
    }
}
