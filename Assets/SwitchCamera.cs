using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public Camera gameCamera;
    public Camera storeCamera;
    public Canvas canvasController, canvasUI, canvasStore;

    private void Start()
    {
        canvasStore.enabled = false;
        storeCamera.enabled = false;
    }

    public void ShowStoreView()
    {
        gameCamera.enabled = false;
        storeCamera.enabled = true;

        canvasStore.enabled = true;
        canvasController.enabled = false;
        canvasUI.enabled = false;

    }

    public void ShowGameView()
    {
        gameCamera.enabled = true;
        storeCamera.enabled = false;
        
        canvasStore.enabled = false;
        canvasController.enabled = true;
        canvasUI.enabled = true;

    }
}
