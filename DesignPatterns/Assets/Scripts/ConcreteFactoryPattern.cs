using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConcreteFactoryPattern
{
    public enum EnemyType
    {
        NONE = 0,
        GOBLIN = 1,
        ORC = 2,
        SLIME = 3
    }
    public interface IEnemy
    {
        EnemyType GetType();
    }
    public interface IEnemyFactory
    {
        static IEnemy CreateEnemy{get;}
    }
    public class Goblin : IEnemy
    {
        EnemyType IEnemy.GetType() => EnemyType.GOBLIN;
        public class Factory : IEnemyFactory
        {
            public static IEnemy CreateEnemy()
            {
                return new Goblin();
            }
        }
    }
    public class Orc : IEnemy
    {
        EnemyType IEnemy.GetType() => EnemyType.ORC;
        public class Factory : IEnemyFactory
        {
            public static IEnemy CreateEnemy()
            {
                return new Orc();
            }
        }
    }
    public class Slime : IEnemy
    {
        EnemyType IEnemy.GetType() => EnemyType.SLIME;
        public class Factory : IEnemyFactory
        {
            public static IEnemy CreateEnemy()
            {
                return new Slime();
            }
        }
    }
    public class Game
    {
        IEnemy goblin = Goblin.Factory.CreateEnemy();
        IEnemy orc = Orc.Factory.CreateEnemy();
        IEnemy slime = Slime.Factory.CreateEnemy();
    }
}
