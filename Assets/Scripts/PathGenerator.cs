using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathGenerator : MonoBehaviour
{
    private float pathX = 0f;
    private float pathWidth = 2.3f;
    public float currentY = 0f;
    
    private float maxX = 1.2f; // maximum corridor path deviation from center of screen
    
    public GameObject wallPrefab;

    private float segmentHeight = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            GenerateSegment();
        }
    }

    private void CreateWalls()
    {
        float leftWall = pathX - pathWidth;
        float rightWall = pathX + pathWidth;
        
        Vector3 leftPos = new Vector3(leftWall, currentY, 0);
        Vector3 rightPos = new Vector3(rightWall, currentY, 0);
        
        Instantiate(wallPrefab, leftPos, Quaternion.identity);
        Instantiate(wallPrefab, rightPos, Quaternion.identity);
    }

    void GenerateSegment()
    {
        float shift = Random.Range(-0.7f, 0.7f);
        if (Math.Abs(pathX + shift) > maxX)
        {
            shift -= shift;
        }
        pathX += shift;

        CreateWalls();
        
        currentY += segmentHeight;
    }
}
