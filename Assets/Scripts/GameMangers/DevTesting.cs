///////////////////////////////////////////////////////////////////////////
//FileName: DevTesting.cs
//Author : Greggory Reed
//Description : Testing in Unity for misc. 
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class DevTesting : MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    {
        text.text = SystemInfo.deviceType.ToString();
    }
}
