
using UnityEngine;

using Invaders.Units;
using Invaders.GameModule;
using Invaders.GameSettings;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

namespace Invaders.GameState
{
    internal sealed class ActionHandler : BaseGameHandler
    {
        private ProjectileSetting[] _projectileSettingList;
        public override void ExecuteHandlerLogic(IState currentState)
        {
            if(_projectileSettingList is null)
            {
                _projectileSettingList = GameInstance.Instance.GetGameModule<GameResourcesModule>().GetItemsSettingList<ProjectileSetting>();
            }
            var convertState = ConvertStateToType<ActionState>(currentState);
            convertState.Deconstruct(out var stateParam);
            Vector3 startEuler = (stateParam.ownerType == ShipType.Player) ? Vector3.zero : Vector3.forward * 180f;
            ProjectileSetting projectileSetting = default;
            switch (stateParam.actionType)
            {
                case ActionType.SingleShoot:
                    CreateShoot(GetProjectilePrototypeByType(ProjectileType.Physics, stateParam.ownerType), stateParam.positon, startEuler);
                    break;
                case ActionType.DoubleShoot:
                    var offset = 0.5f;
                    projectileSetting = GetProjectilePrototypeByType(ProjectileType.Physics, stateParam.ownerType);
                    for (int i = -1; i < 2; i += 2)
                    {
                        CreateShoot(projectileSetting, stateParam.positon + (Vector3.left * offset * i), startEuler);
                    }
                    break;
                case ActionType.TripleShoot:
                    var eulerOffset = 30f;
                    projectileSetting = GetProjectilePrototypeByType(ProjectileType.Physics, stateParam.ownerType);
                    for (int i = -1; i < 2; ++i)
                    {
                        CreateShoot(projectileSetting, stateParam.positon, startEuler + (Vector3.forward * i * eulerOffset));
                    }
                    break;
                case ActionType.SmallLaser:
                    break;
                case ActionType.BigLaser:
                    break;
                default:
                    break;
            }
        }

        private void CreateShoot(ProjectileSetting projectileSetting, Vector3 positions, Vector3 euler)
        {
            var projectile = Game.CreateUnit<Projectile>(projectileSetting);
            projectile.SetPosition(positions);
            projectile.SetRotation(euler);
        }

        private ProjectileSetting GetProjectilePrototypeByType( ProjectileType projectileType , ShipType shiptype)
        {
            if(_projectileSettingList is null)
            {
                GameInstance.Instance.GetGameModule<GameResourcesModule>().GetItemsSettingList<ProjectileSetting>();
            }

            ProjectileSetting setting = default;

            for(int i = 0; i < _projectileSettingList.Length; ++i)
            {
                if(_projectileSettingList[i].projectileType == projectileType && _projectileSettingList[i].shipType == shiptype)
                {
                    setting = _projectileSettingList[i];
                    break;
                }
            }

            return setting;
        }
    }
}
