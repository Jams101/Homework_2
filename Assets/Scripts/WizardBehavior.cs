// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file
//   Performs frame-rate indpendent movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehavior : MonoBehaviour
{
    // A designer-specified, arbitrary movement rate.
    // Set via Unity IDE in WizardBehavior component
    // of GameObject to which this script is attached.

    [Tooltip("Frame-rate independent movement")]
    public float MoveRate = 5.0f;

    [Tooltip("Player-relative ortho camera")]
    public GameObject playerCamera;

    [Tooltip("The X movement of this wizard, updated per frame")]
    public float moveX;

    Animator wizardAnim;
    SpriteRenderer wizardSprite;

    int runTrigger = Animator.StringToHash("isRunning");
    int idleTrigger = Animator.StringToHash("isIdling");
    int attackTrigger = Animator.StringToHash("isAttacking");
    int attackType = Animator.StringToHash("attackType");

    int idle = Animator.StringToHash("Base Layer.WizardIdle");
    int run = Animator.StringToHash("Base Layer.WizardRun");

    // Start is called before the first frame update
    void Start()
    {
        wizardAnim = GetComponent<Animator>();
        wizardSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // input from up/down, left/right keys
        moveX = Input.GetAxisRaw("Horizontal");

        // set the state of the controller
        AnimatorStateInfo state = wizardAnim.GetCurrentAnimatorStateInfo(0);

        // the wizard is moving forward or backward
        if (moveX != 0.0f)
        {
            if (state.fullPathHash != run)
                wizardAnim.SetTrigger(runTrigger);
        }
        // the wizard is standing still, idling
        else
        {
            if (state.fullPathHash != idle)
                wizardAnim.SetTrigger(idleTrigger);
        }

        if (moveX > 0.0f)
        {
            wizardSprite.flipX = false;
        }
        else if (moveX < 0.0f)
        {
            wizardSprite.flipX = true;
        }

        /*
        bool isAttacking = Input.GetKeyDown(KeyCode.Space);
        if (isAttacking)
        {
            int attackSelected = Random.Range(0, 2);

            Debug.Log(attackSelected);

            wizardAnim.SetInteger(attackType, attackSelected);
            wizardAnim.SetTrigger(attackTrigger);
        }
        */
    }
}