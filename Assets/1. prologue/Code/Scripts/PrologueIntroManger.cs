using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueIntroManger : MonoBehaviour
{
    [SerializeField]
    DialogueSystem dialogueSystem;

    IEnumerator Start()
    {

        yield return new WaitForSeconds(1);

        dialogueSystem.Trigger();
    }

    void Update() {    
        if (dialogueSystem.IsDone) {
            SceneManager.LoadScene("PrologueProblemSolve");
        }
    }
}
