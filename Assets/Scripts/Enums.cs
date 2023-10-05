public enum ItemType
{
    Food = 1,
    Equipment,
    Weapon,
    Armor,
    Implant,
    Default
}

public enum Motivations
{
    Unity = 1,
    Understanding,
    Care,
    Autonomy,
    Control,
    Justice,
}

public enum BossLevel
{
    GangBoss = 1,
    Shouter,
    Underling,
    Ganger,
}

public enum CharacterClass
{
    Merc = 1,
    Krim,
    Connector,
    Netrunner,
    Tech,
}

public enum GameState
{   
    PlayerTurn = 1,
    EnemyTurn,
    DamageCalc,
    Win,
    Loss,
    GameOver,
    OutofCombat,
    StoryScene,
    PlayerAmbush,
    EnemyAmbush,
    BattleStart,
    Story,
}

public enum AbilityIDnr
{
    Attack = 1,
    Support,
    Voice,
    Aggitation,
    
}

public enum AbilityTargetnr
{
    Life = 1,
    Stress,
    Conviction,
    Bonus,
    All,

}

public enum AbilityExpertise
{
    Athletics = 1,
    Combat,
    Stealth,
    Netrunning,
    Tech,

}

public enum AbilityMotivation
{
    Unity = 1,
    Understanding,
    Care,
    Autonomy,
    Control,
    Justice,

}

public enum TargetType
{
    Player = 1,
    Enemy,
}

public enum SelectionType
{
    All = 99,
    None,
}