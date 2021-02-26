using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.USH.State;
using SmallBaseDevKit.GameException;

using TD.Characters.Handler;

namespace TD.Characters.State
{
    [RequiredHandler(typeof(AnimationHandler))]
    internal abstract class AnimationState<T> : BaseUnitState<(Animator ownerAnimator, string keyName, T value)>
    {
        private Animator _ownerAnimator;
        protected abstract string AnimationKeyName { get; }
        protected abstract T AnimationValue { get;}
        public override void Deconstruct(out (Animator ownerAnimator, string keyName, T value) stateParam)
        {
            stateParam.ownerAnimator = _ownerAnimator;
            stateParam.keyName = AnimationKeyName;
            stateParam.value = AnimationValue;
        }

        protected override bool EndState()
        {
            return true;
        }

        protected override void ExtendedSetupState()
        {
            try
            {
                owner.TryGetUnitComponent(out _ownerAnimator);
                if(_ownerAnimator is null)
                {
                    throw new NullReferenceException();
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"In unit - {owner.GetType().Name} don't have component Aniamtor");
            }
        }

        protected override void ExtendedStateComplite()
        {

        }
    }
}
