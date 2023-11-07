using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{
   public static ObjectPool instance;

   private List<GameObject> pooledObjects = new List<GameObject>();
   private int amountToPool = 20;
   public GameObject floorPrefab;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      for (int i = 0; i < amountToPool; i++)
      {
         GameObject obj = Instantiate(floorPrefab);
         obj.SetActive(false);
         pooledObjects.Add(obj);
      }
   }

   // ReSharper disable Unity.PerformanceAnalysis
   public GameObject GetPooledObject()
   {
      for (int i = 0; i < pooledObjects.Count; i++)
      {
         if (!pooledObjects[i].activeInHierarchy)
         {
            return pooledObjects[i];
         }
      }
      Debug.LogWarning("need more objects in the pool");

      return null;
   }


}
