
namespace classDesign
{
    class Meat : ZeldaItem, IRegionEffect
    {
        //int hpEffect = 1;
        // 인스턴스 생성 시 매개변수로 미리 정보 넣는 방식 채택하는게 좋을듯. 현재 방식은 클래스 생성자 내에서 타입, 능력, 이펙트까지 다 결정
        // 이렇게 하면 같은 아이템이지만 능력이 조금만 달라지는 경우 또 새로운 클래스를 만들어줘야함. 타입, 능력, 이펙트 생성시
        // 미리 넣어주기
        // 기본생성자 얘는 디폴트로 만들때 불러오기(상점에서 살때 등등?)
        public Meat()
        {
            type = Type.food;
            ability = Ability.Normal;
            effect = 1;
            cost = 15;
        }
        public Meat(string explain)
        {
            type = Type.food;
            ability = Ability.Normal;
            effect = 1;
            cost = 15;
            ZeldaLog(explain);
        }

        //아이템은 대부분 이렇게 타입과 능력, 이펙트양을 정해서 생성하도록 한다.(사냥터에서 사냥감이 죽었을 때 드랍)
        public Meat(Type type, Ability ability, int effect, int cost)
        {
            ZeldaLog("고기 아이템 생성");
            this.type = type; 
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        //아이템이 생성되었을 때는 일단 주워야 하는 건 맞음 줍기 or 버리기
        //그렇다면 인벤에서 접근했을때는?
        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog("링크를 " + effect + " 만큼 회복시켰다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }

        public void EffectByHeat()
        {
            ZeldaLog("고기가 말라붙어서 회복량이 감소했습니다.");
            effect -= 1;
        }

        public void EffectByCold()
        {
            ZeldaLog("얼린 고기로 변했다.");
            ability = Ability.Ice;
        }

        public void EffectByLava()
        {
            ZeldaLog("고기가 불타 없어졌다.");
            ZeldaManager.currentLink.itemList.Remove(this);
            ZeldaManager.allRegionEffectInstance.Remove(this);
        }

    }
    class FishMeat : ZeldaItem, IRegionEffect
    {
        public FishMeat()
        {
            type = Type.food;
            ability = Ability.Normal;
            effect = 1;
            cost = 15;
        }

        public FishMeat(string explain)
        {
            type = Type.food;
            ability = Ability.Normal;
            effect = 1;
            cost = 15;
            ZeldaLog(explain);
        }

        //아이템은 대부분 이렇게 타입과 능력, 이펙트양을 정해서 생성하도록 한다.(사냥터에서 사냥감이 죽었을 때 드랍)
        public FishMeat(Type type, Ability ability, int effect, int cost)
        {
            ZeldaLog("물고기 아이템 생성");
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        //아이템이 생성되었을 때는 일단 주워야 하는 건 맞음 줍기 or 버리기
        //그렇다면 인벤에서 접근했을때는?
        public override void ZeldaSelect()
        {
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog("링크를 " + effect + " 만큼 회복시켰다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }

        public void EffectByHeat()
        {
            
        }

        public void EffectByCold()
        {
            
        }

        public void EffectByLava()
        {
            
        }
    }

    class Spear : ZeldaItem, IRegionEffect
    {
        public Spear()
        {
            type = Type.Weapon;
            ability = Ability.Normal;
            effect = 3;
            cost = 100;
        }

        public Spear(string explain)
        {
            type = Type.Weapon;
            ability=Ability.Normal; 
            effect = 3;
            cost = 100;
            ZeldaLog(explain);
            
        }
        public Spear(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        public override void ZeldaSelect()
        {
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog($"링크가 {this.GetType().Name}을/를 장착하여 공격력이 {effect} 만큼 상승했다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            throw new NotImplementedException();
        }
    }

    class Sword : ZeldaItem
    {
        public Sword()
        {
            type = Type.Weapon;
            ability = Ability.Normal;
            effect = 3;
            cost = 100;
        }

        public Sword(string explain)
        {
            type = Type.Weapon;
            ability = Ability.Normal;
            effect = 3;
            cost = 100;
            ZeldaLog(explain);
        }
        public Sword(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        public override void ZeldaSelect()
        {
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog($"링크가{this.GetType().Name}을/를 장착하여 공격력이 {effect} 만큼 상승했다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }
    }

    class Shield : ZeldaItem
    {
        public Shield()
        {
            type = Type.Shield;
            ability = Ability.Normal;
            effect = 10;
            cost = 100;
        }

        public Shield(string explain)
        {
            type = Type.Shield;
            ability = Ability.Normal;
            effect = 10;
            cost = 100;
            ZeldaLog(explain);

        }
        public Shield(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog($"링크가{this.GetType().Name}을/를 장착하여 방어력이 {effect} 만큼 상승했다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }
    }

    class Horn : ZeldaItem, IRegionEffect
    {
        public Horn()
        {
            type = Type.Material;
            ability = Ability.Normal;
            cost = 100;
        }

        public Horn(string explain)
        {
            ZeldaLog(explain);
            type = Type.Material;
            ability = Ability.Normal;
            cost = 10;
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            //ZeldaLog("뿔이 타서 없어졌다.");
            //ZeldaManager.currentLink.itemList.Remove(this);
            //ZeldaManager.allRegionEffectInstance.Remove(this);
        }

        public override void ZeldaSelect()
        {
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            base.ZeldaSelect();
        }
    }

    class Teeth : ZeldaItem, IRegionEffect
    {
        public Teeth()
        {
            type = Type.Material;
            ability = Ability.Normal;
            cost = 100;
        }

        public Teeth(string explain)
        {
            ZeldaLog(explain);
            type = Type.Material;
            ability = Ability.Normal;
            cost = 10;
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            throw new NotImplementedException();
        }

        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }
    }

    class KeeseEye : ZeldaItem
    {
        public KeeseEye()
        {
            type = Type.Material;
            ability = Ability.Normal;
            cost = 30;
        }

        public KeeseEye(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }

        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }
    }

    class KeeseWing : ZeldaItem, IRegionEffect
    {
        public KeeseWing()
        {
            type = Type.Material;
            ability = Ability.Normal;
            cost = 10;
        }
        public KeeseWing(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            throw new NotImplementedException();
        }

        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }
    }

    class ChuchuJelly : ZeldaItem, IRegionEffect
    {
        public ChuchuJelly()
        {
            type = Type.Material;
            ability = Ability.Normal;
            cost = 10;
        }
        public ChuchuJelly(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }

        public void EffectByCold()
        {
            ZeldaLog("츄츄젤리가 하얀츄츄젤리로 변했다!");
            ability = Ability.Ice;   
        }

        public void EffectByHeat()
        {
            ZeldaLog("츄츄젤리가 쪼그라들어서 파괴되었다.");
            ZeldaManager.currentLink.itemList.Remove(this);
            ZeldaManager.allRegionEffectInstance.Remove(this);
            ZeldaManager.isItemGone = true;
        }

        public void EffectByLava()
        {
            ZeldaLog("츄츄젤리가 빨간츄츄젤리로 변했다!");
            ability = Ability.Fire;
        }

        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }
    }

    class Nail : ZeldaItem, IRegionEffect
    {
        public Nail()
        {
            type = Type.Material;
            ability = Ability.Normal;
            cost = 100;
        }

        public Nail(string explain)
        {
            ZeldaLog(explain);
            type = Type.Material;
            ability = Ability.Normal;
            cost = 10;
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            throw new NotImplementedException();
        }

        public override void ZeldaSelect()
        {
            base.ZeldaSelect();
        }
    }

    class Boomerang : ZeldaItem, IRegionEffect
    {
        public Boomerang()
        {
            type = Type.Weapon;
            ability = Ability.Normal;
            effect = 5;
            cost = 100;
        }

        public Boomerang(string explain)
        {
            type = Type.Weapon;
            ability = Ability.Normal;
            effect = 5;
            cost = 100;
            ZeldaLog(explain);

        }
        public Boomerang(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        public override void ZeldaSelect()
        {
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog($"링크가 {this.GetType().Name}을/를 장착하여 공격력이 {effect} 만큼 상승했다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            throw new NotImplementedException();
        }
    }

    class RandomBox : ZeldaItem, IRegionEffect
    {
        public RandomBox()
        {
            type = Type.Material;
            ability = Ability.Normal;
            effect = 5;
            cost = 100;
        }

        public RandomBox(string explain)
        {
            type = Type.Material;
            ability = Ability.Normal;
            effect = 0;
            cost = 100;
            ZeldaLog(explain);

        }
        public RandomBox(Type type, Ability ability, int effect, int cost)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;
            this.cost = cost;
        }
        public override void ZeldaSelect()
        {
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //base.ZeldaLogic(ZeldaInput());
            base.ZeldaSelect();
        }

        public override void ItemEffect()
        {
            ZeldaLog($"{this.GetType().Name}를 사용했다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }

        public void EffectByHeat()
        {
            throw new NotImplementedException();
        }

        public void EffectByCold()
        {
            throw new NotImplementedException();
        }

        public void EffectByLava()
        {
            throw new NotImplementedException();
        }
    }
}
