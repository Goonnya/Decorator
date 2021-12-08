using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            House house1 = new BrickHouse();
            house1 = new ShopHouse(house1); // кирпичный дом с магазином и мансардным этажом
            house1 = new MansardHouse(house1);
            Console.WriteLine("Название: {0}", house1.Name);
            Console.WriteLine("Цена: {0} млн \n", house1.GetCost());

            House house2 = new BrickHouse();
            house2 = new ShopHouse(house2);
            house2 = new HeatHouse(house2);// кирпичный дом с собственным нагревателем и магазином
            Console.WriteLine("Название: {0}", house2.Name);
            Console.WriteLine("Цена: {0} млн \n", house2.GetCost());

            House house3 = new PanelHouse();
            house3 = new ShopHouse(house3);
            house3 = new HeatHouse(house3);
            house3 = new MansardHouse(house3);// панельный дом с мансардным этажом, собственным нагревателем и магазином
            Console.WriteLine("Название: {0}", house3.Name);
            Console.WriteLine("Цена: {0} млн", house3.GetCost());

            Console.ReadLine();
        }
    }

    abstract class House
    {
        public House(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class BrickHouse : House
    {
        public BrickHouse() : base("Кирпичный дом")
        { }
        public override int GetCost()
        {
            return 100;
        }
    }
    class PanelHouse : House
    {
        public PanelHouse()
            : base("Панельный дом")
        { }
        public override int GetCost()
        {
            return 80;
        }
    }

    abstract class HouseDecorator : House
    {
        protected House house;
        public HouseDecorator(string n, House house) : base(n)
        {
            this.house = house;
        }
    }

    class HeatHouse : HouseDecorator
    {
        public HeatHouse(House p)
            : base(p.Name + ", дом с индивидуальным отоплением", p)
        { }

        public override int GetCost()
        {
            return house.GetCost() + 27;
        }
    }
    class ShopHouse : HouseDecorator
    {
        public ShopHouse(House p)
            : base(p.Name + ", первый этаж сделан под магазины", p)
        { }

        public override int GetCost()
        {
            return house.GetCost() + 11;
        }
    }

    class MansardHouse : HouseDecorator
    {
        public MansardHouse(House p)
            : base(p.Name + ", на мансардном этаже можно жить", p)
        { }

        public override int GetCost()
        {
            return house.GetCost() + 23;
        }
    }
}
