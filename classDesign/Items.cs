
namespace classDesign
{
    class Meat : ZeldaItem
    {
        //int hpEffect = 1;
        // 인스턴스 생성 시 매개변수로 미리 정보 넣는 방식 채택하는게 좋을듯. 현재 방식은 클래스 생성자 내에서 타입, 능력, 이펙트까지 다 결정
        // 이렇게 하면 같은 아이템이지만 능력이 조금만 달라지는 경우 또 새로운 클래스를 만들어줘야함. 타입, 능력, 이펙트 생성시
        // 미리 넣어주기
        public Meat(string explain)
        {
            type = Type.food;
            ability = Ability.Normal;
            effect = 1;
            ZeldaLog(explain);
        }

        public Meat(Type type, Ability ability, int effect)
        {
            ZeldaLog("고기 아이템 생성");
            this.type = type; 
            this.ability = ability;
            this.effect = effect;
        }
        //아이템이 생성되었을 때는 일단 주워야 하는 건 맞음 줍기 or 버리기
        //그렇다면 인벤에서 접근했을때는?
        public override void ZeldaSelect()
        {
            ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        //public override void ItemSelect()
        //{
        //    ZeldaChoice<InvenChoice>("행동을 선택하십시오.");
        //    ItemLogic(ZeldaInput());
        //}
        public override void ItemEffect()
        {
            ZeldaLog("링크를 " + effect + " 만큼 회복시켰다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }

    }

    class Spear : ZeldaItem
    {
        public Spear(Type type, Ability ability, int effect)
        {
            this.type = type;
            this.ability = ability;
            this.effect = effect;

        }
        public override void ZeldaSelect()
        {
            ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }

        //public override void ItemSelect()
        //{
        //    ZeldaChoice<InvenChoice>("행동을 선택하십시오.");
        //    ItemLogic(ZeldaInput());
        //}
        public override void ItemEffect()
        {
            ZeldaLog("링크가 무기를 장착하여 공격력이 " + effect + " 만큼 상승했다.");
            base.ItemEffect();
            //ZeldaManager.currentLink.hp += hpEffect;
        }
    }

    class Sword : ZeldaItem
    {
        
    }

    class Shield : ZeldaItem
    {

    }

    class Horn : ZeldaItem
    {
        public Horn(string explain)
        {
            ZeldaLog(explain);
            type = Type.Material;
            ability = Ability.Normal;

        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }
    }

    class Teeth : ZeldaItem
    {
        public Teeth(string explain)
        {
            ZeldaLog(explain);
            type = Type.Material;
            ability = Ability.Normal;
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }
    }

    //class BigMeat : ZeldaItem
    //{
    //    //int hpEffect = 3;
    //    public BigMeat(string explain)
    //    {
    //        type = Type.food;
    //        ability = Ability.Normal;
    //        effect = 3;
    //        ZeldaLog(explain);
    //    }
    //    public override void ZeldaSelect()
    //    {
    //        ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
    //        base.ZeldaLogic(ZeldaInput());
    //    }

    //    public override void ItemEffect()
    //    {
    //        ZeldaLog("링크를 " + effect + " 만큼 회복시켰다.");
    //        base.ItemEffect();
    //        //ZeldaManager.currentLink.hp += hpEffect;
    //    }
    //}



}
