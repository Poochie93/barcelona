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

//    // M�todo para activar las animaciones de combate
//    public void SetCombatState(bool isInCombat)
//    {
//        // Activamos o desactivamos el estado de combate
//        animator.SetBool("isFighting", isInCombat);
//    }

//    // M�todo para ejecutar la animaci�n de ataque
//    public void TriggerAttackAnimation()
//    {
//        animator.SetTrigger("Attack");
//    }
//}