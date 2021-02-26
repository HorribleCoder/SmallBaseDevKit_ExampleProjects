namespace TD.Characters.State
{
    internal abstract class AnimationMovementState : AnimationState<float>
    {
        protected override string AnimationKeyName { get => "MoveSpeed"; }
    }
}
