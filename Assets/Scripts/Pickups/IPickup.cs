using System;
using UnityEngine;

namespace Pickups
{
    public interface IPickup
    {
        public void Apply(GameObject consumerObject);//fires a static event to notify any consumers
    }

    public interface IPickupConsumer<in T> where T : IPickup
    {
        public void ApplyPickup(T pickup);
    }
}