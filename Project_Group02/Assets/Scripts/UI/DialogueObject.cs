using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class DialogueOBJ
{
    public string[] Dialogues;
    public string CharacterName;
    public int QuestNumber;
}


public class DialogueObject : MonoBehaviour
{
    public PlayerData data;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogueText;

    [Header("Dialogue objects")]
    public DialogueOBJ Dialogue_1;

    int currentDialogueNum = 0;
    DialogueOBJ currentDialogue = null;


    private void OnEnable()
    {
        switch (data.DialogueNumber)
        {
            case 1:
                PlayerDialogue(Dialogue_1);
                currentDialogue = Dialogue_1;
                break;
        }
    }


    void PlayerDialogue(DialogueOBJ tempObj)
    {
        NameText.text = tempObj.CharacterName;
        if(currentDialogueNum < tempObj.Dialogues.Length)
        {
            DialogueText.text = tempObj.Dialogues[currentDialogueNum];
        }
        else
        {
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            data.DialogueNumber = 0;
            currentDialogueNum = 0;
            data.QuestNumber = currentDialogue.QuestNumber;
            currentDialogue = null;

            this.gameObject.SetActive(false);
        }

    }


    public void Next()
    {
        if(currentDialogue != null)
        {
            currentDialogueNum++;
            PlayerDialogue(currentDialogue);
        }
    }


}
