using UnityEngine;
using UnityEngine.AI;

public class BasicAttack : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float attackRange = 2.0f; // Dystans do wykonania ataku
    private bool hasAttacked = false; // Flaga, aby kontrolowaæ jedno uderzenie na wejœcie do stanu

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (agent != null)
        {
            // Zatrzymaj agenta, aby postaæ nie porusza³a siê podczas ataku
            agent.isStopped = true;
        }

        // Flaga umo¿liwia jednorazowy atak na wejœcie do stanu
        hasAttacked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        // SprawdŸ dystans do gracza
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= attackRange && !hasAttacked)
        {
            hasAttacked = true;

            // Dodaj tutaj logikê zadawania obra¿eñ (Twój zaimplementowany skrypt)
            Debug.Log("AI atakuje gracza!");

            // Po zakoñczeniu ataku mo¿esz wróciæ do innego stanu lub pozostawiæ w stanie ataku
            animator.SetBool("isAttacking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            // W³¹cz agenta, aby móg³ znowu siê poruszaæ
            agent.isStopped = false;
        }

        hasAttacked = false; // Reset flagi
    }
}
