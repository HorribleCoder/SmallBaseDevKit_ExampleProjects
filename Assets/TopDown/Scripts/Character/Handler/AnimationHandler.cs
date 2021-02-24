using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using TD.Chacters.State;

namespace TD.Chacters.Handler
{
    internal sealed class AnimationHandler : BaseGameHandler
    {
        private Animator _currentUsedAnimator;
        public override void ExecuteHandlerLogic(IState currentState)
        {
            if(currentState is AnimationMovementState)
            {
                currentState.ConvertTo<AnimationMovementState>().Deconstruct(out var stateParam);
                _currentUsedAnimator = stateParam.ownerAnimator;
                PlayAnimation(stateParam.keyName, stateParam.value);
            }
            _currentUsedAnimator = null;
        }

        protected override void SetupHandlerOnCreate()
        {

        }

        private void PlayAnimation(string animationName)
        {
            _currentUsedAnimator.SetTrigger(animationName);
        }

        private void PlayAnimation(string animationName, float value)
        {
            _currentUsedAnimator.SetFloat(animationName, value);
        }

        private void PlayAnimation(string animationName, int value)
        {
            _currentUsedAnimator.SetInteger(animationName, value);
        }

        private void PlayAnimation(string animationName, bool value)
        {
            _currentUsedAnimator.SetBool(animationName, value);
        }
    }
}
