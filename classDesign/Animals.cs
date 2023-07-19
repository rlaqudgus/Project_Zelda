namespace classDesign
{
    // Fish, Horse, Wolf, Pigeon
    class Fox : Animal
    {
        public Fox()
        {

        }
        public Fox(string explain)
        {
            ZeldaLog(explain);
            fullHp = 1;
            currentHp = 1;
            name = "Fox";
            //ObtainableItems.Add(meat);
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<AnimalChoice>("행동을 선택하십시오.");
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
            ZeldaManager.CreateInstance<Meat>(true, ZeldaItem.Type.food, ZeldaItem.Ability.Normal, 1, 5);
        }
    }

    class Deer : Animal
    {
        public Deer(string explain)
        {
            ZeldaLog(explain);
            fullHp = 2;
            currentHp = 2;
            name = "Deer";
        }
        public override void ZeldaSelect()
        {
            ZeldaChoice<AnimalChoice>("행동을 선택하십시오.");
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
            ZeldaManager.CreateInstance<Meat>(true, ZeldaItem.Type.food, ZeldaItem.Ability.Normal, 2, 10);
        }
    }

    class Boar : Animal
    {
        public Boar(string explain)
        {
            fullHp = 2;
            currentHp = 2;
            name = "Boar";
            ZeldaLog(explain);
        }
        public override void ZeldaSelect()
        {
            ZeldaChoice<AnimalChoice>("행동을 선택하십시오.");
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
            ZeldaManager.CreateInstance<Meat>(true, ZeldaItem.Type.food, ZeldaItem.Ability.Normal, 3, 15);
        }
    }

    class Fish : Animal
    {

    }

    class Horse : Animal
    {

    }

    class Wolf : Animal
    {

    }

    class Pigeon : Animal
    {

    }
}
