 using System;
 using UnityEngine;
 using UnityEngine.Rendering;

 [RequireComponent(typeof(Camera))]
 public class DisableFogOnCamera : MonoBehaviour
 {
     private Camera thisCamera;

     private void Awake()
     {
         thisCamera = GetComponent<Camera>();
     }

     private void OnEnable()
     {
         RenderPipelineManager.beginCameraRendering += A;
         RenderPipelineManager.endCameraRendering += B;
     }

     private void B(ScriptableRenderContext arg1, Camera cam)
     {
         if (thisCamera == cam)
         {
             RenderSettings.fog = true;
         }
     }

     private void A(ScriptableRenderContext arg1, Camera cam)
     {
         if (thisCamera == cam)
         {
             RenderSettings.fog = false;
         }
     }
 }