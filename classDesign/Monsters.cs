
namespace classDesign
{
    class Bokoblin : Monster
    {
        public Bokoblin()
        {

        }
        //여기도 마찬가지, 생성자에 정보를 넣는 방식은 원하는 인스턴스가 조금이라도 달라질때마다 새로운 클래스를 만들어줘야한다는
        //문제점이 있음. 어떤 식으로든 생성할 때 정보를 넣어주느 로직이 필요할듯함
        public Bokoblin(string explain)
        {
            ZeldaLog(explain);
            fullHp = 3;
            currentHp = 3;
            atk = 1;
            name = "Bokoblin";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Spear>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 1, 20);
            ZeldaManager.CreateInstance<Teeth>(true);
            ZeldaManager.CreateInstance<Horn>(true);
        }
    }

    class Moblin : Monster
    {
        public Moblin() { }
        public Moblin(string explain)
        {
            ZeldaLog(explain);
            fullHp = 5;
            currentHp = 5;
            atk = 2;
            name = "Moblin";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Spear>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 3, 30);
            ZeldaManager.CreateInstance<Teeth>(true);
            ZeldaManager.CreateInstance<Horn>(true);
        }
    }

    class Keese : Monster
    {
        public Keese() { }
        public Keese(string explain)
        {
            ZeldaLog(explain);
            fullHp = 1;
            currentHp = 1;
            atk = 1;
            name = "Keese";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<KeeseEye>(true, ZeldaItem.Type.Material, ZeldaItem.Ability.Normal, 0, 15);
            ZeldaManager.CreateInstance<KeeseWing>(true, ZeldaItem.Type.Material, ZeldaItem.Ability.Normal, 0, 5);
        }
    }

    class Octa : Monster
    {
        public Octa() { }
        public Octa(string explain)
        {
            ZeldaLog(explain);
            fullHp = 2;
            currentHp = 2;
            atk = 1;
            name = "Octa";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Teeth>(true);
        }
    }

    class Chuchu : Monster
    {
        public Chuchu()
        {
            
        }

        public Chuchu(string explain)
        {
            ZeldaLog(explain);
            fullHp = 1;
            currentHp = 1;
            atk = 1;
            name = "Chuchu";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<ChuchuJelly>(true,ZeldaItem.Type.Material,ZeldaItem.Ability.Normal,0,8);
        }
    }

    class Hinox : Monster
    {
        public Hinox()
        {

        }

        public Hinox(string explain)
        {
            ZeldaLog(explain);
            fullHp = 50;
            currentHp = 50;
            atk = 5;
            name = "Hinox";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Teeth>(true);
            ZeldaManager.CreateInstance<Meat>(true, ZeldaItem.Type.food, ZeldaItem.Ability.Normal, 10, 30);
            ZeldaManager.CreateInstance<Meat>(true, ZeldaItem.Type.food, ZeldaItem.Ability.Normal, 10, 30);
            ZeldaManager.CreateInstance<Meat>(true, ZeldaItem.Type.food, ZeldaItem.Ability.Normal, 10, 30);
            ZeldaManager.CreateInstance<Sword>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Fire, 20, 150);
        }
    }

    class Lizalfos : Monster
    {
        public Lizalfos()
        {

        }

        public Lizalfos(string explain)
        {
            ZeldaLog(explain);
            fullHp = 10;
            currentHp = 10;
            atk = 2;
            name = "Lizalfos";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Horn>(true);
            ZeldaManager.CreateInstance<Nail>(true);
            ZeldaManager.CreateInstance<Spear>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 5, 40);
            ZeldaManager.CreateInstance<Boomerang>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 4, 30);
        }
    }

    class Lynel : Monster
    {
        public Lynel()
        {

        }

        public Lynel(string explain)
        {
            ZeldaLog(explain);
            fullHp = 150;
            currentHp = 150;
            atk = 15;
            name = "Lynel";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Horn>(true);
            ZeldaManager.CreateInstance<Nail>(true);
            ZeldaManager.CreateInstance<Sword>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 10, 100);
            ZeldaManager.CreateInstance<Shield>(true, ZeldaItem.Type.Shield, ZeldaItem.Ability.Normal, 10, 100);
            ZeldaManager.CreateInstance<Spear>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 15, 100);
        }
    }

    class Molduga : Monster
    {
        public Molduga()
        {

        }

        public Molduga(string explain)
        {
            ZeldaLog(explain);
            fullHp = 100;
            currentHp = 100;
            atk = 10;
            name = "Molduga";
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<MonsterChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        public override void TakeHit()
        {
            ZeldaLog(this.name + " got Hit");
        }

        //아이템이 많을 경우 배열이나 리스트를 받고 loop 돌면서 한꺼번에 생성해주는 메서드가 필요할듯하다
        public override void Die()
        {
            ZeldaLog(this.name + " Died");
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<RandomBox>(true);
        }
    }
}
