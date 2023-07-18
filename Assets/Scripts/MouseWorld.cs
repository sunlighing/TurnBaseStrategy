using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    [SerializeField] private LayerMask mousePlaneLayerMask;
   /// <summary>
   /// Update is called every frame, if the MonoBehaviour is enabled.
   /// </summary>
   private void Update()
   {
        transform.position = MouseWorld.GetPosition();
   }

   public static Vector3 GetPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }
}
