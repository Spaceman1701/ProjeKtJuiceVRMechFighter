using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Weapon : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f; // Seconds between firing
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public float minTriggerPressure = 0.35f;

    public HandState handstate;
    public Transform gunEnd;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f); // How long laser lasts on screen

    private LineRenderer laserLine; // Draw straight line between view
    private float nextFire;

    //private Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        nextFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (handstate.GetTriggerPress() > minTriggerPressure && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireGun();
        }

    }

    private void FireGun()
    {
        RaycastHit hit;

        StartCoroutine(ShotEffect());
        Vector3 shootOrigin = gunEnd.position;
        laserLine.SetPosition(0, shootOrigin);

        if (Physics.Raycast(shootOrigin, gunEnd.forward, out hit, weaponRange))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(1, gunEnd.forward * weaponRange);
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration; // Shoot laser for the length of shotDuration
        laserLine.enabled = false;
    }
}
