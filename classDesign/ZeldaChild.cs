
using static classDesign.ZeldaCreature;

namespace classDesign
{
    class ZeldaLauncher : Zelda
    {
        public ZeldaLauncher()
        {

        }
        public ZeldaLauncher(string explain)
        {
            ZeldaLog(explain);
            //ZeldaManager.GetZeldas.Push(this);
        }
        public enum Mode { New_Game = 1, Load_Game };
        public void StartGame()
        {
            ZeldaSelect();
        }

        public override void ZeldaSelect()
        {
            //ZeldaManager.GetZeldas.Add(this);

            ZeldaChoice<Mode>("안녕하세요. 젤다의 세계로 오신 것을 환영합니다. " +
                "새 게임 또는 불러올 게임을 선택해주십시오. 종료하시려면 언제든 \"종료\"를 입력하십시오.");

            ZeldaLogic(ZeldaInput());
        }

        public override void ZeldaLogic(string input)
        {
            //base.ZeldaLogic(input);
            //ZeldaException(input);
            //여기서 멈춘것. 한사이클 다 돌았으니 다시 여기서부터 출발한다.
            try 
            {
                ZeldaThrow(input);
                switch (input)
                {
                    case "1":
                        ZeldaManager.CreateInstance<Link>(false);
                        break;
                    case "2":
                        ZeldaLog("준비중입니다.");
                        ZeldaSelect();
                        break;
                    default:
                        break;
                }
                
            }
            catch(Exception ex)
            {
                ZeldaCatch(ex);
            }
            finally
            {
                ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            }
            //if (input == "1")
            //{
            //    ZeldaLog("링크 생성");
            //    //Link link = new Link("Link 클래스는 주인공의 정보와 기능을 정의하고 있다. 플레이어가 새 게임을 플레이할 시 생성된다.");
            //    ZeldaManager.CreateInstance<Link>(input);
            //}

            //else if (input == "2")
            //{
                
            //}

            ////else ZeldaSelect();


        }



    }

    //주인공 클래스 게임시작 시 클래스 생성, 게임 과정 중 업데이트되어야함
    class Link : Zelda, IRegionEffect
    {
        public Dictionary<int, Type> logicDictionary = new Dictionary<int, Type>()
        {
            { 1, typeof(ZeldaCreature)},
            { 5, typeof(ZeldaInventory)},
        };

        public List<ZeldaItem> itemList = new List<ZeldaItem>();
        //public List<ZeldaItem> materialList = new List<ZeldaItem>();
        //public List<ZeldaItem> weaponList = new List<ZeldaItem>();
        //public List<ZeldaItem> shieldList = new List<ZeldaItem>();
        //public List<ZeldaItem> foodList = new List<ZeldaItem>();
        //public List<ZeldaItem> clothesList = new List<ZeldaItem>();
        public enum LinkFunction { Warp = 1, Hunt, MarketPlace, Motel, Inven }
        public enum LinkState { Alive, Dead , Hunt, Inventory, Sell, Buy }
        public LinkState state;

        public string name;
        public int hp;
        public int gold;
        public float stamina;
        public int atk;
        public int def;

        //기본스탯
        public Link()
        {

        }

        public Link(string explain)
        {
            //ZeldaManager.currentLink = this;
            //ZeldaManager.GetZeldas.Push(this);
            ZeldaLog(explain);
            name = "Link";
            hp = 4;
            gold = 0;
            stamina = 1;
            atk = 1;
            //ZeldaSelect();

        }

        //저장된 스탯을 불러와서 생성할 때 쓰일 수 있는 생성자
        public Link(string name, int hp, int gold, float stamina)
        {
            this.name = name;
            this.hp = hp;
            this.gold = gold;
            this.stamina = stamina;
        }

        public void Warp()
        {
            ZeldaLog("워프를 한다.");
        }

        public void Hunt()
        {
            ZeldaLog("사냥을 한다.");
        }

        public void MarketPlace()
        {
            ZeldaLog("상점에 간다.");
        }

        public void Motel()
        {
            ZeldaLog("여관에 간다.");
        }

        public void Inven()
        {
            ZeldaLog("인벤토리를 연다.");
        }

