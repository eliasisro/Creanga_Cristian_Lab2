using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace Creanga_Cristian_Lab2
{
    class DoughnutMachine
    {
        private DoughnutType mFlavor;
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }

        public System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
        public Doughnut this[int index]
        {
            get
            {
                return (Doughnut)mDoughnuts[index];
            }
            set
            {
                mDoughnuts[index] = value;
            }
        }

        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        public DispatcherTimer DoughnutTimer;

        private void InitializeComponent()
        {
            this.DoughnutTimer = new DispatcherTimer();
            this.DoughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }
        public DoughnutMachine()
        {
            InitializeComponent();
        }
        public bool Enabled
        {
            set
            {
                DoughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                DoughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        public void MakeDoughnuts(DoughnutType dFlavor)
        {

            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            DoughnutTimer.Start();
        }
    }

}
public enum DoughnutType
{
    Glazed,
    Sugar,
    Lemon,
    Chocolate,
    Vanilla
}

public class Doughnut
{
    private DoughnutType mFlavor;

    public DoughnutType Flavor
    {
        get
        {
            return mFlavor;
        }
        set
        {
            mFlavor = value;
        }
    }
    private float mPrice = .50F;
    public float Price
    {
        get
        {
            return mPrice;
        }
        set
        {
            mPrice = value;
        }
    }
    private readonly DateTime mTimeOfCreation;
    public DateTime TimeOfCreation
    {
        get
        {
            return mTimeOfCreation;
        }

    }

    public Doughnut(DoughnutType aFlavor) // constructor
    {
        mTimeOfCreation = DateTime.Now;
        mFlavor = aFlavor;
    }

}


