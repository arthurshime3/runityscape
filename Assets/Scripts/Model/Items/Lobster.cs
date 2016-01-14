﻿using UnityEngine;
using System.Collections;
using System;

public class Lobster : ConsumableItem {

    public const string NAME = "Lobster";
    public const string DESCRIPTION = "Eat a Lobster for 12 HP, just like in RuneScape™. Property of Jagex Ltd. The most popular Free-To-Play MMORPG played by millions worldwide.";
    public const int HEAL_AMOUNT = 12;

    public Lobster(Character caster, int count = 1) : base(caster, NAME, DESCRIPTION, count) {

    }

    public override void onSuccess() {
        caster.addToResource(ResourceType.HEALTH, false, HEAL_AMOUNT);
        setCastText(string.Format("* {0} eats a Lobster for {1} HP!", caster.getName(), HEAL_AMOUNT));
    }

    public override void undo() {
        base.undo();
        caster.getInventory().add(new Lobster(caster, 1));
        caster.addToResource(ResourceType.HEALTH, false, -HEAL_AMOUNT);
    }
}