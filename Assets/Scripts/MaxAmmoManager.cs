using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxAmmoManager : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public int maxAmmo;
    public int curAmmo;

    public int CurrentAmmo
    {
        get
        {
            return curAmmo;
        }
        set
        {
            curAmmo = value;
            ammoText.text = "Marble Left: " + curAmmo + "/" + maxAmmo;
        }
    }

    private void Start()
    {
        curAmmo = maxAmmo;
        ammoText.text = "Marble Left: " + curAmmo + "/" + maxAmmo;
    }
}
