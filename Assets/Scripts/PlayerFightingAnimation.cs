//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerFightingAnimation : MonoBehaviour
//{
//    private Animator animator;

//    void Start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    // Método para activar las animaciones de combate
//    public void SetCombatState(bool isInCombat)
//    {
//        // Activamos o desactivamos el estado de combate
//        animator.SetBool("isFighting", isInCombat);
//    }

//    // Método para ejecutar la animación de ataque
//    public void TriggerAttackAnimation()
//    {
//        animator.SetTrigger("Attack");
//    }
//}