using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waterText;

    private int water = 0;
    

    public void AddWater(int amount)
    {
        water += amount;
        waterText.text = water.ToString();
    }
}