        public void Attack(ZeldaCreature creature)
        {
            ZeldaLog(creature + "을/를 공격");

            creature.currentHp -= atk;
            hp -= creature.atk;
            creature.TakeHit();

            ZeldaLog(creature + "의 현재 체력 : " + creature.currentHp);
            ZeldaLog("현재 체력 : " + hp);
        }

        public void UseItem(ZeldaItem item)
        {

        }

        public override void ZeldaSelect()
        {
            //ZeldaManager.GetZeldas.Add(this);
            ZeldaChoice<LinkFunction>("행동을 선택하십시오.");
            ZeldaLogic(ZeldaInput());
        }

        public override void ZeldaLogic(string input)
        {
            //base.ZeldaLogic(input);
            //ZeldaException(input);

            try
            {
                ZeldaThrow(input);
                switch (input)
                {
                    case "1":
                        //Type type = logicDictionary[int.Parse(input)];
                        //ZeldaManager.CreateInstance<>(false);
                        ZeldaManager.CreateInstance<ZeldaRegion>(false);
                        break;
                    case "5":
                        ZeldaManager.CreateInstance<ZeldaInventory>(false);
                        break;
                    default:
                        ZeldaLog("먼저 특정 장소로 워프하십시오.");
                        break;
                }
                
            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);

            }
            finally
            {
                ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            }

        }

        public void EffectByHeat()
        {
            ZeldaLog("Too Hot!");
        }

        public void EffectByCold()
        {
            ZeldaLog("Too Cold!");
        }

