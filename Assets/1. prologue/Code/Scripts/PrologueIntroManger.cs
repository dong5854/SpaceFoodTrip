using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueIntroManger : MonoBehaviour
{
    [SerializeField]
    DialogueSystem dialogueSystem;

    void Start()
    {
        dialogueSystem.Trigger();
    }
}
