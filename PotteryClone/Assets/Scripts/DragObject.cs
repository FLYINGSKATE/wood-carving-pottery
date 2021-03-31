using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    public SkinnedMeshRenderer skinedRenderer;
    public int blendShapeIndex;

    private Vector3 mOffset;
    private float mZCoord;



    /*void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = GetMouseAsWorldPoint();
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    void OnMouseUp(){
        gameObject.GetComponent<ParticleSystem>().Stop();
    }*/

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void Update(){
        Debug.Log("vodie Update");
        
    }

    /*void OnMouseDrag()
    {
        float x = Vector3.Distance(GetMouseAsWorldPoint(), transform.position);
        float y = Vector3.Distance(mOffset, transform.position);

        float w = skinedRenderer.GetBlendShapeWeight(blendShapeIndex);

        if (x > y)
        {
            skinedRenderer.SetBlendShapeWeight(blendShapeIndex, Mathf.Clamp(w - 1f, 0, 100));
        }
        else if (x < y)
        {
            skinedRenderer.SetBlendShapeWeight(blendShapeIndex, Mathf.Clamp(w + 1, 0, 100));
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Chisel")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            //Shed the skin and enable particle collider here maybe
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<ParticleSystem>().Play();
        }

    }

    void OnCollisionStay(Collision collision){
        if(collision.gameObject.name=="Chisel"){
            Debug.Log("Do something here on collision");
            float w = skinedRenderer.GetBlendShapeWeight(blendShapeIndex);
            skinedRenderer.SetBlendShapeWeight(blendShapeIndex, Mathf.Clamp(w + 0.5f, 0, 100));
        }
    }

    void OnCollisionExit(Collision collision){
        Debug.Log("WE HAVE EXITED");
        if (collision.gameObject.name == "Chisel")
        {
            Debug.Log("CHISEL HAVE EXITED");
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }

}