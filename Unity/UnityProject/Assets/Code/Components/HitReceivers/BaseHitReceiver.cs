using UnityEngine;
using System.Collections;
using Assets.Code.Components;

[RequireComponent(typeof(Animator))]
public abstract class BaseHitReceiver : MonoBehaviour
{
    protected Animator animator;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public virtual void ReceiveHit()
    {
        //var movingController = this.GetComponent<MovingController>();
        //if (movingController != null) movingController.IsBlocked = true;

        if (animator != null)
        {
            animator.SetTrigger("hit");
            //Debug.Log("ReceiveHit");
        }
    }
}
