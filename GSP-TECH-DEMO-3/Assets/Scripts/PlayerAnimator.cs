using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int currentState;

    private float lockedTill;

    private bool isFacingUp;
    public bool isAttacking;
    public bool isCasting;
    public float castDuration;
    public bool isCat;

    //Human
    private static readonly int Idle = Animator.StringToHash("anim-die");
    private static readonly int CastDown = Animator.StringToHash("anim-cast-1");
    private static readonly int CastUp = Animator.StringToHash("anim-cast-2");
    private static readonly int SwingDown = Animator.StringToHash("anim-swing-1");
    private static readonly int SwingUp = Animator.StringToHash("anim-swing-2");
    private static readonly int WalkDown = Animator.StringToHash("anim-walk-1");
    private static readonly int WalkUp = Animator.StringToHash("anim-walk-2");

    //Cat
    private static readonly int CatIdle = Animator.StringToHash("anim-cat-idle");
    private static readonly int CatSwingDown = Animator.StringToHash("anim-cat-swing-down");
    private static readonly int CatSwingUp = Animator.StringToHash("anim-cat-swing=up");
    private static readonly int CatWalkUp = Animator.StringToHash("anim-cat-walk-down");
    private static readonly int CatWalkDown = Animator.StringToHash("anim-cat-walk-up");

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() => UpdateState();

    private void UpdateState()
    {
        if (playerMovement.moveDirection.x > 0) { spriteRenderer.flipX = false; }
        if (playerMovement.moveDirection.x < 0) { spriteRenderer.flipX = true; }

        //spriteRenderer.flipX = (playerMovement.moveDirection.x > 0) ? false : true;

        int animState = GetState();

        isCasting = false;
        isAttacking = false;
        castDuration = 0;

        if (animState == currentState) { return; }
        animator.CrossFade(animState, 0);
        currentState = animState;
    }

    private int GetState()
    {
        if (Time.time < lockedTill) { return currentState; }

        int returnState = isCat ? CatStates() : HumanStates(); 
        return returnState;
        
    }


    private int CatStates()
    {
        if (isFacingUp == true && isCasting) { return LockState(CatSwingUp, 0.25f); }
        if (isFacingUp == false && isCasting) { return LockState(CatSwingDown, 0.25f); }

        if (isFacingUp == true && isAttacking) { return LockState(CatSwingUp, 0.25f); }
        if (isFacingUp == false && isAttacking) { return LockState(CatSwingDown, 0.25f); }

        if (playerMovement.moveDirection.y > 0) { isFacingUp = true; return CatWalkDown; }
        if (playerMovement.moveDirection.y < 0) { isFacingUp = false; return CatWalkUp; }
        return CatIdle;
    }

    private int HumanStates()
    {
        if (isFacingUp == true && isCasting) { return LockState(CastUp, castDuration); }
        if (isFacingUp == false && isCasting) { return LockState(CastDown, castDuration); }

        if (isFacingUp == true && isAttacking) { return LockState(SwingUp, 0.25f); }
        if (isFacingUp == false && isAttacking) { return LockState(SwingDown, 0.25f); }

        if (playerMovement.moveDirection.y > 0) { isFacingUp = true; return WalkUp; }
        if (playerMovement.moveDirection.y < 0) { isFacingUp = false; return WalkDown; }
        return Idle;
    }

    int LockState(int s, float t)
    {
        lockedTill = Time.time + t;
        return s;
    }
}
