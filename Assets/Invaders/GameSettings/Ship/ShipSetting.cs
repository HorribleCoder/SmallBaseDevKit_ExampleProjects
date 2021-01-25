namespace Invaders.GameSettings
{
    internal abstract class ShipSetting : BaseGameItemSetting
    {
        public ShipType shipType = ShipType.None;
        public float horizontalSpeed;
        public float verticalSpeed;
    }
}
