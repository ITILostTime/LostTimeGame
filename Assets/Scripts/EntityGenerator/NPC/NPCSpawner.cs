﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

public class NPCSpawner : ITickable
{
    readonly NPC.Factory _NPCFactory;  

    FactoryAnimation _animationFactory;
    FactoryPathfinding _pathfindingFactory;
    FactoryTailor _tailorFactory;

    QuestManager _questManager;
    private int npcCount = 0;

    public NPCSpawner(
        QuestManager questManager,
        FactoryAnimation animationFactory,
        FactoryPathfinding pathfindingFactory,
        FactoryTailor tailorFactory,
        NPC.Factory NPCFactory
        )
    {
        _questManager=questManager;
        _NPCFactory = NPCFactory;
        _animationFactory = animationFactory;
        _tailorFactory = tailorFactory;
        _pathfindingFactory = pathfindingFactory;

        //Debug.Log("End NPCSpawner");
    }

    public void Tick()
    {
        if(ShouldSpawnNewNPC())
        {
            npcCount++;

            //Debug.Log(string.Format("Start Factory NPC #{0}",npcCount));
            var data = _questManager.createNewNpc();            

            var newAnimCtrl = _animationFactory.Create(data);
            var newPathfinding = _pathfindingFactory.Create(data);
            var newTailor = _tailorFactory.Create(data);

            var npc = _NPCFactory.Create(newTailor, _questManager, data, newAnimCtrl, newPathfinding);
            //Debug.Log("End Factory NPC");
            Debug.Log(string.Format("Spawn NPC #{0}, {1}",npcCount, data.ToString()));

        }
        //Debug.Log("Tick");
    }

    private bool ShouldSpawnNewNPC()
    {
        //Debug.Log("coin");

        //return (Input.GetKeyDown(KeyCode.X)) ? true : false;
        return (npcCount<_questManager.AmountOfCrownToSpawn) ? true : false;

    }
}

