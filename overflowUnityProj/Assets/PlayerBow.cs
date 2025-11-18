using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : IBaseWeapon
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float minPower = 8f;
    public float maxPower = 20f;
    public float chargeRate = 12f;

    [Header("Trajectory Settings")]
    public int trajectoryPoints = 30;   // number of sampled points
    public float timeBetweenPoints = 0.05f; // time step between points
    public float visibleDistance = 5f;  // how far the line extends

    private float currentPower = 0f;
    private bool isCharging = false;
    private LineRenderer lineRenderer;

    public void Enable() {
      this.enabled = true;
    }
    
    public void Disable() {
      this.enabled = false;
    }
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCharge();
        }

        if (Input.GetMouseButton(0))
        {
            Charge();
            ShowTrajectory();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    void StartCharge()
    {
        isCharging = true;
        currentPower = minPower;
        lineRenderer.enabled = true;
    }

    void Charge()
    {
        if (isCharging)
        {
            currentPower += chargeRate * Time.deltaTime;
            currentPower = Mathf.Clamp(currentPower, minPower, maxPower);
        }
    }

    void Shoot()
    {
        isCharging = false;
        lineRenderer.enabled = false;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;

        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
        arrow.transform.parent = transform;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.velocity = direction * currentPower;

        currentPower = 0;
    }

    void ShowTrajectory()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;
        Vector2 startVelocity = direction * currentPower;

        lineRenderer.positionCount = trajectoryPoints;

        Vector2 prevPos = shootPoint.position;
        float totalDistance = 0f;
        int i;

        for (i = 0; i < trajectoryPoints; i++)
        {
            float t = i * timeBetweenPoints /* Time.deltaTime*/;
            Vector2 newPos = (Vector2)shootPoint.position + startVelocity * t + 0.5f * Physics2D.gravity * (t * t);
            totalDistance += Vector2.Distance(prevPos, newPos);

            lineRenderer.SetPosition(i, newPos);

            // Stop early once we've reached visibleDistance
            if (totalDistance > visibleDistance)
            {
                lineRenderer.positionCount = i + 1;
                break;
            }

            prevPos = newPos;
        }
    }
}