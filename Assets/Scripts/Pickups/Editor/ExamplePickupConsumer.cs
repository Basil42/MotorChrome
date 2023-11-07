using System;
using System.Drawing.Design;
using UnityEngine;

namespace Pickups.Editor
{
    //example class for reference do not use in build
    public class ExamplePickupConsumer : MonoBehaviour , IPickupConsumer<ExamplePickup>
    {
        public void ApplyPickup(ExamplePickup pickup)
        {
            //implement effect here
        }
    }
}