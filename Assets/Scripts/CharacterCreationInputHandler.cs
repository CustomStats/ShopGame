using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.UIElements;

public class CharacterCreationInputHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI buttonText;
    public HandleScenes handleScene;
    private string submittedText;
    public void validateInput()
    {
        if (buttonText.text == "Confirm")
        {
            PlayerPrefs.SetString("playerName", inputField.text);
            handleScene.SwitchToGameScene();
            return;
        }

        string input = inputField.text;
        submittedText = input;

        if (input.Length < 4 )
        {
            resultText.text = "Must be between 4 and 25 characters";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "Valid Name";
            resultText.color = Color.green;
            buttonText.text = "Confirm";
        }

    }

    private void Update()
    {
        if (inputField.text != submittedText)
        {
            resultText.SetText("");
            buttonText.text = "Create Character";
        }
    }
}
