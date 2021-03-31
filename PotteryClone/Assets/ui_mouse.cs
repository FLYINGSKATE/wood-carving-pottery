using UnityEngine;
using System.Collections;
 
public class ui_mouse : MonoBehaviour {
 
//depending on source image size <<i.e Photoshop  Edit-->ImageSize>> you need to adjuts the center of the mouse.
   //public float centerX;
   //public float centerY;
 
   public Texture2D cursorTexture;
   public CursorMode cursorMode = CursorMode.Auto;
   public bool autoCenterHotSpot = false;
   public Vector2 hotSpotCustom = Vector2.zero;
   private Vector2 hotSpotAuto ;
   private Vector2 hotSpot;
   
   public Texture2D downArrowCursorTexture;
 
   void Start () {
     if ( autoCenterHotSpot) {
       hotSpotAuto =  new Vector2(cursorTexture.width*0.5f, 0f);
       hotSpot = hotSpotAuto;
 
     }
     else {hotSpot = hotSpotCustom;}
 
     //Cursor.SetCursor (cursorTexture, new Vector2( centerX,centerY) ,CursorMode.ForceSoftware);
     Cursor.SetCursor (cursorTexture, hotSpot ,CursorMode.ForceSoftware);
 
   }
   
   void OnMouseEnter(){
       Debug.Log("WE ENTERED");
       
       Cursor.SetCursor (downArrowCursorTexture, hotSpot ,CursorMode.ForceSoftware);
       //ignore collision and remove cursor icon
       //Instantiate a mouse cursor at the previous point
   }

   void OnMouseExit(){
       Debug.Log("WE EXITED");
       Cursor.SetCursor (cursorTexture, hotSpot ,CursorMode.ForceSoftware);

       //Get collision again
       //Set mouse cursor again

   }

}