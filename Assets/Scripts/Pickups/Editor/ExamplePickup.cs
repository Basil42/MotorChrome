using System;
using UnityEngine;

namespace Pickups.Editor
{
    //example class for reference do not use in build
    public class ExamplePickup : MonoBehaviour, IPickup
    {
        //Add any data payload you might need here as public fields
        public void Apply(GameObject consumerGo)
        {
            if (TryGetComponent(out IPickupConsumer<ExamplePickup> pickupConsumer)) 
                Debug.LogWarning($"No consumer for ExamplePickup found, you might have put it on the wrong object");
            
            pickupConsumer.ApplyPickup(this);
            
        }
    }
}