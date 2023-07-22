namespace classDesign
{
    class GrassLand : ZeldaRegion
    {
        public GrassLand(string explain)
        {
            ZeldaLog(explain);
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<RegionFunction>("행동을 선택하십시오.");

            //ZeldaLogic(ZeldaInput(),DefaultLogic.Region);
            base.ZeldaLogic(ZeldaInput());
        }

    }

    class Desert : ZeldaRegion
    {
        public Desert(string explain)
        {
            ZeldaLog(explain);
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<RegionFunction>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }
    }

    class SnowField : ZeldaRegion
    {
        public SnowField(string explain)
        {
            ZeldaLog(explain);
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<RegionFunction>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
        }
    }

    class Volcano : ZeldaRegion
    {
        public Volcano(string explain)
        {
            //ZeldaManager.GetZeldas.Push(this);
            //ZeldaManager.currentRegion = this;
            ZeldaLog(explain);
            //ZeldaSelect();
        }

        public override void ZeldaSelect()
        {
            ZeldaChoice<RegionFunction>("행동을 선택하십시오.");
            base.ZeldaLogic(ZeldaInput());
            //ZeldaLogic(ZeldaInput(), DefaultLogic.Region);
        }
    }

    class Animal : ZeldaCreature
    {
        public Animal()
        {

        }
        public Animal(string str)
        {
            //ZeldaManager.GetZeldas.Push(this);
            //ZeldaManager.GetZeldaObjects.Push(this);
            ZeldaLog(str);
            ZeldaLog("Animal 클래스는 플레이어가 동물을 사냥할 시 생성되는 클래스이다. 지역에 따른 동물의 종류가 각각의 enum으로 정의되어 있다.");
            //ZeldaSelect();
        }

        public enum CurrentAnimal { };
        public enum GrassLandAnimal { Fox = 1, Deer, Boar, Fish, Horse, Wolf, Pigeon }
        public enum DesertAnimal { SandSeal = 1, Scorpion, SandLizard }
        public enum SnowFieldAnimal { SnowWolf = 1, ReinDeer, Bear, Rhinoceros, WhitePigeon }
        public enum VolcanoAnimal { GoldenSparrow = 1, VolcanoOstrich }

        public enum AnimalChoice { Attack = 1, Leave }
        public override void ZeldaSelect()
        {
            switch (ZeldaManager.currentRegion)
            {
                case GrassLand:
                    ZeldaChoice<GrassLandAnimal>("사냥감을 선택하십시오.");
                    ZeldaLogic<GrassLandAnimal>(ZeldaInput());
                    break;
                case SnowField:
                    ZeldaChoice<SnowFieldAnimal>("사냥감을 선택하십시오.");
                    ZeldaLogic<SnowFieldAnimal>(ZeldaInput());
                    break;
                case Desert:
                    ZeldaChoice<DesertAnimal>("사냥감을 선택하십시오.");
                    ZeldaLogic<DesertAnimal>(ZeldaInput());
                    break;
                case Volcano:
                    ZeldaChoice<VolcanoAnimal>("사냥감을 선택하십시오.");
                    ZeldaLogic<VolcanoAnimal>(ZeldaInput());
                    break;
                default:
                    break;
            }
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
                        ZeldaManager.currentLink.Attack(this);
                        if (this.currentHp <= 0)
                        {
                            this.Die();
                            this.DropItem();
                            //죽는것과 아이템 드랍 로직 분리
                            //동물이 죽고 아이템을 드랍하면 아이템 생성
                            //(생성과 동시에 아이템 로직 호출-획득할지 말지)
                            //선택 후 다시 여기로 돌아와서 두번 뒤로 돌리기(사냥감 선택 로직으로)
                            //(한번 뒤로 돌리면 다시 공격/그만두기 로직으로 돌아가는데 사냥이 끝난 상태에서
                            //다시 돌아가면 어색한듯)

                            ZeldaManager.MoveTo<Animal>();
                        }
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
                ZeldaManager.currentZelda.ZeldaSelect();
            }
        }
       
    }

    class Monster : ZeldaCreature
    {
        public Monster()
        {

        }
        public Monster(string explain)
        {
            ZeldaLog(explain);
        }

        public enum GrassLandMonster { Bokoblin = 1, Moblin, Keese, Octa, Chuchu, Hinox }
        public enum SnowFieldMonster { Moblin = 1, Lizalfos, Keese, Octa, Chuchu, Lynel }
        public enum DesertMonster { Moblin = 1, Lizalfos, Molduga, Lynel }
        public enum VolcanoMonster { Moblin = 1, Lizalfos, Keese, Octa, Chuchu, Lynel }
        public enum MonsterChoice { Fight = 1, Leave }

        public override void ZeldaSelect()
        {
            switch (ZeldaManager.currentRegion)
            {
                case GrassLand:
                    ZeldaChoice<GrassLandMonster>("몬스터를 선택하십시오.");
                    ZeldaLogic<GrassLandMonster>(ZeldaInput());
                    break;
                case SnowField:
                    ZeldaChoice<SnowFieldMonster>("몬스터를 선택하십시오.");
                    ZeldaLogic<SnowFieldMonster>(ZeldaInput());
                    break;
                case Desert:
                    ZeldaChoice<DesertMonster>("몬스터를 선택하십시오.");
                    ZeldaLogic<DesertMonster>(ZeldaInput());
                    break;
                case Volcano:
                    ZeldaChoice<VolcanoMonster>("몬스터를 선택하십시오.");
                    ZeldaLogic<VolcanoMonster>(ZeldaInput());
                    break;
                default:
                    break;
            }
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
                        ZeldaManager.currentLink.Attack(this);
                        if (this.currentHp <= 0)
                        {
                            this.Die();
                            this.DropItem();
                            //죽는것과 아이템 드랍 로직 분리
                            //동물이 죽고 아이템을 드랍하면 아이템 생성
                            //(생성과 동시에 아이템 로직 호출-획득할지 말지)
                            //선택 후 다시 여기로 돌아와서 두번 뒤로 돌리기(사냥감 선택 로직으로)
                            //(한번 뒤로 돌리면 다시 공격/그만두기 로직으로 돌아가는데 사냥이 끝난 상태에서
                            //다시 돌아가면 어색한듯)

                            //아이템을 여러개 생성했을 때 문제점 발생 - 두번 뒤로 가는 것은 아이템 하나 기준 말이 됨.
                            //그러나 3개 생성했을 때는 두번 뒤로가면 첫번째 아이템 분기로직으로 가버림
                            //특정 분기로 바로 이동하는 메서드가 필요하다 - 매개변수는 Zelda로 넣고 createinstance로 생성
                            ZeldaManager.MoveTo<Monster>();
                        }
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
                ZeldaManager.currentZelda.ZeldaSelect();
            }
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
    }

}
