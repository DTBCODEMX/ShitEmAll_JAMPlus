using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;


/// <summary>
/// TODO_DESCRIPTION
/// </summary>
[AddComponentMenu("Corgi Engine/Character/Abilities/Vertical movement")]
public class CharacterVerticlaMovement : CharacterAbility
{
    /// This method is only used to display a helpbox text
    /// at the beginning of the ability's inspector
    public override string HelpBoxText()
    {
        return "Helps with vertical movement.";
    }

    [Header("vertical speed")]
    /// declare your parameters here
    public float vertical_speed = 4f;

    // Animation parameters
    protected const string _todoParameterName = "TODO";
    protected int _todoAnimationParameter;

    /// <summary>
    /// Here you should initialize our parameters
    /// </summary>
    protected override void Initialization()
    {
        base.Initialization();
    }

    /// <summary>
    /// Every frame, we check if we're crouched and if we still should be
    /// </summary>
    public override void ProcessAbility()
    {
        base.ProcessAbility();
    }

    /// <summary>
    /// Called at the start of the ability's cycle, this is where you'll check for input
    /// </summary>
    protected override void HandleInput()
    {
        // here as an example we check if we're pressing down
        // on our main stick/direction pad/keyboard
        ///_inputManager.MovementControl. 
        if (_inputManager.PrimaryMovement.y < -_inputManager.Threshold.y)
        {
            DoSomething();
        }
    }

    /// <summary>
    /// If we're pressing down, we check for a few conditions to see if we can perform our action
    /// </summary>
    protected virtual void DoSomething()
    {
        // if the ability is not permitted
        if (!AbilityPermitted
            // or if we're not in our normal stance
            || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal)
            // or if we're grounded
            || (!_controller.State.IsGrounded)
            // or if we're gripping
            || (_movement.CurrentState == CharacterStates.MovementStates.Gripping))
        {
            // we do nothing and exit
            return;
        }

        // if we're still here, we display a text log in the console
    //    MMDebug.DebugLogTime("We're doing something yay!");
    }

    /// <summary>
    /// Adds required animator parameters to the animator parameters list if they exist
    /// </summary>
    protected override void InitializeAnimatorParameters()
    {
        RegisterAnimatorParameter(_todoParameterName, AnimatorControllerParameterType.Bool,
            out _todoAnimationParameter);
    }

    /// <summary>
    /// At the end of the ability's cycle,
    /// we send our current crouching and crawling states to the animator
    /// </summary>
    public override void UpdateAnimator()
    {
   //     MMAnimatorExtensions.UpdateAnimatorBool(_animator, _todoAnimationParameter,
    //        (_movement.CurrentState == CharacterStates.MovementStates.Crouching), _character._animatorParameters);
    }
}
