using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Image backgroundColor;
    UnityEngine.Color32 orange;
    Dictionary<int, Color> backgroundColors;
    public void Start()
    {
        orange = new Color32(248, 148, 6, 255);
        backgroundColors = new Dictionary<int, Color>() { {0 , Color.red }, { 1, Color.red }, { 2, orange }, { 3, Color.yellow }, { 4, Color.green }, { 5, Color.blue } };
        backgroundColor.color = Color.blue;
        HealthUIBroker.HealthIsGained += HealthIsGained;
        HealthUIBroker.HealthIsLost += HealthIsLost;
    }

    public void HealthIsLost()
    {
        backgroundColors.TryGetValue(GameManager.instance.playerHealth, out Color colorChange);
        backgroundColor.color = colorChange;
    }

    public void HealthIsGained()
    {
        backgroundColors.TryGetValue(GameManager.instance.playerHealth, out Color colorChange);
        backgroundColor.color = colorChange;
    }
    
}
