using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private MaxAmmoManager ammoManager;
    public GameObject ballPrefab;
    public Transform shotPoint;
    public Transform cameraRotation;
    public Camera mainCamera;
    private float shootPower;

    void Shoot(float shootPower)
    {
        if (ammoManager.CurrentAmmo <= 0) return;
        GameObject shootObject = Instantiate(ballPrefab, shotPoint.position, cameraRotation.rotation);
        shootObject.GetComponent<Rigidbody>().AddForce(shootObject.transform.forward * shootPower, ForceMode.Impulse);
        
    }

    private void Awake()
    {
        ammoManager = GetComponent<MaxAmmoManager>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            shootPower = (60 - mainCamera.fieldOfView) * 0.8f;
            Debug.Log(shootPower);
            Shoot(shootPower);
            ammoManager.CurrentAmmo--;
        }
    }

}
