using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<LevelSegment> segmentPrefabs;
    public LevelSegment tutorialSegment;
    public Transform player;

    public static bool doTutorial;

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
        if (player != null)
        {
            if (activeSegments.Count > 0)
            {
                if (player.position.y > lastSegment.endPoint.position.y - 20f)
                {
                    SpawnSegment();

                    if (activeSegments.Count > 3)
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
    }

    void SpawnSegment()
    {
        LevelSegment newSegment;
        LevelSegment prefab;
        if (Score.firstTimePlaying)
        {
            // PLAY TUTORIAL/GUIDE
            Score.firstTimePlaying = false;
            prefab = tutorialSegment;
            doTutorial = true;
        }
        else
        {
            int random = Random.Range(0, segmentPrefabs.Count);
            prefab = segmentPrefabs[random];
        }
        newSegment = Instantiate(prefab);
        activeSegments.Enqueue(newSegment);
        
        if (lastSegment == null)
        {
            // offset y by 4 so that it doesnt start right up in your face
            
            newSegment.transform.position = new Vector3(0, 6, transform.position.z);
        }
        else
        {
            Vector3 offset = lastSegment.endPoint.position - newSegment.startPoint.position;
            newSegment.transform.position += offset;
        }

        lastSegment = newSegment;
    }
}