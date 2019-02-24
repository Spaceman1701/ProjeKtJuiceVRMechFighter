using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.XR;
using UnityEngine.Rendering;

public class WindowRenderer : MonoBehaviour
{

    public Camera eyeCamera; //so we can get updates right before the eye renders
    public Camera leftCamera;
    public Camera rightCamera;

    public Material windowMaterial;

    // Start is called before the first frame update
    void Start()
    {
        RenderPipeline.beginCameraRendering += OnBeforeCameraRender;

        RenderTexture leftEyeTex = createEyeTexture();
        leftCamera.targetTexture = leftEyeTex;

        RenderTexture rightEyeTex = createEyeTexture();
        rightCamera.targetTexture = rightEyeTex;

        windowMaterial.SetTexture("_LeftEye", leftEyeTex);
        windowMaterial.SetTexture("_RightEye", rightEyeTex);
    }

    private RenderTexture createEyeTexture() {
        RenderTexture eyeTex = new RenderTexture(XRSettings.eyeTextureDesc);
        eyeTex.dimension = TextureDimension.Tex2D;
        eyeTex.volumeDepth = 1;
        eyeTex.antiAliasing = 2;
        return eyeTex;
    }

    private void RenderWindow() {
        UpdateLocationAndProjection();
        leftCamera.Render();
        rightCamera.Render();
    }

    private void UpdateLocationAndProjection() {
        leftCamera.projectionMatrix = eyeCamera.GetStereoNonJitteredProjectionMatrix(Camera.StereoscopicEye.Left);
        rightCamera.projectionMatrix = eyeCamera.GetStereoNonJitteredProjectionMatrix(Camera.StereoscopicEye.Right);

        Vector3 leftEyePosition = Vector3.zero;
        Vector3 rightEyePosition = Vector3.zero;
        Quaternion leftEyeRotation = Quaternion.identity;
        Quaternion rightEyeRotation = Quaternion.identity;

        if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.LeftEye, NodeStatePropertyType.Position, OVRPlugin.Node.EyeLeft, OVRPlugin.Step.Render, out leftEyePosition))
            leftCamera.transform.localPosition = leftEyePosition;
        if (OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.RightEye, NodeStatePropertyType.Position, OVRPlugin.Node.EyeRight, OVRPlugin.Step.Render, out rightEyePosition))
            rightCamera.transform.localPosition = rightEyePosition;
        if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.LeftEye, NodeStatePropertyType.Orientation, OVRPlugin.Node.EyeLeft, OVRPlugin.Step.Render, out leftEyeRotation))
            leftCamera.transform.localRotation = leftEyeRotation;
        if (OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.RightEye, NodeStatePropertyType.Orientation, OVRPlugin.Node.EyeRight, OVRPlugin.Step.Render, out rightEyeRotation))
            rightCamera.transform.localRotation = rightEyeRotation;
    }


    void OnBeforeCameraRender(Camera cam) {
        if (cam == eyeCamera) {
            RenderWindow();
        }
    }
}
