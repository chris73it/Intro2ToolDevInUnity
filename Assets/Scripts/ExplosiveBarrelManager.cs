using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class ExplosiveBarrelManager : MonoBehaviour
{
    public static List<ExplosiveBarrel> allTheBarrels = new();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.zTest = CompareFunction.Less;
        foreach(var barrel in allTheBarrels)
        {
            float halfheight = (transform.position.y - barrel.transform.position.y) * 0.5f;
            Vector3 offset = Vector3.up * halfheight;
            Handles.DrawBezier(transform.position,
                barrel.transform.position,
                transform.position - offset,
                barrel.transform.position + offset,
                Color.white,
                EditorGUIUtility.whiteTexture,
                1f);
        }
    }
#endif
}
