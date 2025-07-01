using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static T FindChild<T>(this GameObject parent, bool recursive = false, string name = null) where T : Component
    {
        if (recursive == false)
        {
            int childCount = parent.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = parent.transform.GetChild(i);
                if (child.TryGetComponent<T>(out T component) && (name == null || child.name == name))
                {
                    return component;
                }
            }
        }
        else
        {
            T[] childs = parent.GetComponentsInChildren<T>();
            foreach (T child in childs)
            {
                if (name == null || child.name == name)
                {
                    return child;
                }
            }
        }
        return null;
    }
}
