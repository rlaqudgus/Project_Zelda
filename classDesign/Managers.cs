namespace classDesign
{
    static class ZeldaManager
    {
        static public Link currentLink;
        static public ZeldaRegion currentRegion;
        static public ZeldaCreature currentTarget;
        //static public List<Zelda> GetZeldas = new List<Zelda>();
        static public Stack<Zelda> GetZeldas = new Stack<Zelda>();
        //static public Stack<Object> GetZeldaObjects = new Stack<Object>();
        static public void LinkStat()
        {
            Console.WriteLine(currentLink.stamina);
            Console.WriteLine(currentLink.hp);
            Console.WriteLine(currentLink.gold);
            Console.WriteLine(currentLink.name);
            Console.WriteLine(currentLink.atk);
        }

        static public void AllZeldaInstances()
        {
            foreach (var item in GetZeldas)
            {
                item.ZeldaSelect();
            }
        }

        static public void MoveBack()
        {
            GetZeldas.Pop();
        }
        static public void MoveBack(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                GetZeldas.Pop();
            }
        }
        static public void MoveTo<T>() where T : Zelda
        {
            while (GetZeldas.Peek() is not T || GetZeldas.Peek().GetType().IsSubclassOf(typeof(T)))
            {
                GetZeldas.Pop();
            }
        }

        //인스턴스를 생성하는 부분과 생성한 놈의 로직을 호출하는 부분의 분리가 필요해보임 
        //문제점 : b나 특수키 입력시 exception 거치고 다시 돌아감 못들어가게 막아야함 
       
        //input에 상관없이 무조건 객체를 생성하는 메서드. 밑에놈이랑 너무 똑같아서 추후 수정 예정
        //일단 아이템 드랍 전용 메서드 push 하지 않고 생성한 그놈의 로직을 호출
        static public void CreateInstance<T>()
        {
            Zelda instance = (Zelda)Activator.CreateInstance(typeof(T), "New Class has been instantiated");
            //GetZeldas.Push(instance);

            SwitchCurrentState(instance);

            instance.ZeldaSelect();
        }

        //매개변수로 들어가는놈이 클래스에 대한 설명이었으면 좋겠음
        //현재 이놈이 매개변수를 가지는 이유는? b나 Z 예외처리하려고, 하지만 trycatch로 예외처리를
        //옮겨버리면 매개변수를 가질 필요 x
        //매개변수 string은 저번에 했던것처럼 클래스 생성할때
        //그 클래스 설명하는 string 넣는것으로 대체
        //생성하는 클래스가 어떤 놈인가? 에 따라 스택에 푸쉬할지 안할지,
        //매니저가 알고 있어야 할 정보 입력, 리스트 add 등의 로직 수행
        //현재 아이템이 생성될때는 로직이 좀 헐겁다.. 어쩔 수 없이 아이템만 불값 매개변수를 받아서 다른 처리를 해주자
        static public void CreateInstance<T>(bool isInstant)
        {
            Zelda instance = (Zelda)Activator.CreateInstance(typeof(T), "New Class " + typeof(T).Name + " has been instantiated");
            //GetZeldas.Push(instance);

            SwitchCurrentState(instance);

            if (isInstant)
            {
                instance.ZeldaSelect();
            }

            //GetZeldas.Peek().ZeldaSelect();
        }
        static public void CreateInstance<T>(bool isItem, ZeldaItem.Type type, ZeldaItem.Ability ability, int effect)
        {
            Zelda instance = (Zelda)Activator.CreateInstance(typeof(T), type, ability, effect);
            //GetZeldas.Push(instance);

            SwitchCurrentState(instance);

            if (isItem)
            {
                instance.ZeldaSelect();
            }

            //GetZeldas.Peek().ZeldaSelect();
        }

        //enum값에 따라 미리 만들어져있는 클래스의 인스턴스를 자동으로 생성,
        //분기에 따라 하나하나 인스턴스화 시키지 않아도 된다.
        //매니저에 정보 저장
        //Region, Animal, Monster, item 목록에 유용하게 쓰일듯하다 
        static public void CreateByEnum(string input, Type enumType)
        {
            if (int.Parse(input)>Enum.GetValues(enumType).Length || int.Parse(input) <=0 )
            {
                throw new Exception("WrongNumberException : 입력 불가능한 숫자입니다.");
            }

            foreach (var item in Enum.GetValues(enumType))
            {

                if (int.Parse(input) == (int)item)
                {

                    //enum 아이템의 이름을 가져와서 어셈블리에 저장되어있는 이름으로 해당 클래스를
                    //찾아 type 변수에 저장

                    Type type = Type.GetType("classDesign." + item.ToString());

                    //Activator로 생성하고
                    //*생성할때 생성자에 로직이 포함되어있기 때문에 밑의 코드는 돌지 않는다.
                    //로직이 끝나야 비로소 밑으로 간다. 따라서 생성자에 input을 포함한 로직은 제거하는것이 맞다.
                    //(제거 완료)

                    Zelda instance = (Zelda)Activator.CreateInstance(type, "New Class " + type.Name + " has been instantiated");


                    //생성한 놈을 stack에 푸쉬

                    //GetZeldas.Push(instance);

                    //타입에 따라 매니저가 알아야 할 것들 저장하는 로직

                    SwitchCurrentState(instance);

                    //로직을 실행할 함수 호출.. zeldaselect

                    //GetZeldas.Peek().ZeldaSelect();

                    break;
                }
                
            }
        }

        static void SwitchCurrentState(Zelda instance)
        {
            //아이템도 푸쉬해줘햐는가? 굳이? 푸쉬해주지 말고 로직 끝나면 특정 분기로 가게끔 코드를 짜면 해결될듯?
            if (!instance.GetType().IsSubclassOf(typeof(ZeldaItem)))
            {
                GetZeldas.Push(instance);
            }

            if (instance is Link)
            {
                currentLink = (Link)instance;
            }
            if (instance.GetType().IsSubclassOf(typeof(ZeldaRegion)))
            {
                currentRegion = (ZeldaRegion)instance;
            }
            if (instance.GetType().IsSubclassOf(typeof(Animal)) || instance.GetType().IsSubclassOf(typeof(Monster)))
            {
                currentTarget = (ZeldaCreature)instance;
            }
        }
        static void SwitchCurrentState(Type type, Zelda instance)
        {
            if (type.IsSubclassOf(typeof(ZeldaRegion)))
            {
                currentRegion = (ZeldaRegion)instance;
            }

            if (type.IsSubclassOf(typeof(Animal))||type.IsSubclassOf(typeof(Monster)))
            {
                currentTarget = (ZeldaCreature)instance;
            }
            
        }
    }

    class UIManager
    {

    }

    interface IRegionEffect
    {
        void EffectByHeat();
        void EffectByCold();
        void EffectByLava();
    }

}
