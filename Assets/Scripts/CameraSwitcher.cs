using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return ActiveCamera == camera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera && c.Priority == 10)
            {
                c.Priority = 2;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        int priority = -1;
        cameras.Add(camera);
        if (camera.gameObject.tag == "PlayerCam")
            priority = 9;
        else
            priority = 2;
        camera.Priority = priority;
        cameras.Add(camera);

        Debug.Log("Camera " + camera + " registered at priority " + priority);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera unregistered: " + camera);
    }
}
