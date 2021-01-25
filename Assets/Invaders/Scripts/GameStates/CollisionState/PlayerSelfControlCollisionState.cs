using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Invaders.GameState
{
    internal sealed class PlayerSelfControlCollisionState : PhysicCollisionState
    {
        protected override float checkDistance => 0.75f;

        protected override Vector3 GetPhysicDirection()
        {
            return Vector3.zero;
        }

        protected override bool EndState()
        {
            return false;
        }

        protected override void ExtendedStateComplite()
        {
            
        }
    }
}
