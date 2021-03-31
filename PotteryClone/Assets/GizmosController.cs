using UnityEngine;
using System.Collections;
 
 [RequireComponent(typeof(MeshCollider))]
 
 public class GizmosController : MonoBehaviour 
 {
 
 private Vector3 screenPoint;
 private Vector3 offset;

 //Restriction Position
 public float yMin,yMax;

 
 void OnMouseDown()
 {
     screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
 
     offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 
 }
 
 void OnMouseDrag()
 {
     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
 
     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
     Debug.Log(curPosition.y);
     curPosition = new Vector3(curPosition.x,Mathf.Clamp(curPosition.y, yMin, yMax),transform.position.z);
     transform.position = curPosition;
 
 }
 
 }