using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;

    public Text textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<Text>();
        
    }

    void Update()
    {
        int Ammo = gunData.currentAmmo;
        string AmmoCount = Ammo.ToString();
        textMeshPro.text = AmmoCount;
    }
}
