using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CastingToObject : MonoBehaviour
{
   
    #region Variables
 
    public static string selectedObject;
    public static string internalObject;
    public RaycastHit theObject;
 
    #endregion
 
   
    void Update()
    {
        // Debug.Log(transform);
        // Debug.Log(transform.position);
        // Debug.Log(transform.TransformDirection(Vector3.forward));
        // We need to actually hit an object
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObject))
        {
            Debug.Log(theObject);
            Debug.Log(theObject.transform);
            Debug.Log(theObject.transform.gameObject);
            Debug.Log(theObject.transform.gameObject.name);
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;
        }
    }
}