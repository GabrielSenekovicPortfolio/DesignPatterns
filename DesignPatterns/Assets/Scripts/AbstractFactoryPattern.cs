using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AbstractFactoryPattern
{
    public enum Class
    {
        NONE = 0,
        FIGHTER = 1,
        WIZARD = 2
    }
    public enum Setting
    {
        NONE = 0,
        FANTASY = 1,
        SCIFI = 2
    }
    public interface IWeapon
    {
        public string GetWeaponName();
    }
    public interface IArmor
    {
        public string GetArmorName();
    }
    public class Sword : IWeapon
    {
        public string GetWeaponName()
        {
            return "Sword";
        }
    }
    public class Staff : IWeapon
    {
        public string GetWeaponName()
        {
            return "Staff";
        }
    }
    public class LeatherArmor : IArmor
    {
        public string GetArmorName()
        {
            return "Leather Armor";
        }
    }
    public class HeavyArmor : IArmor
    {
        public string GetArmorName()
        {
            return "Heavy Armor";
        }
    }
    public interface UnitFactory<T>
    {
        public abstract T Create();
    }

    public interface IClass
    {
        public interface IClassFactory : UnitFactory<IClass>
        {
            public IWeapon CreateWeapon();
            public IArmor CreateArmor();
        }
    }
    public class Fighter : IClass
    {
        public class FighterFactory : IClass.IClassFactory
        {
            public IClass Create()
            {
                CreateArmor();
                CreateWeapon();
                return new Fighter();
            }

            public IArmor CreateArmor()
            {
                return new HeavyArmor();
            }

            public IWeapon CreateWeapon()
            {
                return new Sword();
            }
        }
    }
    public class Wizard : IClass
    {
        public class WizardFactory : IClass.IClassFactory
        {
            public IClass Create()
            {
                CreateArmor();
                CreateWeapon();
                return new Wizard();
            }

            public IArmor CreateArmor()
            {
                return new LeatherArmor();
            }

            public IWeapon CreateWeapon()
            {
                return new Staff();
            }
        }
    }
    public interface ISettingFactory
    {
        public IClass CreateFighter();
        public IClass CreateWizard();
    }
    public class FantasySettingFactory : ISettingFactory
    {
        public IClass CreateFighter()
        {
            return new Fighter();
        }

        public IClass CreateWizard()
        {
            return new Wizard();
        }
    }
    public class SciFiSettingFactory : ISettingFactory
    {
        public IClass CreateFighter()
        {
            return new Fighter();
        }

        public IClass CreateWizard()
        {
            return new Wizard();
        }
    }
    public class CharacterFactory
    {
        public void Start()
        {
            Setting setting = Setting.FANTASY;
            ISettingFactory settingFactory = (setting == Setting.FANTASY) ? new FantasySettingFactory() : new SciFiSettingFactory();

            IClass myWizard = settingFactory.CreateWizard();
        }
    }
}
