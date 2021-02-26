using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;

using TD.Setting;
using TD.GameModules;

namespace TD.Characters
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    internal abstract class BaseCharacter : BaseUnitWithData<CharacterSetting>
    {
        protected GameObject characterVisula;

        protected override void ExtendedSetupUnit()
        {
            this.ReadUnitData<CharacterSetting>(out var data);
            characterVisula = Game.CreateNewObject<GameObject>(data.characterPrototype);
            ComponentHandler.SetupComponentHandler(this, characterVisula);
        }

        internal void SetPosition(Vector3 position)
        {
            characterVisula.transform.position = position;
            ComponentHandler.DebugView();
        }
    }
}
