using UnityEngine;

public class Tutorial : MonoBehaviour
{
   [SerializeField] private GameObject screen1;
   [SerializeField] private GameObject screen2;
   [SerializeField] private GameObject screen3;
   [SerializeField] private GameObject fatherTutorial;

    public void TutorialSequence()
    {
        if (screen1.activeSelf)
        {
            screen1.SetActive(false);
            screen2.SetActive(true);
        }
        else if (screen2.activeSelf)
        {
            screen2.SetActive(false);
            screen3.SetActive(true);
        }
        else if (screen3.activeSelf)
        {
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(false);
            fatherTutorial.SetActive(false);
        }
    }
}
