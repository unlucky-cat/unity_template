using UnityEngine;
using System.Collections;
using System;
using Assets.Code.Common;
using Assets.Code.Common.Extensions;
using Assets.Code.Components.InputReceivers;

namespace Assets.Code.Components
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(BaseInputReceiver))]
    public class MovingController : MonoBehaviour
    {

        // internal types
        public enum MovementState { Moving, Standing };
        public enum FacingState { None, Left, Right, Direct, Back };

        // constants
        private const float boxCastingAngle = 0;

        // private variables
        private Animator animator;
        private BoxCollider2D boxCollider;
        private BaseInputReceiver inputReceiver;
        //private bool isRunning = false;
        private Vector2 lastStep;

        private MovementState movementState;
        private FacingState facingState;


        // UI variables
        [SerializeField]
        private float speed = 6.0f;
        [SerializeField]
        private float raycastDistance = 0.6f;
        [SerializeField]
        private LayerMask wallsMask;

        public Vector3 Speed { get { return lastStep; } }
        //public bool IsBlocked { get; set; } 

        public event EventHandler<GameObjectEventArgs> AfterWallHit;

        void Awake()
        {
            animator = this.GetComponent<Animator>();
            boxCollider = this.GetComponent<BoxCollider2D>();
            inputReceiver = this.GetComponent<BaseInputReceiver>();
            //IsBlocked = false;
        }

        // Use this for initialization
        void Start()
        {
            movementState = MovementState.Standing;
            facingState = FacingState.Direct;

            inputReceiver.MoveInputReceived += InputReceiver_MoveInputReceived;
        }

        private void InputReceiver_MoveInputReceived(object sender, Vector2EventArgs e)
        {
            //if (!IsBlocked)
            {
                //isRunning = !(e.Vector2 == Vector2.zero);
                Move(e.Vector2);
            }
        }

        private void Move(Vector2 dV)
        {

            // in order to implement sliding along the walls we need to split one diaginal
            // movement into two independent X and Y projections and handle them separately.
            // So, in case of pressing two keys against the wall, one projction will be
            // blocked by collision detection but the other will "survive" and successfully
            // move the character along the wall

            if (Mathf.Abs(dV.x) > 0 && Mathf.Abs(dV.y) > 0)
            {
                InternalMove(new Vector2(dV.x, 0));
                InternalMove(new Vector2(0, dV.y));
            }
            else InternalMove(dV);
        }

        protected virtual void OnAfterWallHit(GameObjectEventArgs e)
        {
            if (AfterWallHit != null) AfterWallHit(this, e);
        }

        private void InternalMove(Vector2 dV)
        {
            dV = dV * speed;
            dV = dV.ApplyFixedDeltaTime();

            lastStep = dV;

            //var newPosition = (Vector2)boxCollider.transform.position + dV;
            var newPosition = (Vector2)transform.TransformPoint(boxCollider.offset) + dV;
            var newFacingState = dV.ToFacingState();

            var wallHit = Physics2D.BoxCast(newPosition, boxCollider.size, boxCastingAngle, newFacingState.ToVector2(), raycastDistance, wallsMask);
            //var hit = Physics2D.CircleCast(newPosition, circleRadius, newFacingState.ToVector2(), raycastDistance, wallsMask);
            //var hit = Physics2D.Raycast(newPosition, newFacingState.ToVector2(), raycastDistance, wallsMask);

            var hitCaster = GetComponent<HitCaster>();
            if (hitCaster != null)
            {
                hitCaster.CastHitIfNeeded(newFacingState.ToVector2());
            }

            // no wall ahead
            if (wallHit.collider == null)
            {
                transform.Translate(dV);
                facingState = newFacingState;

                //Debug.Log("facingState");
                if (animator.runtimeAnimatorController != null)
                    animator.SetInteger("facingState", (int)facingState);

                // why this event is triggering here?
                OnAfterWallHit(new GameObjectEventArgs(gameObject));
            }
        }
    }
}