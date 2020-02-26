using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class BLight : MonoBehaviour
    {
        public List<Light> myLights;
        public List<Light> otherLights;

        public void AddLight(Light light)
        {
            otherLights.Add(light);
            foreach (Light item in myLights)
            {
                item.gameObject.SetActive(false);
            }
        }

        public void RemoveLight(Light light)
        {
            otherLights.Remove(light);
            if (otherLights.Count == 0)
                foreach (Light item in myLights)
                {
                    item.gameObject.SetActive(true);
                }
        }
    }
}