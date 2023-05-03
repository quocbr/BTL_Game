using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] protected Card card;
    [SerializeField] protected Text nameText;
    [SerializeField] protected Text descriptionText;
    [SerializeField] protected Image artworkImage;

    private int index;

    private void Awake()
    {
        string[] name = gameObject.name.Split("#");
        index = int.Parse(name[1]);
    }

    void Update()
    {
        card = CardController.Instance.chooseSkill[index];
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artWork;
    }

    public void Active()
    {
        PlayerController.Instance.AddSkill(card.attack,card.health,card.range,card.speed,card.shield,card.speedAttack, card.Gun);
        UIManager.Instance.SetActivePanelLevelUp(false);
    }
}