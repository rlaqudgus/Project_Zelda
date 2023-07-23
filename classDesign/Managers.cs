using Newtonsoft.Json;
using System.IO;

namespace classDesign
{
    static class ZeldaManager
    {
        static public Link currentLink;
        static public ZeldaRegion currentRegion;
        static public ZeldaCreature currentTarget;
        //static public List<Zelda> GetZeldas = new List<Zelda>();
        static public Stack<Zelda> GetZeldas = new Stack<Zelda>();
        static public Zelda currentZelda;
        static public Zelda currentState;
        static public List<IRegionEffect> allRegionEffectInstance = new List<IRegionEffect>();
        static public bool isItemGone;
        //static public Stack<Object> GetZeldaObjects = new Stack<Object>();

        static public void MoveBack()
        {
            GetZeldas.Pop();
            currentZelda = GetZeldas.Peek();
        }
        static public void MoveBack(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                GetZeldas.Pop();
            }
            currentZelda = GetZeldas.Peek();
        }
        static public void MoveTo<T>() where T : Zelda
        {
            //스택을 없애버리는게 좋은 방법인가?
            while (GetZeldas.Peek() is not T || GetZeldas.Peek().GetType().IsSubclassOf(typeof(T)))
            {
                GetZeldas.Pop();
            }
            currentZelda = GetZeldas.Peek();
        }

        //인스턴스를 생성하는 부분과 생성한 놈의 로직을 호출하는 부분의 분리가 필요해보임 
        //문제점 : b나 특수키 입력시 exception 거치고 다시 돌아감 못들어가게 막아야함 
       
        //input에 상관없이 무조건 객체를 생성하는 메서드. 밑에놈이랑 너무 똑같아서 추후 수정 예정
        //생성한 놈을 return해주는 놈
        static public Zelda CreateInstance<T>()
        {
            Zelda instance = (Zelda)Activator.CreateInstance(typeof(T));
            //GetZeldas.Push(instance);

            return instance;
        }

        //매개변수로 들어가는놈이 클래스에 대한 설명이었으면 좋겠음
        //현재 이놈이 매개변수를 가지는 이유는? b나 Z 예외처리하려고, 하지만 trycatch로 예외처리를
        //옮겨버리면 매개변수를 가질 필요 x
        //매개변수 string은 저번에 했던것처럼 클래스 생성할때
        //그 클래스 설명하는 string 넣는것으로 대체
        //생성하는 클래스가 어떤 놈인가? 에 따라 스택에 푸쉬할지 안할지,
        //매니저가 알고 있어야 할 정보 입력, 리스트 add 등의 로직 수행
        //현재 아이템이 생성될때는 로직이 좀 헐겁다.. 어쩔 수 없이 아이템만 불값 매개변수를 받아서 다른 처리를 해주자
        static public void CreateInstance<T>(bool isInstant/*, string explain*/)
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
        static public void CreateInstance<T>(bool isItem, ZeldaItem.Type type, ZeldaItem.Ability ability, int effect, int cost)
        {
            Zelda instance = (Zelda)Activator.CreateInstance(typeof(T), type, ability, effect, cost);
            //GetZeldas.Push(instance);

            SwitchCurrentState(instance);

            if (isItem)
            {
                instance.ZeldaSelect();
            }

            //GetZeldas.Peek().ZeldaSelect();
        }

