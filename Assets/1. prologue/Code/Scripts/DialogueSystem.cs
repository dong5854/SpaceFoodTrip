using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtName;

    public TextMeshProUGUI TxtName
    {
        get
        {
            return txtName;
        }
        set
        {
            txtName = value;
        }
    }

    [SerializeField] private TextMeshProUGUI txtSentence;

    public TextMeshProUGUI TxtSentence
    {
        get
        {
            return txtSentence;
        }
        set
        {
            txtSentence = value;
        }
    }

    private Queue<string> sentences = new Queue<string>();

    [SerializeField] private Animator animator;

    public void Begin(Dialogue info)
    {
        animator.SetBool("isOpen", true);
        sentences.Clear();

        TxtName.text = info.Name;

        foreach (var sentence in info.Sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        //TxtSentence.text = sentences.Dequeue();
        TxtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void End()
    {
        animator.SetBool("isOpen", false);
        TxtSentence.text = string.Empty;
    }
}
