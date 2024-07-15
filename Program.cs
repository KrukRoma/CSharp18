namespace CSharp18
{ 
    public interface IPcFactory
    {
        Box CreateBox();
        Processor CreateProcessor();
        MainBoard CreateMainBoard();
        Hdd CreateHdd();
        Memory CreateMemory();
    }

    public class PcConfigurator
    {
        private IPcFactory _pcFactory;

        public IPcFactory PcFactory
        {
            get { return _pcFactory; }
            set { _pcFactory = value; }
        }

        public void Configure(Pc pc)
        {
            pc.Box = _pcFactory.CreateBox();
            pc.Processor = _pcFactory.CreateProcessor();
            pc.MainBoard = _pcFactory.CreateMainBoard();
            pc.Hdd = _pcFactory.CreateHdd();
            pc.Memory = _pcFactory.CreateMemory();
        }
    }

    public class Pc
    {
        public Box Box { get; set; }
        public Processor Processor { get; set; }
        public MainBoard MainBoard { get; set; }
        public Hdd Hdd { get; set; }
        public Memory Memory { get; set; }
    }

    public class OfficePcFactory : IPcFactory
    {
        public Box CreateBox() => new BlackBox();
        public Processor CreateProcessor() => new AmdProcessor();
        public MainBoard CreateMainBoard() => new AsusMainBoard();
        public Hdd CreateHdd() => new LGHdd();
        public Memory CreateMemory() => new DdrMemory();
    }

    public class HomePcFactory : IPcFactory
    {
        public Box CreateBox() => new SilverBox();
        public Processor CreateProcessor() => new IntelProcessor();
        public MainBoard CreateMainBoard() => new MSIMainBoard();
        public Hdd CreateHdd() => new SamsungHdd();
        public Memory CreateMemory() => new Ddr2Memory();
    }

    public abstract class Box { }
    public abstract class Processor { }
    public abstract class MainBoard { }
    public abstract class Hdd { }
    public abstract class Memory { }

    public class BlackBox : Box { }
    public class SilverBox : Box { }

    public class AmdProcessor : Processor { }
    public class IntelProcessor : Processor { }

    public class AsusMainBoard : MainBoard { }
    public class MSIMainBoard : MainBoard { }

    public class LGHdd : Hdd { }
    public class SamsungHdd : Hdd { }

    public class DdrMemory : Memory { }
    public class Ddr2Memory : Memory { }
    internal class Program
    {
        static void Main(string[] args)
        {
            PcConfigurator configurator = new PcConfigurator();

            configurator.PcFactory = new OfficePcFactory();
            Pc officePc = new Pc();
            configurator.Configure(officePc);

            configurator.PcFactory = new HomePcFactory();
            Pc homePc = new Pc();
            configurator.Configure(homePc);
        }
    }
}
