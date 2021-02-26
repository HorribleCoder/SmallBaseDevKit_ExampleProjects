using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Characters
{
    internal sealed class CharacterData
    {
        internal CharacterMovementType movementType = CharacterMovementType.Walk;
        internal float characterMovementSpeed;


        internal void ResetData()
        {
            movementType = CharacterMovementType.Walk;
            characterMovementSpeed = 0f;
        }
    }
}
