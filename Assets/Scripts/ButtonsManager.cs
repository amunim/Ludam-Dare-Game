﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Utility;
using System;

public class ButtonsManager : MonoBehaviour
{
    public Card CardOne, CardTwo, CardThree;

    private float cardOneTimer, cardTwoTimer, cardThreeTimer;
    private bool cardOneTimerSet, cardTwoTimerSet, cardThreeTimerSet;

    public bool CardOneTimerSet { get { return cardOneTimerSet; } }
    public bool CardTwoTimerSet { get { return cardTwoTimerSet; } }
    public bool CardThreeTimerSet { get { return cardThreeTimerSet; } }

    private void Update()
    {
        if (cardOneTimerSet)
        {
            cardOneTimer -= Time.deltaTime;

            if (cardOneTimer <= 0)
            {
                cardOneTimer = 0;

                cardOneTimerSet = false;
                CardOne.MyButton.interactable = true;
                print("re-enabling Card One");
            }
        }

        if (cardTwoTimerSet)
        {
            cardTwoTimer -= Time.deltaTime;

            if (cardTwoTimer <= 0)
            {
                cardTwoTimer = 0;

                cardTwoTimerSet = false;
                CardTwo.MyButton.interactable = true;
                print("re-enabling Card Two");
            }
        }

        if (cardThreeTimerSet)
        {
            cardThreeTimer -= Time.deltaTime;

            if (cardThreeTimer <= 0)
            {
                cardThreeTimer = 0;

                cardThreeTimerSet = false;
                CardThree.MyButton.interactable = true;
                print("re-enabling Card Three");
            }
        }
    }

    public void CardOneButton()
    {
        CardOne.MyWork = FindObjectOfType<AllCardActions>().GetRandomAction(); ;

        print("Using Card One, adding timer");
        Debug.Log("Card One action: " + CardOne.MyWork.Method.ToString());
        CardOne.MyWork();

        DisableAllCards();
    }

    public void DisableAllCards() // using a card should disable ALL cards
    {
        DisableCardToUse(CardOne);
        DisableCardToUse(CardTwo);
        DisableCardToUse(CardThree);
    }

    public void EnableAllCards() 
    {
        ReEnableCardToUse(CardOne);
        ReEnableCardToUse(CardTwo);
        ReEnableCardToUse(CardThree);
    }

    public void CardTwoButton()
    {
        CardTwo.MyWork = FindObjectOfType<AllCardActions>().GetRandomAction();
        print("Using Card Two, adding timer");
        Debug.Log("Card Two action: " + CardTwo.MyWork.Method.ToString());
        CardTwo.MyWork();

        DisableAllCards();
    }

    public void CardThreeButton()
    {
        CardThree.MyWork = FindObjectOfType<AllCardActions>().GetRandomAction();
        Debug.Log("Card Three action: " + CardThree.MyWork.Method.ToString());
        print("Using Card Three, adding timer");
        CardThree.MyWork();

        DisableAllCards();
    }

    private void DisableCardToUse(Card Card)
    {
        UtilityClass.UnableButton(Card.MyButton);

        switch (Card.CardNumber)
        {
            case 1:
                cardOneTimer = Card.RelodTime;
                cardOneTimerSet = true;
                break;

            case 2:
                cardTwoTimer = Card.RelodTime;
                cardTwoTimerSet = true;
                break;

            case 3:
                cardThreeTimer = Card.RelodTime;
                cardThreeTimerSet = true;
                break;

            default:
                print("Wrong Card Number");
                break;
        }
    }

    private void ReEnableCardToUse(Card Card)
    {
        UtilityClass.EnableButton(Card.MyButton);

        switch (Card.CardNumber)
        {
            case 1:
                cardOneTimerSet = false;
                break;

            case 2:
                cardTwoTimerSet = false;
                break;

            case 3:
                cardThreeTimerSet = false;
                break;

            default:
                print("Wrong Card Number");
                break;
        }
    }
}
