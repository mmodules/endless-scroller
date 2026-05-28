using System.Collections;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject tutorialCursor;
    
    void Start()
    {
        StartCoroutine(TutorialSequence());
    }

    IEnumerator TutorialSequence()
    {
        tutorialText.SetActive(false);
        tutorialCursor.SetActive(false);
        
        while (!LevelGenerator.doTutorial)
        {
            yield return null;
        }

        tutorialText.SetActive(true);
        tutorialCursor.SetActive(true);

        yield return new WaitForSeconds(4f);

        tutorialText.SetActive(false);
        tutorialCursor.SetActive(false);

        LevelGenerator.doTutorial = false;
    }
}