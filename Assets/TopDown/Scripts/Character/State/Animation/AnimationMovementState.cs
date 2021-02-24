namespace TD.Chacters.State
{
    internal abstract class AnimationMovementState : AnimationState<float>
    {
        protected override string AnimationKeyName { get => "MoveSpeed"; }
    }
}
