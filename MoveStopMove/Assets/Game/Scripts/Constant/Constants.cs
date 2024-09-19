using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public class AnimType
    {
        public const string IDLE = "IsIdle";
        public const string WIN = "IsWin";
        public const string RUN = "IsRun";
        public const string ULTI = "IsUlti";
        public const string DANCE = "IsDance";
        public const string ATTACK = "IsAttack";
        public const string DEAD = "IsDead";
    }

    public class CharacterAttack
    {
        public const float ATTACK_TIME = 0.7f;
        public const float ATTACK_SPEED = 0.25f;
        public const float DEFAULT_SPHERE_RADIUS = 5f;
        public const float MIN_SIZE = 1f;
        public const float MAX_SIZE = 4f;
    }

    public class TagName
    {
        public const string CHARACTER = "Character";
        public const string WEAPON = "Weapons";
        public const string OBSTACLE = "Obstacle";
    }

    public class BulletSpeed
    {
        public const float BOOMERANG = 5f;
        public const float STRAIGHT = 9f;
        public const float ROTATION = 800f;
    }

    public enum SkinColorType
    {
        Hammer = 0,
        Bommerang = 1,
        Knife = 2,
    }
    
    public enum WeaponType
    {
        Hammer = 0,
        Bommerang = 1,
        Knife = 2,
    }

    

    public enum HatType
    {
        None = 0,
        Arrow = 1,
        Ear = 2,
        Crown = 3,
        Flower = 4,
        Hair = 5,
        Hat = 6,
        Police = 7,
        Horn = 8,
        Rau = 9,
        //Luffy = 8,
        //Headphone = 9,
    }

    public enum PantsType 
    {
        Default = 0,
        batman = 1,
        chambi = 2,
        comy = 3,
        dabao = 4,
        onion = 5,
        pokemon = 6,
        rainbow = 7,
        skull = 8,
        vantim = 9,
    }
    
    public enum AccessoryType
    {
        None = 0,
        CaptainShield = 1,
        BatmanShield = 2,
    }

    public enum SetType
    {
        Normal = 0,
        Devil = 1,
        Angel = 2,
        Witch = 3,
        Deadpool = 4,
        Thor = 5,
    }
    
    public enum ItemType
    {
        Hat = 0,
        Pants = 1,
        Accessory = 2,
        SetSkin = 3,
        Weapon = 4,
    }

    public enum ButtonState
    {
        Lock = 0,
        Unlock = 1,
        Equipped = 2,
        None = 3,
    }

    public enum WeaponAdjust
    {
        KnifeStraightX = -90,

        KnifeStraightY = 180,
    }

    public enum StateTimerAndRate
    {
        minIdleTime = 2,
        maxIdleTime = 5,

        attackMinChance = 0,
        attackMaxChance = 100,
    }

    public enum FX
    {
        BloodVFX = 0,
    }

    public enum BotName
    {
        Messi, 
        Ronaldo, 
        PeterParker, 
        SteveUniverse, 
        WashingtonDC,
        KyleWalker, 
        MichaelJackson, 
        Poseidon, 
        BrianGriffin, 
        ThomasEdison, 
        Ramirez, 
        Bryant, 
        YoungKiller
    }

    public enum PlayerPrefsKey
    {
        Hat,
        Weapon,
        Pant,
        Accessory,
        FullSet,
        PlayerGold,
        PlayerName,
    }

    public enum Gold
    {
        GOLD_PER_KILL = 3,
        GOLD_PER_LEVEL = 100,
        POINT = 10,
    }

    public enum Camera
    {
        DEFAULT_GAMEPLAY_CAMERA_FOV = 35,
        FOV_PER_SIZE = 5,
    }
    public class SpawnAndDespawnTime
    {
        public const float Bot_Despawn_Time = 1.5f;
        public const float Bot_Spawn_Time = 2f;
    }
}
