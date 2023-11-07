using UnityEngine;

namespace Pickups
{
    public class ShieldPickup : MonoBehaviour, IPickup
    {
        public void Apply(GameObject consumerObject)
        {
            if (!consumerObject.TryGetComponent(out IPickupConsumer<ShieldPickup> pickupConsumer))
            {
                Debug.LogWarning($"No consumer for ShieldPickup found, you might have put it on the wrong object");
            }
            pickupConsumer.ApplyPickup(this);
        }
    }
}