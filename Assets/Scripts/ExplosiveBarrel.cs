using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class ExplosiveBarrel : MonoBehaviour
{
    static readonly int shaderPropertyColor = Shader.PropertyToID("_BaseColor");

    [SerializeField] [Range(1,8)] float radius; //1
    [SerializeField] float damage; //10
    [SerializeField] Color color; //red
    [SerializeField] MeshRenderer meshRenderer;
    
    MaterialPropertyBlock mpb;
    MaterialPropertyBlock Mpb
    {
        get
        {
            if (mpb == null)
            {
                mpb = new MaterialPropertyBlock();
            }
            return mpb;
        }
    }

    void ApplyColor()
    {
        Mpb.SetColor(shaderPropertyColor, color);
        meshRenderer.SetPropertyBlock(Mpb);
    }
    
    //Called on property change
    void OnValidate()
    {
        ApplyColor();
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(transform.position, radius);
        Handles.DrawWireDisc(transform.position, transform.up, radius);
    }
#endif

    void OnEnable()
    {
        ApplyColor();
        ExplosiveBarrelManager.allTheBarrels.Add(this);
    }

    void OnDisable()
    {
        ExplosiveBarrelManager.allTheBarrels.Remove(this);
    }
}
