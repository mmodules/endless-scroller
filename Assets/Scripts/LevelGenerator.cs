using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<LevelSegment> segmentPrefabs;
    public Transform player;

    public int segmentsAhead = 6;

    private LevelSegment lastSegment;
    
    Queue<LevelSegment> activeSegments = new Queue<LevelSegment>();

    void Start()
    {
        // spawn starting segments
        for (int i = 0; i < segmentsAhead; i++)
        {
            SpawnSegment();
        }
    }

    void Update()
    {
        if (activeSegments.Count > 0)
        {
            if (player.position.y > lastSegment.endPoint.position.y - 20f)
            {
                SpawnSegment();
            
                if (activeSegments.Count > 4)
                {
                    Destroy(activeSegments.Dequeue().gameObject);
                }
            }
        }
        else
        {
            SpawnSegment();
        }

    }

    void SpawnSegment()
    {
        int random = Random.Range(0, segmentPrefabs.Count);
        Debug.Log(segmentPrefabs.Count);
        LevelSegment prefab = segmentPrefabs[random];

        LevelSegment newSegment = Instantiate(prefab);
        activeSegments.Enqueue(newSegment);

        if (lastSegment == null)
        {
            newSegment.transform.position = new Vector3(0, 2, transform.position.z);
        }
        else
        {
            Vector3 offset = lastSegment.endPoint.position - newSegment.startPoint.position;
            newSegment.transform.position += offset;
        }

        lastSegment = newSegment;
    }
}