        public void EffectByLava()
        {
            ZeldaLog("I'm Burning!");
        }
    }


    //zeldaManager 클래스는 상태에 따라 출력되어야 할 텍스트를 결정해 주는 역할을 해야 할 것.
    //Ex) 링크가 이동할 시 ~~으로 이동한다는 텍스트가 출력되어야 함
    //단, 텍스트 자체는 Manager 클래스에 있어서는 안된다. Manager 클래스는 상태에 따라 다른 것을 출력하겠다고 "결정"하는 역할만 수행
    //문제점 : 텍스트 기반 게임에서 게임을 계속 지속하려면 어떻게 해야 할까?
    //Update가 없기 때문에 함수를 지속적으로 호출하려면 반복문이라던가 따로 절차가 필요할듯 싶다.
    //1. 게임 전체를 거대한 while 문으로 디자인? while문을 멈추기 힘들다..
    //2. 게임플레이에 따라 오브젝트를 지속적으로 생성시키면서 생성자에 게임을 지속시키는 함수를 넣기 zeldaselect 함수가 될듯

    class ZeldaCreature : Zelda
    {
        public ZeldaCreature()
        {

        }
        public ZeldaCreature(string explain)
        {
            //ZeldaManager.GetZeldas.Push(this);
            ZeldaLog(explain);

            //ZeldaSelect();
        }
        public enum CreatureType { Animal = 1, Monster }
        public int fullHp;
        public int currentHp;
        public int atk;
        public string name;
        public override void ZeldaSelect()
        {
            ZeldaChoice<CreatureType>("목표를 선택하십시오");
            ZeldaLogic<CreatureType>(ZeldaInput());
        }

        //public override void ZeldaLogic(string input)
        //{
        //    ZeldaException(input);

        //    if (input == "1")
        //    {
        //        Animal animal = new Animal("");
        //    }

        //    if (input == "2")
        //    {
        //        Monster monster = new Monster();
        //    }
        //}

        //public ZeldaCreature(int hp)
        //{
        //    ZeldaLog();
        //    this.hp = hp;
        //}

        virtual public void TakeHit()
        {

        }

        virtual public void Move()
        {
            ZeldaLog("Move");
        }

        virtual public void Die()
        {

        }

        virtual public void DropItem()
        {

        }
    }

    class ZeldaItem : Zelda
    {
        public enum Type { Weapon, Shield, Clothes, Material, food };
        public Type type;
        public enum Ability { Fire, Electricity, Ice, Water, Normal };
        public Ability ability;

        public enum ItemChoice { 줍기 = 1, 버리기 }
        public enum InvenChoice { 사용하기 = 1, 버리기 }

        public enum SellChoice { 판다 = 1, 그만둔다 }
        public enum BuyChoice { 산다 = 1, 그만둔다 }

        public int effect;
        public int cost;
        public override void ZeldaSelect()
        {
            //다른 곳에서 접근했을 때에도 동일한 메서드를 호출하게끔 하자. 내부에서 갈라지도록
            //ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
            //ZeldaLogic(ZeldaInput());
            switch (ZeldaManager.currentLink.state)
            {
                case Link.LinkState.Hunt:
                    ZeldaChoice<ItemChoice>("행동을 선택하십시오.");
                    break;
                case Link.LinkState.Inventory:
                    ZeldaChoice<InvenChoice>("행동을 선택하십시오.");
                    break;
                case Link.LinkState.Sell:
                    ZeldaChoice<SellChoice>("행동을 선택하십시오.");
                    break;
                case Link.LinkState.Buy:
                    ZeldaChoice<BuyChoice>("행동을 선택하십시오.");
                    break;
                default:
                    break;
            }
            ZeldaLogic(ZeldaInput());
        }
        public void ItemSelect()
        {
            ZeldaChoice<InvenChoice>("행동을 선택하십시오.");
            ItemLogic(ZeldaInput());
        }
        //이 로직은 마음에 들지 않는다. 추후수정필요 - 각각의 상태마다 다른 로직으로 흘러가게 디자인
        //currentlink의 state를 바꾸는 방식? 사냥, 인벤토리, 상점 살 때, 팔 때
        public override void ZeldaLogic(string input)
        {
            try
            {
                ZeldaThrow(input);
                switch (ZeldaManager.currentLink.state)
                {
                    case Link.LinkState.Hunt:
                        switch (input)
                        {
                            case "1":
                                ZeldaLog("아이템 획득 : " + this.GetType().Name);
                                ZeldaManager.currentLink.itemList.Add(this);
                                break;
                            case "2":
                                ZeldaLog("아이템을 버렸다");
                                break;
                        }
                        break;
                    case Link.LinkState.Inventory:
                        switch (input)
                        {
                            case "1":
                                ItemEffect();
                                //극혐방법. 생각했던것보다 로직이 너무 복잡해져서 뒤로가기 기능이
                                //어려워짐.

                                ZeldaManager.currentLink.itemList.Remove(this);
                                break;
                            case "2":
                                ZeldaManager.currentLink.itemList.Remove(this);
                                break;
                            default:
                                break;
                        }
                        break;
                    case Link.LinkState.Sell:
                        switch (input)
                        {
                            case "1":
                                ZeldaManager.currentLink.gold += this.cost;
                                ZeldaLog($"{this.GetType().ToString()}을/를 팔아서 {this.cost} 골드를 얻었습니다.");
                                ZeldaManager.currentLink.itemList.Remove(this);
                                break;
                            case "2":

                                break;
                            default:
                                break;
                        }
                        break;
                    case Link.LinkState.Buy:
                        switch (input)
                        {
                            case "1":
                                ZeldaManager.currentLink.gold -= this.cost;
                                ZeldaLog($"{this.cost} 골드로 {this.GetType()} 을/를 구입했습니다.");
                                ZeldaManager.currentLink.itemList.Add(this);
                                break;
                            case "2":

                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);
                ZeldaManager.currentZelda.ZeldaSelect();
            }
            //finally
            //{
            //    ZeldaManager.currentZelda.ZeldaSelect();
            //}

            //finally
            //{
            //    ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            //}


            //    try
            //    {
            //        if (input=="b")
            //        {
            //            throw new Exception("bItemException");
            //        }

            //        ZeldaThrow(input);

            //        switch (input)
            //        {
            //            case "1":

            //                ZeldaLog("아이템 획득 : "+ this.GetType().Name);

            //                //switch (type)
            //                //{
            //                //    case Type.Weapon:
            //                //        ZeldaManager.currentLink.weaponList.Add(this);
            //                //        break;
            //                //    case Type.Shield:
            //                //        ZeldaManager.currentLink.shieldList.Add(this);
            //                //        break;
            //                //    case Type.Clothes:
            //                //        break;
            //                //    case Type.Material:
            //                //        ZeldaManager.currentLink.materialList.Add(this);
            //                //        break;
            //                //    case Type.food:
            //                //        ZeldaManager.currentLink.foodList.Add(this);
            //                //        break;
            //                //    default:
            //                //        break;
            //                //}

            //                ZeldaManager.currentLink.itemList.Add(this);

            //                break;
            //            case "2":
            //                ZeldaLog("아이템을 버렸다");
            //                break;
            //            default:
            //                break;
            //        }
            //    }

            //    catch (Exception ex)
            //    {
            //        ZeldaCatch(ex);
            //        ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            //    }
            //}
        }
        public virtual void ItemEffect()
        {
            //dosth
            switch (type)
            {
                case Type.food:
                    ZeldaManager.currentLink.hp += effect;
                    break;
                case Type.Weapon:
                    ZeldaManager.currentLink.atk += effect;
                    break;
                case Type.Clothes:
                    ZeldaManager.currentLink.def += effect;
                    break;
                case Type.Material:
                    throw new Exception("UseMaterialException");
                    break;
                default:
                    break;
            }
        }
        
        //인벤토리에서 아이템에 접근했을 때는 다른 로직이 필요하다..쫌 별론데 어쩔수없음
        public void ItemLogic(string input)
        {
            //사용,버리기 그리고 뒤로가기 분기
            try
            {
                ZeldaThrow(input);

                switch (input)
                {
                    case "1":
                        ItemEffect();
                        //극혐방법. 생각했던것보다 로직이 너무 복잡해져서 뒤로가기 기능이
                        //어려워짐.
                        
                        ZeldaManager.currentLink.itemList.Remove(this);
                        break;
                    case "2":
                        ZeldaManager.currentLink.itemList.Remove(this);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                
                ZeldaCatch(ex);
            }
            finally
            {
                ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            }
        }
    }

    class ZeldaRegion : Zelda
    {
        public enum Region { GrassLand = 1, Desert, SnowField, Volcano };
        public enum RegionFunction { HuntingGround = 1, Shop, Motel };
        public Region region;

        public ZeldaRegion()
        {
            ZeldaLog("이동중");
        }

        public ZeldaRegion(string text)
        {
            //ZeldaManager.GetZeldas.Push(this);
            ZeldaLog(text);
            //ZeldaSelect();
            //ZeldaLogic();

        }

        public override void ZeldaSelect()
        {
            //eldaManager.GetZeldas.Add(this);
            //ZeldaManager.currentGame = this;
            ZeldaChoice<Region>("워프할 지역을 선택하십시오.");
            //string input = ZeldaInput();
            ZeldaLogic<Region>(ZeldaInput());
        }

        public override void ZeldaLogic(string input)
        {
            //ZeldaException(input);

            try
            {
                ZeldaThrow(input);
                switch (input)
                {
                    case "1":
                        ZeldaManager.CreateInstance<ZeldaCreature>(false);
                        break;
                    case "2":
                        ZeldaManager.CreateInstance<ZeldaShop>(false);
                        break;
                    case "3":
                        ZeldaManager.CreateInstance<ZeldaMotel>(false);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);
            }
            finally
            {
                ZeldaManager.currentZelda.ZeldaSelect();
            }
           
            
        }
    }

    
    class ZeldaInventory : Zelda
    {
        public ZeldaInventory()
        {

        }
        public ZeldaInventory(string explain)
        {
            //ZeldaManager.GetZeldas.Push(this);
            ZeldaLog(explain);

            //ZeldaSelect();
        }
        public enum InvenChoice { WeaponInventory = 1, ShieldInventory, ClothesInventory, MaterialInventory, FoodInventory }

        public List<ZeldaItem> itemList = new List<ZeldaItem>();

        public override void ZeldaSelect()
        {
            ZeldaChoice<InvenChoice>("인벤토리 종류를 선택하십시오.");
            ZeldaLogic<InvenChoice>(ZeldaInput());
        }

        //각 인벤토리의 공통 로직 : UI - 아이템을 선택하십시오 로직 - 현재 가지고 있는 아이템들을 쫙 나열
        //ZeldaChoice 리스트 버전도 만들어야할듯. 얘는 이넘처럼 정해져있는 것이 아니라 항상 바뀌니까
        //ZeldaLogic은 따로 만들어야하나? input으로 리스트의 인덱스를 가져오자. 그놈의 zeldaselect를 부르면
        //사용하기 or 그만두기 분기가 나오게끔
        public override void ZeldaLogic(string input)
        {
            try
            {
                ZeldaThrow(input);
                //링크 안에서부터 분류를 하는게 맞나? 링크는 획득할때마다 리스트에 넣어주기만 하고 인벤토리에서 분류작업을 실시하는것이 어떨까?
                itemList[int.Parse(input)-1].ZeldaSelect();

            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);
                ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            }
            finally
            {
                ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            }
        }



    }

    class ZeldaShop : Zelda
    {
        public ZeldaShop(string explain) 
        {
            ZeldaLog(explain);
        }
        public enum ShopChoice { Sell = 1, Buy }
        public enum GrassLandItems { Meat = 1 }
        public enum VolcanoItems { Spear = 1 }
        public enum SnowFieldItems { Horn = 1 }
        public enum DesertItems { Teeth = 1 }

        public List<ZeldaItem> GrassLandItemList;
        public List<ZeldaItem> VocanoItemList = new List<ZeldaItem>();
        public List<ZeldaItem> SnowFieldItemList = new List<ZeldaItem>();
        public List<ZeldaItem> DesertItemList = new List<ZeldaItem>();
        public override void ZeldaSelect()
        {
            ZeldaChoice<ShopChoice>("행동을 선택하십시오");
            ZeldaLogic(ZeldaInput());
        }

        public override void ZeldaLogic(string input)
        {
            try
            {
                ZeldaThrow(input);
                switch (input)
                {
                    case "1":
                        ZeldaManager.currentLink.state = Link.LinkState.Sell;
                        //기제작된 인벤토리 클래스 재사용하는거는 문제가 있음 그냥 아이템 리스티 전체 받아서 출력
                        ZeldaChoice(ZeldaManager.currentLink.itemList, "아이템을 선택하십시오.");
                        ZeldaLogic(ZeldaManager.currentLink.itemList, ZeldaInput());
                        ZeldaManager.MoveTo<ZeldaShop>();
                        //ZeldaManager.CreateInstance<ZeldaInventory>(false);
                        
                    break;
                    case "2":
                        ZeldaManager.currentLink.state = Link.LinkState.Buy;
                        switch (ZeldaManager.currentRegion)
                        {
                            case GrassLand:
                                ZeldaChoice<GrassLandItems>("아이템을 선택하십시오.");
                                ZeldaLogic<GrassLandItems>(ZeldaInput());
                            break;
                            case Volcano:
                                ZeldaChoice<VolcanoItems>("아이템을 선택하십시오.");
                                ZeldaLogic<VolcanoItems>(ZeldaInput());
                                break;
                            case SnowField:
                                ZeldaChoice<SnowFieldItems>("아이템을 선택하십시오.");
                                ZeldaLogic<SnowFieldItems>(ZeldaInput());
                                break;
                            case Desert:
                                ZeldaChoice<DesertItems>("아이템을 선택하십시오.");
                                ZeldaLogic<DesertItems>(ZeldaInput());
                                break;
                                

                            default:
                                break;
                        }
                        ZeldaManager.MoveTo<ZeldaShop>();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                ZeldaCatch(ex);
                
            }
            finally 
            {
                ZeldaManager.currentZelda.ZeldaSelect();
            }
        }

    }

    class ZeldaMotel : Zelda
    {
        public ZeldaMotel()
        {
            ZeldaLog("휴식을 취하러 이동합니다.");
        }

        public ZeldaMotel(string explain)
        {
            ZeldaLog(explain);
        }

        public enum Rest {GetRest = 1, GoBack};
        public override void ZeldaSelect()
        {
            ZeldaChoice<Rest>("휴식을 취하겠습니까?");
            ZeldaLogic(ZeldaInput());
        }

        public override void ZeldaLogic(string input)
        {
            int MaxHP = 4;
            try
            {
                ZeldaThrow(input);
                switch (input)
                {
                    case "1":
                        ZeldaLog($"체력이 {MaxHP} 회복되었습니다.");
                        ZeldaManager.currentLink.hp = MaxHP; //Max HP를 설정해 둘 것
                        break;

                    case "2":
                        ZeldaManager.MoveBack();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                ZeldaCatch(ex);
            }
            finally
            {
                ZeldaManager.GetZeldas.Peek().ZeldaSelect();
            }
        }
    }

}
