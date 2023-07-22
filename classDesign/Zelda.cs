namespace classDesign
{
    //최상위 클래스. 유틸리티 함수 및 virtual / abstract 함수 포함. 
    abstract class Zelda
    {
        public enum DefaultLogic { Region = 1, Hunt}
        public Zelda()
        {

        }
        public Zelda(string explain)
        {
            ZeldaLog(explain);
            //ZeldaSelect();
        }

        // ZeldaOver는 게임을 종료하는 메서드
        public void ZeldaOver()
        {
            ZeldaLog("즐겨주셔서 감사합니다. 다음에 또 뵙기를.");

            Environment.Exit(0);
        }
        
        // ZeldaLog는 현재 시간, 호출한 클래스를 확인하기 위한 메서드
        public void ZeldaLog()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "]" + " " + "[" + this.GetType().Name + "]");
        }

        // ZeldaLog 오버로딩 : 현재 시간, 호출한 클래스 그리고 원하는 텍스트를 출력 가능.
        public void ZeldaLog(string input)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "]" + " " + "[" + this.GetType().Name + "]" + " " + input);
        }

        // ZeldaLoad 미정
        public void ZeldaLoad(int loadTime, string name)
        {
            ZeldaLog(name + "으로 이동중");
        }

        //디자인 : Zelda의 모든 하위 클래스들은 ZeldaSelect라는 메서드를 구현해야함.

        //ZeldaSelect에는 현재 클래스에 따라 다른 UI(텍스트) 출력, 입력에 따른 로직 존재 
        //최상위클래스 Zelda는 인스턴스화할 일이 없으므로 추상클래스화,
        //ZeldaSelect는 하위 클래스들에서 override 하기 위해 추상메서드화
        //- 클래스마다 다른 UI, 다른 로직 넣어야 하기 때문
        abstract public void ZeldaSelect();

        // ZeldaChoice 메서드는 zeldaselect에서 UI의 역할 수행.
        // Enum을 받아 보기를 출력해주는 메서드.
        // 상황에 따라 보기 출력 전에 필요한 설명을 매개변수로 넣어줄 수 있다.
        public void ZeldaChoice<T>(string text) where T : Enum
        {
            Type type = typeof(T);

                foreach (var item in Enum.GetValues(type))
                {
                    text += "\n" + (int)item + "." + " " + item;
                }

                ZeldaLog(text);
        }

        //인벤토리에 존재하는 아이템 설명 창 전용 UI
        public void ZeldaChoice(List<ZeldaItem> items, string text)
        {
            if (items.Count==0)
            {
                ZeldaLog("아이템이 없습니다.");
                return;
            }
            for (int i = 0; i < items.Count; i++)
            {
                text += "\n" + (i+1) + "." + " " + items[i].GetType().Name +
                    " Type : " + items[i].type + "/" + 
                    " Ability : " + items[i].ability + "/" +
                    " effect : " + items[i].effect + "/" +
                    " cost : " + items[i].cost;
            }
            ZeldaLog(text);
        }

        // ZeldaLogic 메서드는 클래스마다 다른 로직을 가지고 있는 메서드.
        // 그러나 어떤 상황에도 공통적으로 같은 기능을 수행해야 할 경우가 존재
        // ex) 게임의 어떤 상황이든 "종료" 를 입력 시 게임을 종료하는 기능
        //     게임의 어떤 상황이든 "b" 입력 시 그 전 상황으로 되돌아가는 기능
        //     다양한 디버그 메서드들 or 예외처리
        // 따라서 공통 로직은 virtual로 선언한 가상메서드에 넣어주고, 상황마다 다른 로직은
        // 상속받은 클래스에서 override하여 구현.
        virtual public void ZeldaLogic(string input)
        {
            
        }

        //input에 따라 미리 설정해놓은 enum 이름을 불러와서 자동으로 객체 생성하는 방식 - 매개변수 or generic
        //choice에서 사용했던 로직과 비슷. 이넘을 generic으로 받아서 loop 돌며
        //입력값과 비교 후 같으면 그놈의 어셈블리상 클래스명을 가져다 Activator.CreateInstance
        //메서드로 런타임에 생성. 미리 정의하기엔 너무 양이 많을 경우 용이하게 사용할 수 있음
        public void ZeldaLogic<T>(string input) where T : Enum
        {
            Type type = typeof(T);

            try
            {
                if (input=="b" && this is ZeldaShop)
                {
                    throw new Exception("bItemException");
                }
                ZeldaThrow(input);
                ZeldaManager.CreateByEnum(input, type);
            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);
            }
            finally
            {
                //ZeldaManager.RegionEffect();
                ZeldaManager.currentZelda.ZeldaSelect();
            }
        }

        public void ZeldaLogic(List<ZeldaItem> zelda, string input)
        {
            try
            {
                if (zelda.Count == 0 && input=="b")
                {
                    throw new Exception("InventorybException");
                }
                //if (input == "b")
                //{
                //    throw new Exception("bItemException");
                //}
                ZeldaThrow(input);
                //ZeldaManager.CreateByEnum(input, type);
                ZeldaManager.CreateByItemList(zelda, input);
                
            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);
            }
            finally
            {
                //ZeldaManager.RegionEffect();
                ZeldaManager.currentZelda.ZeldaSelect();
            }
        }
       

        // ZeldaInput 메서드는 플레이어의 입력을 맡고 있는 메서드.
        // ZeldaLogic의 매개변수로 쓰인다.
        public string ZeldaInput()
        {
            ZeldaLog("명령어는 보기에 주어진 숫자 혹은 특정 문자열만 가능합니다.\n허용되는 명령어 리스트를 확인하려면 \"c\" 를 입력하십시오.");
            ZeldaLog("명령어를 입력하십시오.");

            string input = Console.ReadLine();

            return input;
        }

        public void ZeldaThrow(string input)
        {
            
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("nullException");
                //ZeldaSelect();
            }
            
            if (input == "종료" || input == "exit")
            {
                throw new Exception("GameOver");
            }
            if (input == "b")
            {
                throw new Exception("bException");
            }

            if (input == "z")
            {
                throw new Exception("zException");
            }

            if (input == "l")
            {
                throw new Exception("lException");
            }

            if(input == "c")
            {
                throw new Exception("cException");
            }

            if (!int.TryParse(input, out int result))
            {
                throw new Exception("IntegerException");
            }
           
        }

        public void ZeldaCatch(Exception ex)
        {
            ZeldaLog("처리된 예외 : " + ex.Message);
            switch (ex.Message)
            {
                case "nullException":
                    //ZeldaSelect();
                    ZeldaLog("명령어를 입력하지 않았습니다.");
                    break;

                case "GameOver":
                    ZeldaOver();
                    break;

                case "bException":
                    
                    try
                    {
                        if (ZeldaManager.GetZeldas.Count == 1)
                        {
                            throw new Exception();
                        }
                        ZeldaManager.MoveBack();
                    }
                    catch
                    {
                        ZeldaLog("뒤로 갈 수 없습니다.");
                        //throw new Exception("더 이상 뒤로 갈 수 없을 때 처리되는 예외");
                        //ZeldaSelect();
                    }
                    break;

                case "zException":
                    ZeldaLog(ZeldaManager.GetZeldas.Count.ToString());

                    foreach (var item in ZeldaManager.GetZeldas)
                    {
                        Console.WriteLine(item.GetType().ToString());
                    }
                    ZeldaLog();
                    //foreach (var item in ZeldaManager.GetZeldaObjects)
                    //{
                    //    Console.WriteLine(item.GetType().ToString());
                    //}

                    if (ZeldaManager.currentLink==null)
                    {
                        ZeldaLog("링크가 생성되기 전이기 때문에 정보를 확인할 수 없습니다.");
                        break;
                    }
                   


                    ZeldaLog("현재 링크 상태 :"
                        + " name - " + ZeldaManager.currentLink.name
                        + " Hp - " + ZeldaManager.currentLink.hp
                        + " Stamina - " + ZeldaManager.currentLink.stamina
                        + " Gold - " + ZeldaManager.currentLink.gold
                        + " atk - " + ZeldaManager.currentLink.atk
                        + " currentRegion - " + ZeldaManager.currentRegion
                        + " currentTarget - " + ZeldaManager.currentTarget);

                    ZeldaLog("현재 아이템");

                    foreach (var item in ZeldaManager.currentLink.itemList)
                    {
                        ZeldaLog(item.ToString());
                    }

                    ZeldaLog("현재 IregionEffect 인스턴스");

                    foreach (var item in ZeldaManager.allRegionEffectInstance)
                    {
                        ZeldaLog(item.ToString());
                    }
                    //ZeldaSelect();
                    break;

                case "bItemException":
                    //ZeldaLog("아이템 습득 창에서는 뒤로 갈 수 없습니다. 먼저 행동을 선택하십시오.");
                    break;

                case "integerException":
                    ZeldaLog("잘못된 명령어입니다. 보기 중의 숫자를 입력하십시오.");
                    break;

                case "lException":
                    try
                    {
                        if (ZeldaManager.currentLink==null)
                        {
                            throw new Exception();
                        }
                        ZeldaManager.currentZelda = ZeldaManager.currentLink;
                    }
                    catch
                    {
                        ZeldaLog("링크를 참조할 수 없습니다. 주인공을 생성하기 전인지 확인하십시오.");
                    }
                    break;
                case "UseMaterialException":
                    ZeldaLog("소재는 가공되기 전까지 사용할 수 없습니다.");
                    break;
                case "cException":
                    ZeldaLog("\nb : 뒤로가기\nz : stack 확인 및 주인공 현재 상태 확인\nl : 빠른 워프 및 인벤토리 확인\nc : 명령어 확인\n종료 및 exit : 빠른 종료");
                    break;
                case "InventorybException":
                    ZeldaManager.MoveBack();
                    break;
                default:
                    break;
            }
        }
        public void ZeldaException(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                ZeldaLog("명령어를 입력하지 않았습니다.");
                throw new Exception("사용자가 빈칸을 입력하면 처리되는 예외.");
                //ZeldaSelect();
            }
            if (input == "종료")
            {
                ZeldaOver();
            }
            //여기에 그만두기 기능 추가(B로 할까)
            if (input == "b")
            {
                try
                {
                    ZeldaManager.MoveBack();
                }
                catch
                {
                    ZeldaLog("뒤로 갈 수 없습니다.");
                    throw new Exception("더 이상 뒤로 갈 수 없을 때 처리되는 예외");
                    //ZeldaSelect();
                }

            }
            if (input == "Z")
            {
                ZeldaLog(ZeldaManager.GetZeldas.Count.ToString());

                foreach (var item in ZeldaManager.GetZeldas)
                {
                    Console.WriteLine(item.GetType().ToString());
                }
                ZeldaLog();
                //foreach (var item in ZeldaManager.GetZeldaObjects)
                //{
                //    Console.WriteLine(item.GetType().ToString());
                //}

                ZeldaLog("현재 링크 상태 :"
                    + " name - " + ZeldaManager.currentLink.name
                    + " Hp - " + ZeldaManager.currentLink.hp
                    + " Stamina - " + ZeldaManager.currentLink.stamina
                    + " Gold - " + ZeldaManager.currentLink.gold
                    + " currentRegion - " + ZeldaManager.currentRegion
                    + " currentTarget - " + ZeldaManager.currentTarget);

                ZeldaLog("현재 아이템");

                foreach (var item in ZeldaManager.currentLink.itemList)
                {
                    ZeldaLog(item.ToString());
                }


                ZeldaSelect();
                return;
            }


           
        }
    }
}
