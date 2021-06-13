using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_PotionUI : MonoBehaviour
{
    [Header("Internal References")]
    [SerializeField]
    GameObject potionUIContent;

    [SerializeField]
    Transform startingPosition;

    [SerializeField]
    Button makePotionButton;
    [SerializeField]
    Button clearIngredientsButton;

    [SerializeField]
    TextMeshProUGUI potionText;

    [SerializeField]
    scr_PotionResultUI potionResultUI;


    [SerializeField]
    scr_IngredientSlotUI ingredientSlot0;
    [SerializeField]
    scr_IngredientSlotUI ingredientSlot1;
    [SerializeField]
    scr_IngredientSlotUI ingredientSlot2;

    scr_IngredientUI[] ingredientUIs;
    public scr_IngredientUI[] IngredientUIs => ingredientUIs;

    [Header("External References")]
    [SerializeField]
    scr_PotionManager potionManager;

    [SerializeField]
    AudioClip potionCreatedSFX;

    [SerializeField]
    AudioClip ingredientDroppedSFX;
    public AudioClip IngredientDroppedSFX => ingredientDroppedSFX;
    [SerializeField]
    AudioClip ingredientPickedUpSFX;
    public AudioClip IngredientPickedUpSFX => ingredientPickedUpSFX;

    int currentIngredient;

    static scr_PotionUI instance;
    public static scr_PotionUI Instance { get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<scr_PotionUI>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        ingredientUIs = FindObjectsOfType<scr_IngredientUI>();
    }

    private void Start()
    {
        makePotionButton.interactable = false;
        clearIngredientsButton.interactable = false;

        potionText.text = "";

        RestartPotion(false);
        currentIngredient = 0;
        HidePotionUI();
    }

    public void SetNextIngredient(scr_Ingredient ingredient)
    {
        if(ingredient == null)
        {
            Debug.Log("Got null ingredient");
            return;
        }
        ingredientUIs[currentIngredient].SetIngredient(ingredient);
        ingredientUIs[currentIngredient].gameObject.SetActive(true);
        currentIngredient += 1;
    }

    public void RestartPotion(bool slotsOnly)
    {
        currentIngredient = 0;
        foreach(scr_IngredientUI ingredientUI in ingredientUIs)
        {
            if (!slotsOnly | ingredientUI.IsSetInSlot)
            {
                ingredientUI.UnsetIngredient();
                ingredientUI.gameObject.SetActive(false);
                ingredientUI.transform.position = startingPosition.position;
            }

        }
        List<scr_IngredientSlotUI> slots = new List<scr_IngredientSlotUI>() {
            ingredientSlot0,
            ingredientSlot1,
            ingredientSlot2
        };
        foreach(scr_IngredientSlotUI slotUI in slots)
        {
            slotUI.UnsetObject();

        }
    }

    public void PotionMaker_OnClear()
    {
        makePotionButton.interactable = false;
        clearIngredientsButton.interactable = false;
        scr_AudioManager.PlaySoundEffect(ingredientDroppedSFX, 0.2f);


        RestartPotion(true);
    }

    public void PotionMaker_OnIngredientSelected(int slot, scr_Ingredient ingredient)
    {
        clearIngredientsButton.interactable = true;
    }

    public void PotionMaker_OnIngredientsSelectionComplete()
    {
        makePotionButton.interactable = true;
    }

    public void PotionManager_OnPotionCreated(scr_Potion potionCreated)
    {
        potionText.text = potionCreated.Name;
        RestartPotion(true);
        scr_AudioManager.PlaySoundEffect(potionCreatedSFX, 0.2f);
    }

    public void PotionMakeButton_OnClick()
    {
        potionManager.AttemptMakePotion();
    }

    public void ClearButton_OnClick()
    {
        potionManager.ClearIngredients();
        Debug.Log("clear");
    }

    public void IngredientSlot_OnChange(int slot, scr_Ingredient ingredient = null)
    {
        if (ingredient == null)
        {
            potionManager.ClearIngredient(slot);
        }
    }

    public void ShowPotionUI()
    {
        potionUIContent.SetActive(true);
    }

    public void HidePotionUI()
    {
        potionUIContent.SetActive(false);

    }

}
