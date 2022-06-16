using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;
    public GameObject RTSCameraRig;
    public GameObject RTSYawNode;
    public GameObject RTSPitchNode;
    public GameObject RTSRollNode;

    public GameObject TPCameraRig;
    public GameObject TPYawNode;
    public GameObject TPPitchNode;
    public GameObject TPRollNode;

    public float cameraMoveSpeed = 100.0f;
    public float cameraRotateSpeed = 10.0f;
    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 currentPitchEulerAngles = Vector3.zero;
    private int CamVal = 1;

    // Start is called before the first frame update
    void Start()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CamVal)
        {
            case (2):
                TPCameraRig.SetActive(true);
                RTSCameraRig.SetActive(false);
                break;
            case (1):
                TPCameraRig.SetActive(false);
                RTSCameraRig.SetActive(true);
                break;
            default:
                TPCameraRig.SetActive(false);
                RTSCameraRig.SetActive(true);
                break;
        }
        CamInput();
    }

    void CamInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(CamVal >= 3)
            {
                CamVal = 1;
            }
            else
            {
                CamVal++;
            }
        }

        if (CamVal == 1)
        {
            if (Input.GetKey(KeyCode.W))
                RTSYawNode.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
            if (Input.GetKey(KeyCode.S))
                RTSYawNode.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);

            if (Input.GetKey(KeyCode.A))
                RTSYawNode.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
            if (Input.GetKey(KeyCode.D))
                RTSYawNode.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);

            if (Input.GetKey(KeyCode.R))
                RTSYawNode.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);
            if (Input.GetKey(KeyCode.F))
                RTSYawNode.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);

            currentYawEulerAngles = RTSYawNode.transform.localEulerAngles;
            if (Input.GetKey(KeyCode.Q))
                currentYawEulerAngles.y -= cameraRotateSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.E))
                currentYawEulerAngles.y += cameraRotateSpeed * Time.deltaTime;
            RTSYawNode.transform.localEulerAngles = currentYawEulerAngles;

            currentPitchEulerAngles = RTSPitchNode.transform.localEulerAngles;
            if (Input.GetKey(KeyCode.Z))
                currentPitchEulerAngles.x -= cameraRotateSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.X))
                currentPitchEulerAngles.x += cameraRotateSpeed * Time.deltaTime;
            RTSPitchNode.transform.localEulerAngles = currentPitchEulerAngles;
        }

        if (CamVal == 2)
        {
            if (Input.GetKey(KeyCode.W))
                TPYawNode.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
            if (Input.GetKey(KeyCode.S))
                TPYawNode.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);

            if (Input.GetKey(KeyCode.A))
                TPYawNode.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
            if (Input.GetKey(KeyCode.D))
                TPYawNode.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);

            if (Input.GetKey(KeyCode.R))
                TPYawNode.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);
            if (Input.GetKey(KeyCode.F))
                TPYawNode.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);

            currentYawEulerAngles = TPYawNode.transform.localEulerAngles;
            if (Input.GetKey(KeyCode.Q))
                currentYawEulerAngles.y -= cameraRotateSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.E))
                currentYawEulerAngles.y += cameraRotateSpeed * Time.deltaTime;
            TPYawNode.transform.localEulerAngles = currentYawEulerAngles;

            currentPitchEulerAngles = TPPitchNode.transform.localEulerAngles;
            if (Input.GetKey(KeyCode.Z))
                currentPitchEulerAngles.x -= cameraRotateSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.X))
                currentPitchEulerAngles.x += cameraRotateSpeed * Time.deltaTime;
            TPPitchNode.transform.localEulerAngles = currentPitchEulerAngles;
        }
    }
}
