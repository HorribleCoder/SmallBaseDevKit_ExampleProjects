using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.GameException;


using Invaders.GameSettings;
using Invaders.GameModule;

namespace Invaders.Units
{
    [RequireComponent(typeof(Rigidbody))]
    internal abstract class BaseGameUnit<T> : BaseUnit<T>
        where T: BaseGameItemSetting
    {
        protected GameObject characterVisual;

        internal virtual void SetPosition(Vector3 position)
        {
            position -= Vector3.forward * position.z;
            characterVisual.transform.position = position;
            componentHandler.GetComponent<Rigidbody>().position = position;
        }

        internal virtual void SetRotation(Vector3 euler)
        {
            characterVisual.transform.rotation = Quaternion.Euler(euler);
            componentHandler.GetComponent<Rigidbody>().rotation = Quaternion.Euler(euler);
        }

        protected override void ExtendedDestroyUnit()
        {
            GameInstance.Instance.GetGameModule<VisualModule>().ReturnCharacterVisual(characterVisual);
        }

        protected override void ExtendedSetupUnit(T unitData)
        {
            characterVisual = GameInstance.Instance.GetGameModule<VisualModule>().GetCharacterVisual(unitData.ItemPrefab);
            componentHandler.SetupComponentHandler(this, characterVisual);

            try
            {
                var rb = componentHandler.GetComponent<Rigidbody>();
                if(rb is null)
                {
                    throw new System.Exception();
                }

                rb.useGravity = false;
                rb.freezeRotation = true;
            }
            catch(System.Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"Character - {GetType().Name}, don't have Rigidbody compoennt");
            }
        }
    }
}

