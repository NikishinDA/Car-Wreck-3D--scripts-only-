// The Game Events used across the Game.
// Anytime there is a need for a new event, it should be added here.

using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventsHandler
{
    public static readonly GameStartEvent GameStartEvent = new GameStartEvent();
    public static readonly GameOverEvent GameOverEvent = new GameOverEvent();
    public static readonly MoneyCollectEvent MoneyCollectEvent = new MoneyCollectEvent();
    public static readonly FinisherStartEvent FinisherStartEvent = new FinisherStartEvent();
    public static readonly PlayerFinishLevelEvent PlayerFinishLevelEvent = new PlayerFinishLevelEvent();
    public static readonly TutorialShowEvent TutorialShowEvent = new TutorialShowEvent();
    public static readonly TutorialToggleEvent TutorialToggleEvent = new TutorialToggleEvent();
    public static readonly AmbianceChangeEvent AmbianceChangeEvent = new AmbianceChangeEvent();
    public static readonly GateSpeedEvent GateSpeedEvent = new GateSpeedEvent();
    public static readonly GateWeightEvent GateWeightEvent = new GateWeightEvent();
    public static readonly GateSizeEvent GateSizeEvent = new GateSizeEvent();
    public static readonly GateSpikeEvent GateSpikeEvent = new GateSpikeEvent();
    public static readonly DebugCallEvent DebugCallEvent = new DebugCallEvent();
    public static readonly ObstacleEvent ObstacleEvent = new ObstacleEvent();
    public static readonly NitroCollectEvent NitroCollectEvent = new NitroCollectEvent();
    public static readonly LevelLoadEvent LevelLoadEvent = new LevelLoadEvent();
    public static readonly LevelSplineChangeEvent LevelSplineChangeEvent = new LevelSplineChangeEvent();
    public static readonly FinisherPlayEvent FinisherPlayEvent = new FinisherPlayEvent();
    public static readonly FinisherEndEvent FinisherEndEvent = new FinisherEndEvent();
}

public class GameEvent {}
public class GateEvent : GameEvent{} 
public class GameStartEvent : GameEvent
{
}

public class GameOverEvent : GameEvent
{
    public bool IsWin;
}

public class MoneyCollectEvent : GameEvent
{
    
}

public class FinisherStartEvent : GameEvent
{
    
}

public class FinisherPlayEvent : GameEvent{}

public class FinisherEndEvent : GameEvent
{
    public HitType HitType;
}

public class  PlayerFinishLevelEvent : GameEvent{}

public class TutorialShowEvent : GameEvent
{
}

public class TutorialToggleEvent : GameEvent
{
    public bool Toggle;
}


public class AmbianceChangeEvent : GameEvent
{
    public int Number;
}

public class NitroCollectEvent : GameEvent
{
    
}
public class ObstacleEvent : GameEvent
{
    
}
public class GateSpeedEvent : GateEvent
{
    public bool IsGood;
}
public class GateWeightEvent : GateEvent
{
    public bool IsGood;

}
public class GateSizeEvent : GateEvent
{
    public bool IsGood;
}
public class GateSpikeEvent : GateEvent{}

public class LevelLoadEvent : GameEvent
{
    public float[] Length;
}

public class LevelSplineChangeEvent : GameEvent
{
    
}
public class PlayerInfoEvent : GameEvent
{
    
}
public class PlayerInfoSpeedChangeEvent : PlayerInfoEvent
{
    public float Value;
}
public class PlayerInfoWeightChangeEvent : PlayerInfoEvent
{
    public float Value;
}
public class PlayerInfoSizeChangeEvent : PlayerInfoEvent
{
    public float Value;
}
public class PlayerInfoSpikeChangeEvent : PlayerInfoEvent
{
    public bool Value;
}
public class DebugCallEvent : GameEvent
{
    public float Speed;
    public float Strafe;
    public float Size;
    public int NOS;
}





