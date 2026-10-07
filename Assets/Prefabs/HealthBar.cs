using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HealthBar : MonoBehaviour
{
    public Image imagePrefab;
    public Image Hearth;
    //public PlayerHealthNew playerHealth;
    public List<Image> Hearths = new List<Image>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < PlayerHealthNew.instance.maxHealth; i++)
        {
            Hearth = Instantiate(imagePrefab, transform.position, Quaternion.identity);
            Hearth.transform.SetParent(this.transform, false);
            Hearths.Add(Hearth);
        }
    }
    public void UpdateHearths()
    {
        for (int i = 0; i < PlayerHealthNew.instance.maxHealth; i++)
        {
            if (i < PlayerHealthNew.instance.currentHealth)
            {
                Hearths[i].color = Color.red;
            }
            else
                Hearths[i].color = Color.black;
        }
    }

    private void Update()
    {
        UpdateHearths();
    }
}
