namespace _Game.Data
{
    public class DStats
    {
        public float HP { get;  set;  }
        public float MP { get;  set; }
        public float maxHP { get;  set; } //statID 1
        public float maxMP { get;  set; } //statID 2
        public int inteligence { get;  set; } //statID 3
        public int force { get;  set; } //statID 4
        public int dexterity { get;  set; } //statID 5
        public int agility { get;  set; } //statID 6
        public int defense { get;  set; } //statID 7
        public int magicDefense { get;  set; } //statID 8
        
        //Stats %
        public int windResistence { get;  set; }
        public int waterResistence { get;  set; }
        public int earthResistence { get;  set; }
        public int fireResistence { get;  set; }
        public int windBonus { get;  set; }
        public int waterBonus { get;  set; }
        public int earthBonus { get;  set; }
        public int fireBonus { get;  set; }
    }
}