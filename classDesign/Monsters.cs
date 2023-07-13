
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


            //item 생성 로직 여기다가 넣자
        }

        public override void DropItem()
        {
            ZeldaManager.CreateInstance<Spear>(true, ZeldaItem.Type.Weapon, ZeldaItem.Ability.Normal, 1);
            ZeldaManager.CreateInstance<Teeth>(true);
            ZeldaManager.CreateInstance<Horn>(true);
        }
    }
}
