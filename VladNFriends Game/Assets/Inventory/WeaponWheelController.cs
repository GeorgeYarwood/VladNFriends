using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheelController : MonoBehaviour
{
    public int Id;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;

    public bool playerHasIt = false;
    [SerializeField] private Image sprite;
    [SerializeField] private Button button;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHasIt)
        {
            sprite.enabled = true;
            button.interactable = true;
        }
        
        else if (!playerHasIt)
        {
            sprite.enabled = false;
            button.interactable = false;
        }
        
        if (selected == true)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        if (playerHasIt)
        {
            selected = true;
            InventoryController.weaponId = Id;
        }
    }

    public void Deselected()
    {
        if (playerHasIt)
        {
            selected = false;
            InventoryController.weaponId = 0;
        }
    }

    public void HoverEnter()
    {
        if (playerHasIt)
        {
            anim.SetBool("Hover", true);
            itemText.text = itemName;
        }
        
    }

    public void HoverExit()
    {
        if (playerHasIt)
        {
            anim.SetBool("Hover", false);
            itemText.text = "";
        }
    }
}