        static public void CreateInstance<T>(bool isItem, List<ZeldaItem> itemList, int maxHp, int hp, int gold, int def, int atk, float stamina)
        {
            Zelda instance = (Zelda)Activator.CreateInstance(typeof(T), itemList, maxHp, hp, gold, def, atk, stamina);
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
        //Region, Animal, Monster, item 목록에 유용하게 쓰일듯하다(미리 정해쟈 있는 목록이라면 enum으로 가능)
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

                    //타입에 따라 매니저가 알아야 할 것들 저장하는 로직

                    SwitchCurrentState(instance);

                    //로직을 실행할 함수 호출.. zeldaselect

                    //GetZeldas.Peek().ZeldaSelect();

                    break;
                }
                
            }
        }

        //미리 정해져 있지 않고 계속 바뀌는 리스트의 경우(인벤토리 아이템은 계속 바뀐다) 비슷한 놈으로 다시 만들어주자
        //새로 만들어줄 필요는 없는데? 아이템 리스트에 접근해서 그놈의 로직만 실행시켜주면 된다
        static public void CreateByItemList(List<ZeldaItem> items, string input)
        {
            if (int.Parse(input) > items.Count || int.Parse(input) <= 0)
            {
                throw new Exception("WrongNumberException : 입력 불가능한 숫자입니다.");
            }

            ZeldaItem currentItem = items[int.Parse(input) - 1];

            currentItem.ZeldaSelect();
        }

        static void SwitchCurrentState(Zelda instance)
        {
            currentZelda = instance;

            //아이템도 푸쉬해줘햐는가? 굳이? 푸쉬해주지 말고 로직 끝나면 특정 분기로 가게끔 코드를 짜면 해결될듯?
            if (!instance.GetType().IsSubclassOf(typeof(ZeldaItem)))
            {
                GetZeldas.Push(instance);
                //currentZelda = instance;
            }

            if (instance is Link)
            {
                currentLink = (Link)instance;
            }
            if (instance.GetType().IsSubclassOf(typeof(ZeldaRegion)))
            {
                currentRegion = (ZeldaRegion)instance;
                RegionEffect();
            }
            if (instance.GetType().IsSubclassOf(typeof(Animal)) || instance.GetType().IsSubclassOf(typeof(Monster)))
            {
                currentTarget = (ZeldaCreature)instance;
            }
            if (instance is ZeldaInventory)
            {
                currentLink.state = Link.LinkState.Inventory;
            }
            if (instance is ZeldaCreature)
            {
                currentLink.state = Link.LinkState.Hunt;
            }
            if (instance is IRegionEffect)
            {
                allRegionEffectInstance.Add((IRegionEffect)instance);
            }
        }

        static public void RegionEffect()
        {
            switch (currentRegion)
            {
                case GrassLand:
                    break;

                case Volcano:
                    //foreach (var item in allRegionEffectInstance)
                    //{
                    //    item.EffectByLava();       
                    //}

                    for (int i = 0; i < allRegionEffectInstance.Count; i++)
                    {
                        allRegionEffectInstance[i].EffectByLava();

                        if (isItemGone)
                        {
                            i -= 1;
                        }

                        isItemGone = false;
                    }
                    //여기서 해줘야함

                    break;

                case SnowField:
                    //foreach (var item in allRegionEffectInstance)
                    //{
                    //    item.EffectByCold();
                    //}
                    for (int i = 0; i < allRegionEffectInstance.Count; i++)
                    {
                        allRegionEffectInstance[i].EffectByCold();

                        if (isItemGone)
                        {
                            i -= 1;
                        }

                        isItemGone = false;
                    }
                    break;

                case Desert:
                    //foreach (var item in allRegionEffectInstance)
                    //{
                    //    item.EffectByHeat();
                    //}
                    for (int i = 0; i < allRegionEffectInstance.Count; i++)
                    {
                        allRegionEffectInstance[i].EffectByHeat();

                        if (isItemGone)
                        {
                            i -= 1;
                        }

                        isItemGone = false;
                    }
                    break;

                default:
                    break;
            }

            if (currentLink.hp<=0)
            {
                allRegionEffectInstance.Clear();
                currentLink.Die();
                
            }
        }
    }

    static class FileManager
    {
        static string path = "./fileTest.txt";
        static public void SaveFile()
        {
            File.WriteAllText(path, String.Empty);

            string jsonString = JsonConvert.SerializeObject(ZeldaManager.currentLink, Formatting.Indented, new JsonSerializerSettings 
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
            Console.WriteLine(jsonString);

            FileStream saveFile =  new FileStream(path, FileMode.OpenOrCreate);
            
            StreamWriter streamWriter = new StreamWriter(saveFile);

            streamWriter.Write(jsonString);
            
            streamWriter.Close();
            saveFile.Close();      
        }

        static public Link LoadFile() 
        {
            FileStream saveFile = new FileStream(path, FileMode.OpenOrCreate);

            StreamReader streamReader = new StreamReader(saveFile);

            string linkInfo = streamReader.ReadToEnd();

            Link link = JsonConvert.DeserializeObject<Link>(linkInfo, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            streamReader.Close();

            saveFile.Close();

            return link;
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
