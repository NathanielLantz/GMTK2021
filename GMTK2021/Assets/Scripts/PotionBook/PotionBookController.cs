using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct PotionPageContent
{
    public string textToDisplay;
}

public class PotionBookController : MonoBehaviour
{
    [SerializeField]
    GameObject bookUI;

    [SerializeField]
    PotionPageContent[] content;


    int currentPage;

    private void Awake()
    {
        currentPage = 0;
    }

    [ContextMenu("Next Page")]
    public void NextPage()
    {
        currentPage += 1;
        if (currentPage > content.Length - 1)
        {
            currentPage = content.Length - 1;
        }
        UpdatePageContent();
    }

    [ContextMenu("Prevous Page")]
    public void PreviousPage()
    {
        currentPage -= 1;
        if (currentPage > content.Length - 1)
        {
            currentPage = content.Length - 1;
        }
        UpdatePageContent();

    }

    private void UpdatePageContent()
    {
        Debug.Log(content[currentPage].textToDisplay);
    }

    public void Open()
    {
        bookUI.SetActive(true);
        UpdatePageContent();
    }

    public void Close()
    {
        bookUI.SetActive(false);

    }
}
