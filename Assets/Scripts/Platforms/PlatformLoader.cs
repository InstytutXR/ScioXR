﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Management;

public class PlatformLoader : MonoBehaviour
{
    public enum ScioXRPlatforms
    {
        Flat3D,
        UnityXR,
        WebXR
    };

    public ScioXRPlatforms currentPlatfrom;

    public GameObject[] platforms;

    public static PlatformLoader instance;

    public Platform platform;

    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;

            Init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Init()
    {
        platform = platforms[(int)currentPlatfrom].GetComponent<Platform>();
        platforms[(int)currentPlatfrom].SetActive(true);
        platform.Init();

#if UNITY_WEBGL
        //platform = gameObject.AddComponent<Scio3DPlatform>();
        //setup3D.SetActive(true);
#else
        /*if (force3D)
        {
            platform = gameObject.AddComponent<Scio3DPlatform>();
            setup3D.SetActive(true);
        }
        else
        {
            XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
            if (XRGeneralSettings.Instance.Manager.activeLoader == null)
            {
                Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
                setup3D.SetActive(true);
                platform = gameObject.AddComponent<Scio3DPlatform>();
                //EventSystem.current.GetComponent<XRUIInputModule>().enabled = false;
            }
            else
            {
                Debug.Log("Starting XR...");
                setupVR.SetActive(true);
                platform = gameObject.AddComponent<UnityXRPlatform>();
                XRGeneralSettings.Instance.Manager.StartSubsystems();
            }
        }*/
#endif
    }
}
