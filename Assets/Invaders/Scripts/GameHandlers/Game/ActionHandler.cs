using System;
using UnityEngine;

using Invaders.Units;
using Invaders.GameModule;
using Invaders.GameSettings;

using SmallBaseDevKit;
using SmallBaseDevKit.GameException;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

namespace Invaders.GameState
{
    internal sealed class ActionHandler : BaseGameHandler
    {
        private ProjectileSetting[] _projectileSettingList;
        public override void ExecuteHandlerLogic(IState currentState)
        {
            var convertState = currentState.ConvertTo<ActionState>();
            convertState.Deconstruct(out var stateParam);
            Vector3 startEuler = (stateParam.ownerType == ShipType.Player) ? Vector3.zero : Vector3.forward * 180f;
            stateParam.positon = (stateParam.ownerType == ShipType.Player) ? stateParam.positon : stateParam.positon + Vector3.forward * 5f;
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

        protected override void SetupHandlerOnCreate()
        {
            _projectileSettingList = GameInstance.Instance.GetGameModule<GameResourcesModule>().GetItemsSettingList<ProjectileSetting>();
        }

        private void CreateShoot(ProjectileSetting projectileSetting, Vector3 positions, Vector3 euler)
        {
            Projectile projectile;
            if(projectileSetting.shipType == ShipType.Player)
            {
                projectile = Game.CreateUnit<PlayerProjectile, ProjectileSetting>(projectileSetting);
            }
            else
            {
                projectile = Game.CreateUnit<EnemyProjectile, ProjectileSetting>(projectileSetting);
            }
            
            projectile.SetPosition(positions);
            projectile.SetRotation(euler);
        }

        private ProjectileSetting GetProjectilePrototypeByType( ProjectileType projectileType , ShipType shipType)
        {
            if(_projectileSettingList is null)
            {
                GameInstance.Instance.GetGameModule<GameResourcesModule>().GetItemsSettingList<ProjectileSetting>();
            }

            ProjectileSetting setting = default;
            try
            {
                for (int i = 0; i < _projectileSettingList.Length; ++i)
                {
                    if (_projectileSettingList[i].projectileType == projectileType && _projectileSettingList[i].shipType == shipType)
                    {
                        setting = _projectileSettingList[i];
                        break;
                    }
                }
                if(setting == default)
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"In Game Resources not have Projectile Setting - <b>{shipType}</b> by type <b>{projectileType}</b>");
            }
            return setting;
        }
    }
}
