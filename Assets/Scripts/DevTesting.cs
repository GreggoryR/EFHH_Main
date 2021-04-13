using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevTesting : MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    {
        text.text = SystemInfo.deviceType.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
