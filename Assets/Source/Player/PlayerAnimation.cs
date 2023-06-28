using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Player Animator")]
    [SerializeField] private Animator animator;

    public void SetGameOverAnimation(bool value)
    {
        animator.SetBool("GameOver", value);
    }

    public void SetStartGameAnimation(bool value)
    {
        animator.SetBool("GameStarted", value);
    }
}
