using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueIntroManger : MonoBehaviour
{
    [SerializeField]
    DialogueSystem dialogueSystem;

    IEnumerator Start()
    {

        yield return new WaitForSeconds(1);

        dialogueSystem.Trigger();
    }
}
