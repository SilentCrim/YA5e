using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class SelectedFlash : MonoBehaviour
{

    public GameObject selectedObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;
    public Color32 defaultColor;

    void Update() {
        if (lookingAtObject == true) {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }

    void OnMouseOver() {
        Debug.Log(CastingToObject.selectedObject);
        if (CastingToObject.selectedObject == null) {
            CastingToObject.selectedObject = name;
        }
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if (startedFlashing == false) {
            startedFlashing = true;
            defaultColor = selectedObject.GetComponent<Renderer>().material.color;
            StartCoroutine(FlashObject());
        }
    }

    private void OnMouseExit() {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = defaultColor;
    }

    IEnumerator FlashObject() {
        while (lookingAtObject==true) {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn == true) {
                if (blueCol <= 30) {
                    flashingIn = false;
                }
                else {
                    blueCol -= 25;
                    greenCol -= 1;
                }
            }

            if (flashingIn == false) {
                if (blueCol >= 250) {
                    flashingIn = true;
                }
                else {
                    blueCol += 25;
                    greenCol += 1;
                }
            }
        }
    }
}