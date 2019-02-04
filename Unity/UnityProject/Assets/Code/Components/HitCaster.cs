using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class HitCaster : MonoBehaviour
{
    [SerializeField]
    protected LayerMask targetMask;
    [SerializeField]
    float distance = 0.2f;

    private Animator animator;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public bool CastHitIfNeeded(Vector3 direction)
    {
        var hit = Physics2D.Raycast(transform.position, direction, distance, targetMask);

        return CastHitIfNeeded(hit);
    }

    public bool CastHitIfNeeded(RaycastHit2D hit)
    {
        bool successfulHit = hit.collider != null;

        if (successfulHit)
        {
            var targetHitReceiver = hit.collider.gameObject.GetComponent<BaseHitReceiver>();
            // hit is successful and target can recieve the hit
            if (targetHitReceiver != null)
            {
/*
                var hitCollector = GetComponentInParent<HitInfoCollector>();
                if (hitCollector != null)
                {
                    hitCollector.CollectHit();
                }
*/

                //if (animator != null) animator.SetTrigger("hit");
                targetHitReceiver.ReceiveHit();
            }
        }

        return successfulHit;
    }
}
