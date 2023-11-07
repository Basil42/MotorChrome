using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ED_ObjectPool : MonoBehaviour
{
   public static ED_ObjectPool instance;

   private List<GameObject> pooledObjects = new List<GameObject>();
   private int amountToPool = 20;
   public GameObject ed_floorPrefab;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      for (int i = 0; i < amountToPool; i++)
      {
         GameObject obj = Instantiate(ed_floorPrefab);
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
