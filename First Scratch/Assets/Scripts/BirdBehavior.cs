using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    public enum BirdState
    {
        Waiting,
        Flying,
    }

    public BirdState birdState { get; private set; }

    public float flySpeed = 10.0f;

    public float waitTime = 5.0f;
    public float waitVariance = 1.0f;

    public AnimationCurve FlightCurve;

    private float targetTime = 0.0f;
    private float flightTime = 0.0f;

    private LandingPoint currentLandingPoint;
    private LandingPoint previousLandingPoint;

    void Start()
    {
        birdState = BirdState.Waiting;

        // Try to find a starting spot.
        currentLandingPoint = FindLandingPoint();
        if (currentLandingPoint != null)
        {
            currentLandingPoint.isOccupied = true;
            transform.position = currentLandingPoint.transform.position;
        }

        // Reset our wait timer.
        ResetWaitTimer();
    }

    void Update()
    {
        if (birdState == BirdState.Waiting)
        {
            // Decrement the wait timer.  If we've still got time left,
            // we return.
            targetTime -= Time.deltaTime;
            if (targetTime > 0.0f)
            {
                return;
            }

            // Try to find another location to fly to.
            LandingPoint landingPoint = FindLandingPoint();

            // If we didn't find a landing point, or we found the one we're
            // currently on, reset the wait timer and return.
            if (landingPoint == null || landingPoint == currentLandingPoint)
            {
                ResetWaitTimer();
                return;
            }

            // Unclaim the old point, and claim the new point.
            previousLandingPoint = currentLandingPoint;
            currentLandingPoint = landingPoint;

            if (previousLandingPoint != null)
            {
                previousLandingPoint.isOccupied = false;
            }

            currentLandingPoint.isOccupied = true;
            flightTime = 0.0f;

            birdState = BirdState.Flying;
        }
        else if (birdState == BirdState.Flying)
        {
            flightTime += Time.deltaTime;

            float totalFlightTime = GetFlightTime();
            float normalizedFlightTime = flightTime / totalFlightTime;

            transform.position = Vector3.Lerp(
                previousLandingPoint.transform.position,
                currentLandingPoint.transform.position, 
                FlightCurve.Evaluate(normalizedFlightTime));

            // If we're close enough to the new location, reset our wait timer,
            // and change state back to waiting.
            if (Vector3.Distance(transform.position, currentLandingPoint.transform.position) < 0.001f)
            {
                ResetWaitTimer();
                birdState = BirdState.Waiting;
            }
        }
    }

    private LandingPoint FindLandingPoint()
    {
        GameObject[] landingPointGameObjects = GameObject.FindGameObjectsWithTag("LandingPoint");
        
        // Build a list of valid landing points.
        List<LandingPoint> validLandingPoints = new List<LandingPoint>();
        foreach (GameObject pointGameObject in landingPointGameObjects)
        {
            LandingPoint point = pointGameObject.GetComponent<LandingPoint>();
            if (point == null)
            {
                continue;
            }

            if (point.isOccupied)
            {
                continue;
            }

            validLandingPoints.Add(point);
        }

        if (validLandingPoints.Count == 0)
        {
            return null;
        }

        int RandIndex = Random.Range(0, validLandingPoints.Count - 1);
        return validLandingPoints[RandIndex];
    }

    private void ResetWaitTimer()
    {
        targetTime = waitTime + Random.Range(-waitVariance, waitVariance);
    }

    private float GetFlightTime()
    {
        if (previousLandingPoint == null || currentLandingPoint == null)
        {
            return 0.0f;
        }

        float distance = Vector3.Distance(previousLandingPoint.transform.position, currentLandingPoint.transform.position);
        
        return distance / flySpeed;
    }
}